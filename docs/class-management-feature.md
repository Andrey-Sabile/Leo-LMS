# Class Management Feature Vertical Slice

Documentation for implementing the class management vertical slice that powers the teacher-facing class workspace, roster administration, and timetable context.

---

## Feature Goals & Scope

- Provide teachers with a multi-class dashboard summarizing key metrics (enrollment counts, next lesson, outstanding tasks).
- Enable roster management actions: add/remove students, assign co-teachers, and manage class metadata (subject tags, schedule blocks).
- Surface a timetable overview with class meeting times and room assignments.
- Deliver a tabbed class workspace (`Classwork`, `Attendance`, `Marks`) that shares a synchronized context (classroom, academic term, time window, optional student focus) for any authorized role, with fine-grained authorization layered later.
- Support bulk roster imports/exports and soft-deletion for historical records.
- Ensure data flows align with the gradebook, assignments, and attendance modules without duplicating sources of truth.

Non-goals (document but defer):
- Automated timetable conflict resolution.
- Parent visibility into class setup details (handled via other features).
- Integration with SIS rosters (future extension).

---

## Domain Design

### Aggregates & Entities

- **Classroom (Aggregate Root)**  
  - Derive from `BaseAuditableEntity` and live under `src/Domain/ClassManagement`. Expose immutable `Id` plus `ClassCode`, `Title`, `SubjectTagIds`, `AcademicTermId`, `Room`, `SchedulePattern`, `WorkspaceSettings`, `IsArchived`, and `ArchivedOn`. Back student and instructor relationships with private collections (e.g., `_memberships`, `_instructors`) and surface `IReadOnlyCollection` views so only aggregate methods can mutate them.  
  - Provide a static factory `Create` that requires a primary instructor identifier, validates the supplied `ClassCode` against the current academic term (delegate uniqueness checks to a domain service or specification passed in), populates initial schedule/workspace settings, and immediately raises `ClassroomCreatedEvent`.  
  - Implement domain behaviors:  
    - `UpdateMetadata` for title, subject tags, room, and schedule pattern changes (re-run schedule validations before applying).  
    - `AssignInstructor`/`RemoveInstructor` and `PromoteInstructorToPrimary` that coordinate updates to `ClassInstructor` entities while enforcing the single-primary invariant; emit `ClassRosterChangedEvent` when the roster changes.  
    - `EnrollStudent`/`WithdrawStudent` helpers that manage `ClassMembership` entries, prevent duplicate active enrollments, and ensure `JoinedOn`/`LeftOn` timestamps are captured.  
    - `Archive`/`Restore` that toggle `IsArchived`, set `ArchivedOn`, and raise `ClassroomArchivedEvent` (guard `Archive` with a flag supplied by the application layer indicating unresolved assignments).  
    - `UpdateWorkspaceSettings` that normalizes date windows, confirms highlighted student ids exist in the active roster, and raises `ClassWorkspaceSettingsUpdatedEvent` when defaults change.  
  - Keep constructors private, rely on methods so invariants remain centralized.
- **ClassMembership**  
  - A join entity for student enrollment. Use a composite key (`ClassroomId`, `StudentId`) and store `EnrollmentStatus` (Active, Pending, Withdrawn), `JoinedOn`, `LeftOn`, `SeatNumber`, and `Notes`.  
  - Provide methods `Activate`, `MarkPending`, `Withdraw(leftOn, note?)`, all of which enforce that only one active membership exists per student, `JoinedOn` is mandatory when activating, and `LeftOn` is required when withdrawing.
- **ClassInstructor**  
  - Join entity between classroom and teacher with composite key (`ClassroomId`, `TeacherId`). Hold `Role` (Lead, CoTeacher, Assistant) and `IsPrimary`.  
  - Expose behaviors `AssignRole` and `PromoteToPrimary`. Promotion should happen through the aggregate so it can demote any existing primary before elevating the new instructor.
- **ScheduleBlock** (Value Object)  
  - Owned by `Classroom` and persisted as an owned collection. Encapsulate `DayOfWeek`, `StartTime`, `EndTime`, `Location`, and `RotationCode`. Include overlap checks (`ConflictsWith`) and validation (e.g., `StartTime < EndTime`). These utilities are consumed by `Classroom.UpdateMetadata` to block conflicting schedules.

### Value Objects

- **SubjectTag**  
  - Reuse an existing lookup aggregate if available; otherwise model as a value object containing `Code`, `DisplayName`, `ColorHex`. Ensure `Code` uses a canonical format and is compared case-insensitively.
- **SchedulePattern**  
  - Wrap recurring schedule metadata such as cadence (Weekly, ABRotation) and application notes. Offer named constructors (e.g., `SchedulePattern.Weekly(...)`, `SchedulePattern.Rotating(...)`) that pre-validate inputs before assigning backing fields.
