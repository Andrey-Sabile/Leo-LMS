# Attendance Feature Vertical Slice

Documentation for implementing the attendance vertical slice handling daily roll call, bulk status updates, and attendance history with notes.

---

## Feature Goals & Scope

- Allow teachers to take daily attendance per class with quick status toggles (Present, Absent, Tardy, Excused).
- Provide bulk operations (mark entire class present, copy previous day) and note-taking for exceptions.
- Maintain attendance history per student with filtering by date range and status.
- Surface anomalies (multiple absences, tardiness streaks) in notification center.
- Integrate with gradebook/reporting for attendance metrics and with parent digest for alerts.

Non-goals:
- Automated attendance via hardware (badges, RFID) – document integration points only.
- District-level absence reporting formats (future requirement).

---

## Domain Design

### Aggregates & Entities

- **AttendanceRegister (Aggregate Root)** – per class/day entity inheriting `BaseAuditableEntity`.
  - Properties: `Id`, `ClassroomId`, `Date`, `Status` (Open, Submitted, Locked), `TakenByUserId`, `SubmittedOn`.
  - Navigation: `ICollection<AttendanceEntry>`.
  - Behaviors: initialize register, update entries, submit, lock/unlock.
- **AttendanceEntry** – per student record.
  - Properties: `Id`, `RegisterId`, `StudentId`, `AttendanceStatus` (enum), `Note`, `RecordedOn`, `OverrideReason`.
  - Behaviors: change status, append note, track overrides with audit.
- **AttendanceAlert** – optional entity storing rule-triggered alerts (e.g., 3 absences).

### Value Objects

- **AttendanceStatus** enumeration with allowed transitions (e.g., cannot revert `Locked`).
- **AttendanceNote** value object enforcing length and sanitization.

### Invariants & Business Rules

- Register unique per `ClassroomId` + `Date`.
- Only open registers allow edits; submitting sets `Status=Submitted`, locking transitions to `Locked` after admin verification.
- Bulk update operations respect existing excused statuses unless override flag provided.
- Attendance alerts triggered when thresholds exceeded; events emitted for notifications.

### Domain Events

- `AttendanceRegisterCreatedEvent`, `AttendanceSubmittedEvent`, `AttendanceStatusChangedEvent`, `AttendanceAlertTriggeredEvent`.

---

## Application Layer

Namespace `src/Application/Attendance`.

### Commands

1. **CreateOrOpenRegisterCommand : IRequest<int>** – ensures register exists for class/date.
2. **UpdateAttendanceEntriesCommand : IRequest** – bulk updates statuses/notes.
3. **SubmitAttendanceCommand : IRequest** – finalizes register, triggers notifications.
4. **LockRegisterCommand : IRequest** – admin-only, prevents further changes.
5. **AcknowledgeAttendanceAlertCommand : IRequest** – mark alerts resolved.

### Queries

- **GetAttendanceForClassQuery** – returns registers within date range, including summary counts.
- **GetAttendanceHistoryForStudentQuery** – chronological history with notes and statuses.
- **GetAttendanceAlertsQuery** – outstanding anomalies for teacher/admin dashboards.

### Validation & Mapping

- Validators for status transitions, note length, date constraints.
- DTO mapping for registers, entries, alerts.

---

## Infrastructure

- DbSets for registers, entries, alerts.
- Unique index on `(ClassroomId, Date)`.
- Query filters excluding locked records when editing.
- Integration with notification service to queue alerts (email, in-app).
- Background job to auto-create registers based on timetable schedule.

---

## Web API

- Endpoint group `Attendance`.
- Endpoints: open register, update entries, submit, lock, list registers, fetch student history, manage alerts.
- Authorization: teachers for their classes, admins for reporting.
- Provide SSE or SignalR channel for real-time updates if multiple teachers editing.

---

## Angular Frontend

Feature folder `features/attendance`.

- **AttendanceBoardComponent** – grid of students with status buttons (DaisyUI `btn-group`).
- **AttendanceBulkActionsComponent** – toggles for mark all present, copy previous day, apply note.
- **AttendanceHistoryComponent** – timeline/table for student history with filters.
- **AlertsPanelComponent** – list of triggered alerts with acknowledge buttons.
- Signals store maintains current register state, statuses, and syncs with API.

UX Considerations:
- Use color-coded buttons/badges for statuses (present=success, absent=error, tardy=warning).
- Auto-save feedback indicator when entry updated.
- Provide offline-safe caching (document future improvement) – for now warn if network lost.

---

## Testing Strategy

- **Domain.UnitTests**: register uniqueness, status transitions, alert thresholds.
- **Application.UnitTests**: command handlers for bulk update, submit, lock, alert acknowledgement.
- **Infrastructure.IntegrationTests**: mapping validations, background job register creation.
- **Web.AcceptanceTests**: API flows for create/update/submit, permission enforcement.
- **Angular Tests**: component tests for board interactions, store tests for optimistic updates.

---

## Implementation Checklist

1. Domain entities/events.
2. Application commands/queries/validators.
3. DbContext configuration, migration, job scheduler integration.
4. API endpoints + NSwag client regenerate.
5. Angular components/state.
6. Automated tests.
7. Execute build/test/format commands.
8. Update documentation/teacher onboarding material.

---

## References

- Class Management for timetable data.
- DaisyUI `btn-group`, `badge` components.
- Angular CDK for virtual scrolling if class sizes large.
- Notifications service interfaces for alert dispatch.
