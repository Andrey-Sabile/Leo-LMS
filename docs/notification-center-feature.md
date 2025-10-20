# Notification Center Feature Vertical Slice

Documentation for implementing the notification center focused on spotlighting submissions to grade, attendance anomalies, and forum activity for teachers.

---

## Feature Goals & Scope

- Provide a centralized notification center aggregating events from assignments, assessments, attendance, forums, announcements, and other modules.
- Highlight actionable items for teachers: submissions requiring grading, attendance anomalies, new forum posts, upcoming deadlines.
- Offer filtering by category, priority, and time window, along with role-specific views (teacher, admin).
- Support notification actions (mark read, snooze, resolve) and deep links into relevant modules.
- Deliver notifications via in-app center plus optional email digest.

Non-goals:
- Push/mobile notifications (document for future).
- Student notification UI (handled separately).
- Full audit log replacement (this is user-facing feed).

---

## Domain Design

### Aggregates & Entities

- **Notification (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `Category` (Submission, Attendance, Forum, Announcement, System), `Priority`, `Title`, `Body`, `Context` (JSON containing entity ids), `AudienceType`, `AudienceIds`, `ExpiresOn`, `IsRead`, `ReadOn`, `ResolvedOn`, `SnoozedUntil`.
  - Behaviors: mark read/unread, resolve, snooze, escalate priority.
- **NotificationRule** – optional entity for configurable triggers (e.g., thresholds for attendance anomalies).
- **NotificationDigestPreference** – user preferences for email digest frequency.

### Value Objects

- **NotificationContext** storing entity references and deep link info.
- **NotificationAction** enumerating allowed actions.

### Invariants & Business Rules

- Notifications targeted either to individuals or roles; ensure at least one target defined.
- Expired notifications removed from active feeds but stored for limited period.
- Snoozed notifications reappear when `SnoozedUntil` <= now.
- Resolved notifications retained with audit log.

### Domain Events

- `NotificationCreatedEvent`, `NotificationResolvedEvent`, `NotificationDigestRequestedEvent`.

---

## Application Layer

Namespace `src/Application/Notifications`.

### Commands

1. **CreateNotificationCommand : IRequest<Guid>** – invoked by other modules; validates payload and stores notification.
2. **MarkNotificationReadCommand : IRequest** – update read timestamp for user.
3. **ResolveNotificationCommand : IRequest** – mark resolved, optionally attach note.
4. **SnoozeNotificationCommand : IRequest** – set snooze period.
5. **ConfigureNotificationRulesCommand : IRequest** – adjust rule thresholds per class/user.
6. **ConfigureDigestPreferenceCommand : IRequest** – set email digest schedule.

### Queries

- **GetNotificationFeedQuery** – returns notifications for current user filtered by category/status.
- **GetNotificationCountsQuery** – aggregated counts for header badges.
- **GetNotificationRulesQuery** – fetch rule configurations for editing.

### Validation & Mapping

- Validators for payload structure, context references, snooze durations.
- Map to DTOs for feed display, counts, preferences.

### Integration

- Provide service interface `INotificationPublisher` to be used by modules (assignments, attendance, forums) to emit notifications via domain events/handlers.
- Implement digest generator that groups notifications and triggers email send.

---

## Infrastructure

- DbSets for notifications, rules, preferences.
- Indexes on `RecipientId`, `Category`, `IsRead`, `ExpiresOn`.
- Background job for digest generation and cleanup of expired notifications.
- Integration with email service for digests.
- Optional SignalR hub for real-time updates.

---

## Web API

- Endpoint group `Notifications`.
- Endpoints: fetch feed, fetch counts, mark read/unread, resolve, snooze, configure rules/preferences.
- Provide streaming endpoint (SignalR or SSE) for real-time push.
- Authorization ensures only owner can modify notifications; admins manage rules.

---

## Angular Frontend

Feature folder `features/notification-center`.

- **NotificationCenterComponent** – panel using DaisyUI `tabs` or `menu` for category filters; list with `alert` components.
- **NotificationItemComponent** – renders each notification with actions (CTA buttons).
- **NotificationSettingsComponent** – manage rules and digest preferences.
- **NotificationBellComponent** – header icon with badge/tooltip integrated globally.
- Signals store handles feed state, counts, WebSocket updates.

UX Considerations:
- Use `badge` to show counts; highlight high-priority items with `alert-error` or accent color.
- Provide quick action buttons inline (e.g., "Grade now", "Review attendance").
- Support keyboard navigation and accessible announce (ARIA live region).

---

## Testing Strategy

- **Domain.UnitTests**: verify read/snooze/resolve behaviors, rule evaluation.
- **Application.UnitTests**: command handler coverage for creating notifications, updating statuses, digest preferences.
- **Infrastructure.IntegrationTests**: persistence indexes, background jobs, email digest formatting.
- **Web.AcceptanceTests**: API tests for feed retrieval, mark read, rule configuration.
- **Angular Tests**: component tests for notification center interactions, store tests for live updates.

---

## Implementation Checklist

1. Domain entities/events/services.
2. Application commands/queries/validators.
3. Infrastructure persistence, scheduler, email integration.
4. API endpoints + SignalR (optional) wiring.
5. NSwag regeneration.
6. Angular components/stores/global integration.
7. Automated tests across layers.
8. Run build/test/format commands.
9. Update documentation/training for teachers.

---

## References

- Assignments/Attendance/Forums modules event contracts.
- DaisyUI `alert`, `badge`, `menu` components.
- SignalR integration examples.
- Accessibility guidelines for notification systems.