- **ClassWorkspaceSettings**  
  - Owned by `Classroom` and immutable. Capture `DefaultTab` (enum: Classwork, Attendance, Marks), `DefaultDateRange` (`WorkspaceDateRange` value object), `DefaultStudentScope` (`AllStudents`, `HighlightedStudentId`), and `IncludeArchivedByDefault`.  
  - Centralize validation to confirm highlighted student ids exist in the active roster (accept a lookup delegate or raise a deferred validation error provided by the aggregate), and ensure date ranges fall inside the academic term. Provide helpers for merging new settings without mutating unchanged values to avoid unnecessary events.
- **WorkspaceDateRange**  
  - Encapsulate window logic with factories like `WorkspaceDateRange.ThisWeek(referenceDate)` and `WorkspaceDateRange.Custom(start, end)`. Guard against empty windows (`start <= end`) and expose operations such as `ShiftForward(days)` used by reporting workflows.

### Invariants & Business Rules

- `ClassCode` must remain unique within the scope of an academic term. Enforce during creation and when metadata updates attempt to change the code.  
- Maintain at least one primary instructor before a class can be published or made active. Primary status moves must demote the previous primary within the same transaction.  
- Archival requires downstream confirmation that assignments/assessments have been migrated or closed (`Archive` should accept a `hasActiveAssignments` argument and throw if true).  
- A student cannot hold two simultaneous active memberships; calling `EnrollStudent` while an active membership exists should return the existing entity or throw based on the application policy.  
- Withdrawing a student forces a `LeftOn` timestamp and transitions `EnrollmentStatus` to Withdrawn. Re-enrollment after withdrawal should reset timestamps through the aggregate.  
- Roster edits (student or instructor) must enqueue `ClassRosterChangedEvent` describing additions and removals, so gradebook and attendance projections can respond.  
- Workspace defaults must reference valid tabs, honor active membership for highlighted students, and maintain a date window aligned with the classroom's academic term start/end boundaries.

### Domain Events

- **ClassroomCreatedEvent** — emitted by `Classroom.Create`; include classroom id, academic term, primary instructor id, and initial schedule metadata.  
- **ClassroomArchivedEvent** — triggered by `Archive`/`Restore` transitions; payload should include new archival state and effective timestamps.  
- **ClassRosterChangedEvent** — fired after instructor or student roster mutations with collections documenting added and removed ids (separated for students and instructors).  
- **ClassWorkspaceSettingsUpdatedEvent** — dispatched whenever default tab, date range, or highlighted student scope changes so cached workspace snapshots can refresh without polling.  
- All events should inherit from the solution-wide `BaseEvent` so mediator pipelines can publish them consistently.

---

## Application Layer

Located under `src/Application/ClassManagement` with subfolders `Commands`, `Queries`, `Dtos`.

### Commands

1. **CreateClassCommand : IRequest<int>**
   - Payload: `ClassCode`, `Title`, `SubjectTagIds`, `AcademicTermId`, optional schedule blocks, primary instructor id.
   - Handler ensures uniqueness, creates `Classroom`, assigns instructor, emits `ClassroomCreatedEvent`.
2. **UpdateClassCommand : IRequest**
   - Allows editing metadata, schedule, room, subject tags; validates no conflicting schedule blocks.
3. **ArchiveClassCommand : IRequest**
   - Checks dependent modules (assignments, gradebook) via `IClassReadinessService` before toggling `IsArchived`.
4. **ManageRosterCommand : IRequest<ClassRosterDto>**
   - Accepts lists of student ids to add/remove/update status plus seat numbers; returns updated roster snapshot.
5. **AssignInstructorCommand : IRequest**
   - Handles lead/co-teacher assignments ensuring single primary.
6. **UpdateClassWorkspaceSettingsCommand : IRequest**
   - Updates `WorkspaceSettings` (default tab, date range, highlighted student) ensuring invariants and raising `ClassWorkspaceSettingsUpdatedEvent` for cache invalidation.

### Queries

- **GetClassesDashboardQuery** returning paginated list with metrics (counts, next lesson, outstanding grading).
- **GetClassDetailQuery** providing roster, timetable, instructors, subject tags.
- **GetRosterTimelineQuery** exposing joins/leaves for audit purposes.
- **GetClassWorkspaceSnapshotQuery** aggregating lesson plans, assignments, live sessions, and resource library items per shared state.
- **GetClassAttendanceTabQuery** projecting attendance registers/history while delegating write operations to Attendance commands.
- **GetClassMarksTabQuery** composing gradebook grid data, weighting configuration, and recent grading alerts scoped to the selected class.

### Validation & Mapping

- FluentValidation rules for codes, schedule times.
- AutoMapper profile converting entities to DTOs (e.g., `ClassSummaryDto`, `ClassRosterStudentDto`).

---

## Infrastructure

