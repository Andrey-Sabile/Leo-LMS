# Submission Locker Feature Vertical Slice

Documentation for implementing the student submission locker that displays draft, submitted, and graded work across classes.

---

## Feature Goals & Scope

- Provide students with a consolidated view of their assignment and assessment submissions categorized by status (Draft, Submitted, Graded, Returned).
- Allow quick actions to continue drafts, view feedback, resubmit (if allowed), and download graded artifacts.
- Surface due dates, late indicators, and teacher comments within the locker.
- Integrate with notifications and gradebook to ensure status synchronization.
- Support filtering by class, status, and timeframe.

Non-goals:
- Teacher management of submissions (handled in assignments/assessments modules).
- Offline submission support.
- Parent-facing view (covered by parent digest).

---

## Domain Design

The locker primarily consumes data from assignments/assessments; domain focus lies in personalization and caching.

### Aggregates & Entities

- **SubmissionLockerPreference (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `StudentId`, `DefaultStatusFilter`, `SortOption`, `ShowArchived`, `LastSyncedOn`.
  - Behaviors: update preferences, toggle archived visibility, record sync timestamp.
- **SubmissionLockerSnapshot** – optional entity caching aggregated data for faster load.

### Value Objects

- **SubmissionLockerItem** capturing `SubmissionId`, `AssignmentId`, `Title`, `ClassroomId`, `Status`, `DueDate`, `SubmittedOn`, `Score`, `FeedbackAvailable`, `ActionLinks`.

### Invariants & Business Rules

- Preferences unique per student.
- Locker items should reflect latest assignment/assessment data; scheduled sync or event-driven updates maintain snapshot.
- Late flag shown when submission occurs after due date without exception.
- Resubmission allowed only if assignment permits; action link disabled otherwise.

### Domain Events

- `SubmissionLockerSyncedEvent`, `SubmissionLockerPreferenceUpdatedEvent`.

---

## Application Layer

Namespace `src/Application/SubmissionLocker`.

### Commands

1. **UpdateLockerPreferencesCommand : IRequest** – adjust default filters/sort.
2. **RefreshLockerSnapshotCommand : IRequest** – rebuild locker data for student (triggered by events from assignments/assessments).
3. **DismissLockerItemCommand : IRequest** – optionally hide informational items.

### Queries

- **GetSubmissionLockerQuery** – returns items grouped by status with pagination.
- **GetLockerPreferencesQuery** – returns stored preferences.

### Integration

- Event handlers listening to `SubmissionCreatedEvent`, `SubmissionGradedEvent` from assignments/assessments to trigger snapshot refresh.
- Optional background job to refresh stale snapshots nightly.

### Validation & Mapping

- Validate filter options belong to enumerations.
- Map aggregated data to DTOs for UI.

---

## Infrastructure

- DbSets for preferences and optional snapshots (persisted as JSON or relational).
- Implement aggregator service combining assignment/assessment submissions.
- Caching strategy for quick retrieval.
- Ensure data respects student privacy/permissions.

---

## Web API

- Endpoint group `SubmissionLocker`.
- Endpoints: `GET /api/student/submission-locker`, `GET/PUT /api/student/submission-locker/preferences`, optional `POST /api/student/submission-locker/refresh` (manual refresh), `POST /api/student/submission-locker/{itemId}/dismiss`.
- Authorization ensures only the student (and parent via delegated read) can access.

---

## Angular Frontend

Feature folder `features/submission-locker`.

- **SubmissionLockerComponent** – segmented view using DaisyUI `tabs` or `collapse` for status categories.
- **SubmissionLockerItemComponent** – card/table row showing assignment title, due date, status, actions.
- **LockerFilterBarComponent** – filter chips for class/status, search box.
- **LockerPreferencesModalComponent** – manage default settings.
- Signals store handles data load, filter application, and interactions with API.

UX Considerations:
- Use status-specific `badge` colors; highlight overdue items.
- Provide CTA buttons: `View details`, `Continue draft`, `View feedback`.
- Show sync indicator and manual refresh button.

---

## Testing Strategy

- **Domain.UnitTests**: preference updates, dismissal logic.
- **Application.UnitTests**: snapshot refresh command, query aggregator using mocks.
- **Infrastructure.IntegrationTests**: aggregator queries, event-driven refresh.
- **Web.AcceptanceTests**: API responses, authorization.
- **Angular Tests**: component rendering for statuses, store filter logic.

---

## Implementation Checklist

1. Domain preference entity/events.
2. Application commands/queries/aggregator.
3. Infrastructure persistence, caching, event handlers.
4. API endpoints & DI.
5. NSwag regeneration.
6. Angular components/stores/tests.
7. Automated tests + formatting.
8. Update student documentation/support materials.

---

## References

- Assignments & Assessment modules events.
- DaisyUI `tabs`, `card`, `badge` components.
- Angular signals best practices.
- Caching strategies for aggregated views.
