# Announcements Feature Vertical Slice

Documentation for implementing the announcements vertical slice enabling schoolwide and class-level communications with acknowledgment tracking.

---

## Feature Goals & Scope

- Allow admins and teachers to compose announcements targeted at schoolwide, grade-level, or class audiences.
- Support rich content (formatted text, attachments via artifact repository) and scheduling for future send.
- Provide acknowledgment tracking (require confirmation from recipients) and summary metrics.
- Deliver notifications via in-app feeds, email digests, and optional push integrations.
- Maintain delivery history and allow edits or cancellation for scheduled announcements.

Non-goals:
- SMS delivery (document integration later).
- Translation automation (leverage locale switcher manually for now).
- Comment threads (handled by forums feature).

---

## Domain Design

### Aggregates & Entities

- **Announcement (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `Title`, `Body`, `AudienceType` (Schoolwide, GradeLevel, Class, CustomGroup), `AudienceFilters`, `PublishOn`, `Expiration`, `RequiresAcknowledgment`, `Status` (Draft, Scheduled, Published, Cancelled).
  - Navigation: `ICollection<AnnouncementAttachment>`, `ICollection<AnnouncementDelivery>`.
  - Behaviors: schedule publication, publish immediately, cancel, update content while draft.
- **AnnouncementDelivery** – tracks per-user delivery state.
  - Properties: `Id`, `AnnouncementId`, `RecipientId`, `DeliveredOn`, `AcknowledgedOn`, `DeliveryChannel` (InApp, Email, Push).
- **AnnouncementAttachment** – artifact references.
- **AudienceSegment** – optional entity representing saved targeting criteria.

### Value Objects

- **AudienceFilter** capturing grade levels, classes, roles.
- **AnnouncementStatus** controlling workflow transitions.
- **AcknowledgmentState** enumerating `Pending`, `Acknowledged`, `Declined` (if applicable).

### Invariants & Business Rules

- `PublishOn` must be >= current time for scheduled announcements.
- Schoolwide announcements must be authored by admin role; class-level can be teacher.
- Once published, only `Expiration` or attachments may be updated (content edits require new announcement or version history).
- Acknowledgment required announcements record responses; non-response triggers reminder after configured interval.
- Expired announcements hidden from default listings but accessible in history.

### Domain Events

- `AnnouncementPublishedEvent`, `AnnouncementAcknowledgedEvent`, `AnnouncementReminderDueEvent`.

---

## Application Layer

Namespace `src/Application/Announcements`.

### Commands

1. **CreateAnnouncementCommand : IRequest<Guid>** – create draft with targeting and optional schedule.
2. **UpdateAnnouncementCommand : IRequest** – modify draft, attachments, schedule.
3. **PublishAnnouncementCommand : IRequest** – set status to published, enqueue deliveries.
4. **CancelAnnouncementCommand : IRequest** – cancel future scheduled announcement.
5. **RecordAcknowledgmentCommand : IRequest** – mark recipient acknowledgment.
6. **SendAcknowledgmentReminderCommand : IRequest** – triggered by scheduler for pending recipients.

### Queries

- **GetAnnouncementsFeedQuery** – returns announcements relevant to current user with filter options.
- **GetAnnouncementDetailQuery** – includes attachments and delivery metrics.
- **GetAnnouncementRecipientsQuery** – for admin view of acknowledgment progress.

### Validation & Mapping

- Validators for schedule times, required fields by audience type.
- Mapping to DTOs for frontend feed and admin dashboards.

---

## Infrastructure

- DbSets for announcements, deliveries, attachments, audience segments.
- Indexes on `AudienceType`, `PublishOn`, `RecipientId` for efficient filtering.
- Background job scheduler to publish scheduled announcements and dispatch reminders.
- Integration with email/push providers (service abstraction) and in-app notification service.
- Soft delete for attachments handled by artifact repository.

---

## Web API

- Endpoint group `Announcements`.
- Routes: create/update/publish/cancel, list feed, detail view, record acknowledgment, get delivery metrics, schedule reminders.
- Authorization policies per role (admin vs teacher vs student read-only).
- Response caching for public feed segments.

---

## Angular Frontend

Feature folder `features/announcements`.

- **AnnouncementComposerComponent** – rich text editor (Markdown or limited toolbar) with schedule picker and audience chips.
- **AnnouncementListComponent** – feed using DaisyUI `card` components with status badges.
- **AnnouncementDetailDrawerComponent** – shows attachments, acknowledgment stats.
- **AcknowledgmentPanelComponent** – for users to confirm receipt; includes reminder indicator.
- Signals-based store manages feed pagination, filters, composer state.

UX Notes:
- Display schedule status with `badge` (Scheduled, Live, Expired).
- Provide quick filters for My Classes, Schoolwide, Requires Ack.
- Show acknowledgment progress bar (DaisyUI `progress`).

---

## Testing Strategy

- **Domain.UnitTests**: workflow transitions, audience validation, acknowledgment recording.
- **Application.UnitTests**: command handlers for publish/cancel/reminder flows, feed queries.
- **Infrastructure.IntegrationTests**: EF configuration, scheduled job execution, delivery logging.
- **Web.AcceptanceTests**: ensure API enforces permissions and returns correct feed data.
- **Angular Tests**: component tests for composer validation, list filtering, acknowledgment interactions.

---

## Implementation Checklist

1. Domain entities/value objects/events.
2. Application commands/queries/validators.
3. DbContext and configuration updates; scheduler integration.
4. API endpoints and DI wiring.
5. Regenerate NSwag clients.
6. Angular components/stores/tests.
7. Execute automated tests & formatting.
8. Update documentation/onboarding materials.

---

## References

- Notification center integration spec.
- DaisyUI `card`, `badge`, `progress` components.
- Markdown editor selection (e.g., ngx-markdown) guidelines.
- Scheduler service (Hangfire/Cron) usage patterns.