- Update `ApplicationDbContext` to include `DbSet<Classroom>`, `DbSet<ClassMembership>`, `DbSet<ClassInstructor>`.
- Configure many-to-many relationships with composite keys and query filters for archived classes.
- Implement EF Core `Owned` configuration for `ScheduleBlock` collection (e.g., `builder.OwnsMany`) and `WorkspaceSettings` (`OwnsOne` with nested `WorkspaceDateRange`).
- Add indexes on `ClassCode`, `AcademicTermId`, `SubjectTagIds` (JSON index if using PostgreSQL array).
- Extend repository abstractions or `IClassroomRepository` for specialized queries (timetable projections).
- Ensure soft delete/archival flows update audit columns via interceptors.

---

## Web API (Minimal APIs)

- Create endpoint group `Classrooms` under `src/Web/Endpoints/Classrooms.cs`.
- Routes:
  - `POST /api/classrooms` → `CreateClassCommand`.
  - `PUT /api/classrooms/{id}` → `UpdateClassCommand`.
  - `POST /api/classrooms/{id}/archive` → `ArchiveClassCommand`.
  - `PUT /api/classrooms/{id}/roster` → `ManageRosterCommand`.
  - `PUT /api/classrooms/{id}/instructors` → `AssignInstructorCommand`.
  - `GET /api/classrooms` → `GetClassesDashboardQuery` with filtering.
  - `GET /api/classrooms/{id}` → `GetClassDetailQuery`.
  - `GET /api/classrooms/{id}/workspace` → `GetClassWorkspaceSnapshotQuery`.
  - `GET /api/classrooms/{id}/attendance-tab` → `GetClassAttendanceTabQuery`.
  - `GET /api/classrooms/{id}/marks-tab` → `GetClassMarksTabQuery`.
- Apply `[Authorize(Policy = Policies.RequiresTeacherRole)]` and log audit trails.
- Register NSwag exposure for generated client.

---

## Angular Frontend (DaisyUI)

Feature folder: `src/Web/ClientApp/src/app/features/class-management` with standalone components and signals.

- **ClassWorkspaceComponent**: wraps DaisyUI `tabs` (`Classwork`, `Attendance`, `Marks`) and owns shared signals: `selectedClassroomId`, `selectedAcademicTermId`, `selectedDateRange` (or week window), optional `selectedStudentId`, and `includeArchived`. The component propagates these into tab views and coordinates load/effect lifecycles via `ClassWorkspaceStore`.
- **ClassworkTabComponent**: surfaces lesson plans, assignments, live sessions, and resource library items using DaisyUI `card`, `table`, and `badge` components; includes quick actions to create or clone items through respective modules.
- **AttendanceTabComponent**: embeds attendance register UI (bulk status buttons, notes, alerts) reusing Attendance feature components, but bound to the shared state filters to ensure dates/students stay aligned with other tabs.
- **MarksTabComponent**: hosts the Gradebook grid and category weighting controls scoped to the selected class; enforces read-only states for roles lacking edit rights while still reflecting category summaries and recent grading alerts.
- **RosterTableComponent**, **ClassFormModalComponent**, **InstructorPickerComponent**, and **TimetableViewComponent** remain part of this feature for roster and configuration flows, surfaced through workspace-side panels.
- **ClassWorkspaceStore**: Angular signals-based store caching tab payloads, coordinating cross-tab alerts (e.g., outstanding submissions badge on `Marks`), and avoiding duplicate fetches when toggling tabs.

UX Notes:
- Show `badge badge-warning` when class archived; disable roster edit buttons.
- Provide import/export button hooking into future CSV integration (tooltip marking TODO).
- Responsive layout: on <lg breakpoints, pivot to stacked cards or stacked tabs with persistent filters.
- Surface shared filters (class, term, date, student) in a sticky header so context remains visible across tabs.

---

## Testing Strategy

- **Domain.UnitTests**: validate class creation invariants, instructor assignment, schedule block overlap detection, and workspace settings constraints (valid tab/date/student combinations).
- **Application.UnitTests**: command/query handler tests using in-memory context verifying roster updates, archival guards, and workspace/tab snapshot projections.
- **Infrastructure.IntegrationTests**: EF mapping tests for join table constraints, owned schedule blocks.
- **Web.AcceptanceTests**: API tests covering create/update roster flows, verifying permission enforcement.
- **Angular Tests**: component harness tests for roster table actions, tab rendering, and shared store signal updates ensuring context consistency across Classwork/Attendance/Marks.

---

## Implementation Checklist

1. Domain entities/value objects plus events.
2. Application commands/queries, validators, mappings.
3. DbContext updates, configurations, migrations.
4. Minimal API endpoint group + DI registrations (including workspace/tab snapshot routes).
5. Regenerate NSwag clients.
6. Scaffold Angular class workspace tabs, shared store, and supporting components.
7. Add unit/integration/Angular tests.
8. Run `dotnet test --filter "FullyQualifiedName!~AcceptanceTests"`, Angular lint/tests, and `dotnet format`.
9. Document route in README or navigation menu if exposed.

---

## References

- Existing `CalendarEvents` feature for Minimal API patterns.
- DaisyUI docs for `card`, `table`, `collapse` components.
- EF Core docs on owned collections and many-to-many relationships.
- Angular signals best practices (Angular v16+).
