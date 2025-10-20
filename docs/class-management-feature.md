# Class Management Feature Vertical Slice

Documentation for implementing the class management vertical slice that powers the teacher-facing class workspace, roster administration, and timetable context.

---

## Feature Goals & Scope

- Provide teachers with a multi-class dashboard summarizing key metrics (enrollment counts, next lesson, outstanding tasks).
- Enable roster management actions: add/remove students, assign co-teachers, and manage class metadata (subject tags, schedule blocks).
- Surface a timetable overview with class meeting times and room assignments.
- Support bulk roster imports/exports and soft-deletion for historical records.
- Ensure data flows align with the gradebook, assignments, and attendance modules without duplicating sources of truth.

Non-goals (document but defer):
- Automated timetable conflict resolution.
- Parent visibility into class setup details (handled via other features).
- Integration with SIS rosters (future extension).

---

## Domain Design

### Aggregates & Entities

- **Classroom (Aggregate Root)** – derives from `BaseAuditableEntity`.
  - Properties: `Id`, `ClassCode` (unique, human-friendly), `Title`, `SubjectTagIds`, `AcademicTermId`, `Room`, `SchedulePattern`, `IsArchived`, `ArchivedOn`.
  - Navigation: `ICollection<ClassMembership>` for students, `ICollection<ClassInstructor>` for teachers.
  - Behaviors: factory enforcing unique `ClassCode`, methods to update metadata, archive/restore, assign/remove members with validations, manage timetable blocks.
- **ClassMembership** – join entity between `Classroom` and `Student`.
  - Properties: `ClassroomId`, `StudentId`, `EnrollmentStatus` (Active, Pending, Withdrawn), `JoinedOn`, `LeftOn`, `SeatNumber`, `Notes`.
  - Behaviors: ensures `JoinedOn` required, prevents duplicate active enrollment.
- **ClassInstructor** – join entity between `Classroom` and `Teacher`.
  - Properties: `ClassroomId`, `TeacherId`, `Role` (Lead, CoTeacher, Assistant), `IsPrimary`.
  - Behaviors: guarantee exactly one primary instructor per class.
- **ScheduleBlock** (Value Object) – describes meeting pattern (day of week, start/end time, location, rotation code). Owned by `Classroom` and persisted as JSON/owned collection.

### Value Objects

- **SubjectTag** reference via existing lookup aggregate or value object containing `Code`, `DisplayName`, `ColorHex`.
- **SchedulePattern** encapsulating recurring schedule metadata (e.g., weekly vs. A/B rotation).

### Invariants & Business Rules

- `ClassCode` unique per academic term.
- At least one primary instructor required before publishing class.
- Class cannot be archived if active assignments/assessments exist without reassignment (integration hooks documented later).
- Student cannot be enrolled twice concurrently; withdrawing requires `LeftOn` timestamp.
- Roster edits emit domain events for downstream modules (gradebook, attendance) to sync.

### Domain Events

- `ClassroomCreatedEvent`, `ClassroomArchivedEvent`, `ClassRosterChangedEvent` with payload listing additions/removals.

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

### Queries

- **GetClassesDashboardQuery** returning paginated list with metrics (counts, next lesson, outstanding grading).
- **GetClassDetailQuery** providing roster, timetable, instructors, subject tags.
- **GetRosterTimelineQuery** exposing joins/leaves for audit purposes.

### Validation & Mapping

- FluentValidation rules for codes, schedule times.
- AutoMapper profile converting entities to DTOs (e.g., `ClassSummaryDto`, `ClassRosterStudentDto`).

---

## Infrastructure

- Update `ApplicationDbContext` to include `DbSet<Classroom>`, `DbSet<ClassMembership>`, `DbSet<ClassInstructor>`.
- Configure many-to-many relationships with composite keys and query filters for archived classes.
- Implement EF Core `Owned` configuration for `ScheduleBlock` collection (e.g., `builder.OwnsMany`).
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
- Apply `[Authorize(Policy = Policies.RequiresTeacherRole)]` and log audit trails.
- Register NSwag exposure for generated client.

---

## Angular Frontend (DaisyUI)

Feature folder: `src/Web/ClientApp/src/app/features/class-management` with standalone components and signals.

- **DashboardComponent**: displays cards for each class with subject badge, next lesson info; uses DaisyUI `card`, `badge`, `progress` components.
- **RosterTableComponent**: DaisyUI `table` with sticky header, inline actions for status change, seat assignment; uses `overflow-x-auto`.
- **ClassFormModalComponent**: reactive form with signals, including schedule block repeater using DaisyUI `accordion`/`collapse`.
- **InstructorPickerComponent**: autocomplete field with `AsyncPipe` + signals; ensures primary toggle.
- **TimetableViewComponent**: weekly grid leveraging CSS grid + DaisyUI `tabs` for multi-day rotations.
- State management via Angular signals; effect triggers API client calls (`ClassroomsClient`).
- Provide `ClassManagementStore` service encapsulating load, select, and mutate actions.

UX Notes:
- Show `badge badge-warning` when class archived; disable roster edit buttons.
- Provide import/export button hooking into future CSV integration (tooltip marking TODO).
- Responsive layout: on <lg breakpoints, pivot to stacked cards.

---

## Testing Strategy

- **Domain.UnitTests**: validate class creation invariants, instructor assignment, schedule block overlap detection.
- **Application.UnitTests**: command handler tests using in-memory context verifying roster updates, archival guards.
- **Infrastructure.IntegrationTests**: EF mapping tests for join table constraints, owned schedule blocks.
- **Web.AcceptanceTests**: API tests covering create/update roster flows, verifying permission enforcement.
- **Angular Tests**: component harness tests for roster table actions, timetable rendering; store tests verifying signal updates.

---

## Implementation Checklist

1. Domain entities/value objects plus events.
2. Application commands/queries, validators, mappings.
3. DbContext updates, configurations, migrations.
4. Minimal API endpoint group + DI registrations.
5. Regenerate NSwag clients.
6. Scaffold Angular feature components and state.
7. Add unit/integration/Angular tests.
8. Run `dotnet test --filter "FullyQualifiedName!~AcceptanceTests"`, Angular lint/tests, and `dotnet format`.
9. Document route in README or navigation menu if exposed.

---

## References

- Existing `CalendarEvents` feature for Minimal API patterns.
- DaisyUI docs for `card`, `table`, `collapse` components.
- EF Core docs on owned collections and many-to-many relationships.
- Angular signals best practices (Angular v16+).
