# Student Timeline Feature Vertical Slice

Documentation for implementing the student timeline feature that aggregates upcoming lessons, assignments, and exams across classes into a unified view.

---

## Feature Goals & Scope

- Provide students with a chronological timeline of upcoming lessons, assignments, exams, and key events across all enrolled classes.
- Include status indicators (due soon, overdue, completed) and quick actions (view details, submit work, join session).
- Offer filters by class, item type, and date range, plus grouping by day/week.
- Integrate with notifications to highlight urgent items and with calendar exports (optional ICS download).
- Support responsive design for laptop-focused web app with accessible navigation.

Non-goals:
- Mobile-native calendar app.
- Automatic scheduling changes (read-only display).
- Parental view (handled via Parent Digest feature).

---

## Domain Design

The timeline is a read model aggregating data from multiple modules; domain persistence focuses on personalization settings.

### Aggregates & Entities

- **StudentTimelinePreference (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `StudentId`, `DefaultFilters` (classes, item types), `Grouping` (Day, Week), `CollapsedSections`, `LastViewedOn`.
  - Behaviors: update filters, reset defaults, record view timestamp.
- Timeline items generated via projection service combining assignments, assessments, lessons, live sessions, announcements.

### Value Objects

- **TimelineFilter** storing selections.
- **TimelineItem** value object with `Id`, `ItemType`, `Title`, `StartDate`, `DueDate`, `Status`, `ClassroomId`, `ActionLink`.

### Invariants & Business Rules

- Preferences unique per student; defaults when none configured.
- Timeline items include only published/active content respecting availability windows.
- Overdue items flagged when `DueDate` < current date and not completed.
- Completed/graded items optional to hide; preference controls visibility.

### Domain Events

- `TimelinePreferenceUpdatedEvent`, `TimelineItemCompletedEvent` (emitted when student completes action, used to update timeline view).

---

## Application Layer

Namespace `src/Application/StudentTimeline`.

### Commands

1. **UpdateTimelinePreferencesCommand : IRequest** – adjusts default filters/grouping.
2. **RecordTimelineViewCommand : IRequest** – update last viewed timestamp for analytics.
3. **DismissTimelineItemCommand : IRequest** – hides optional items (e.g., informational events).

### Queries

- **GetStudentTimelineQuery** – orchestrates data retrieval across modules, returns ordered timeline items.
- **GetTimelinePreferencesQuery** – returns saved preferences.

### Services

- `ITimelineAggregator` service to gather data from assignments, lessons, assessments, announcements, live sessions.
- Incorporate caching per student per time window.

### Validation & Mapping

- Validate filter inputs (class membership) and grouping values.
- Map aggregated projections to DTOs consumed by Angular timeline component.

---

## Infrastructure

- DbSet for `StudentTimelinePreference`.
- Implement aggregator using repositories or direct queries; consider database view for upcoming items.
- Caching layer (e.g., memory cache) to reduce repeated cross-module queries.
- Optional ICS export generator for calendar integrations.

---

## Web API

- Endpoint group `StudentTimeline`.
- Endpoints: `GET /api/student/timeline`, `GET /api/student/timeline/preferences`, `PUT /api/student/timeline/preferences`, `POST /api/student/timeline/{itemId}/dismiss`.
- Ensure endpoints enforce student identity; allow parents read-only via delegated access (future extension).

---

## Angular Frontend

Feature folder `features/student-timeline`.

- **StudentTimelineComponent** – timeline view using DaisyUI `steps` or custom timeline layout with vertical line.
- **TimelineFilterBarComponent** – filter chips, dropdowns for class/item type, date range.
- **TimelineItemComponent** – cards with CTA buttons (submit, view lesson, join session) and status badges.
- **TimelinePreferencesModalComponent** – manage default settings.
- Signals store fetches timeline data, handles filters/prefs, manages dismissed items.

UX Considerations:
- Display due soon items with `badge badge-warning`, overdue with `badge badge-error`.
- Provide sticky header for filters.
- Support keyboard navigation (arrow keys to move across timeline items).

---

## Testing Strategy

- **Domain.UnitTests**: preference updates, dismissal behavior.
- **Application.UnitTests**: aggregator service tests (using mocks), preference commands.
- **Infrastructure.IntegrationTests**: verify aggregator queries, caching invalidation.
- **Web.AcceptanceTests**: API responses for timeline, permission checks.
- **Angular Tests**: component tests for timeline rendering, filter interactions, store logic.

---

## Implementation Checklist

1. Domain preference entity/value objects.
2. Application commands/queries/aggregator service.
3. Infrastructure persistence and caching.
4. API endpoints & DI wiring.
5. NSwag regeneration.
6. Angular components/stores/tests.
7. Automated testing & formatting.
8. Update student onboarding documentation.

---

## References

- Assignments, Lesson Planning, Assessment modules for data sources.
- DaisyUI timeline or `steps` component styling.
- Angular CDK virtual scroll (optional) for long timelines.
- Calendar export best practices (ICS generation).
