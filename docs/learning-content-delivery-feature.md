# Learning Content Delivery Feature Vertical Slice

Documentation for implementing the learning content delivery vertical slice that manages hosted resources, live session scheduling, and per-class libraries.

---

## Feature Goals & Scope

- Provide teachers a centralized resource library per class with support for files, videos, links, and embedded content.
- Schedule live sessions (virtual classroom links) with host platform metadata and access control.
- Track resource usage analytics (views/downloads) and expose summaries in dashboards.
- Allow tagging resources by topic, curriculum standard, and lesson alignment.
- Support version history and linkage to the Artifact Repository for storage consistency.

Non-goals:
- Native video transcoding/streaming (assume external provider integration).
- Offline downloads or DRM.
- Real-time collaborative document editing (future extension).

---

## Domain Design

### Aggregates & Entities

- **LearningResource (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `ClassroomId`, `Title`, `Description`, `ResourceType` (File, Link, Video, Embed), `ArtifactId`, `ExternalUrl`, `Duration`, `Tags`, `AssociatedLessonId`, `IsArchived`.
  - Behaviors: create from upload or external link, update metadata, archive/restore, track view counts.
- **LiveSession** – scheduled synchronous event.
  - Properties: `Id`, `ClassroomId`, `Title`, `StartDateTime`, `EndDateTime`, `MeetingProvider` (e.g., Teams, Zoom), `JoinUrl`, `HostInfo`, `RecordingArtifactId`, `Status` (Scheduled, InProgress, Completed, Cancelled).
  - Behaviors: schedule, reschedule, cancel, mark completed (link recording).
- **ResourceAccessLog** – track student access.
  - Properties: `Id`, `ResourceId`, `UserId`, `AccessedOn`, `Action` (View, Download, JoinSession), `DeviceInfo` (optional).

### Value Objects

- **ResourceTag** as value object linking to taxonomy.
- **ResourceVersion** capturing version number, artifact reference, created timestamp.
- **MeetingDetails** for live sessions (includes passcodes, dial-in numbers, timezone).

### Invariants & Business Rules

- Each resource must belong to a classroom or be shared with a global library (future optional flag).
- Files stored via artifact repository; `ArtifactId` required for `File` type.
- `LiveSession` times must not overlap for same classroom unless explicitly allowed; enforce minimal duration.
- Access logs should avoid duplicates for same user/action within configurable window (aggregation handled in query layer).
- Archiving resource should hide from student view but retain analytics history.

### Domain Events

- `LearningResourceCreatedEvent`, `LiveSessionScheduledEvent`, `LiveSessionCancelledEvent`, `ResourceViewedEvent` (for notifications/analytics pipelines).

---

## Application Layer

Namespace `src/Application/LearningContent`.

### Commands

1. **CreateResourceCommand : IRequest<Guid>** – handles metadata validation, artifact linking, optional associations to lessons.
2. **UpdateResourceCommand : IRequest** – change title, description, tags, version attachments.
3. **ArchiveResourceCommand : IRequest** – toggles `IsArchived` and cascades to search index.
4. **ScheduleLiveSessionCommand : IRequest<Guid>** – creates session, ensures no conflict, triggers calendar integration.
5. **UpdateLiveSessionCommand : IRequest** – adjust times or provider settings.
6. **RecordResourceAccessCommand : IRequest** – invoked from API when user accesses resource; stores log entry.

### Queries

- **GetClassResourceLibraryQuery** – returns paginated list per class with filters (type, tags, status).
- **GetLiveSessionsQuery** – upcoming/completed sessions with join info.
- **GetResourceDetailQuery** – load metadata, versions, usage metrics.
- **GetResourceAnalyticsQuery** – aggregated counts by user/resource.

### Validation & Mapping

- Validators for url formats, start/end times, artifact ids.
- DTO mapping for Angular (e.g., `LearningResourceDto`, `LiveSessionDto`).

---

## Infrastructure

- Extend DbContext with `DbSet<LearningResource>`, `DbSet<LiveSession>`, `DbSet<ResourceAccessLog>`.
- Configure indexes on `ClassroomId`, `ResourceType`, `Tags` (GIN index if JSON array).
- Provide service integration with storage provider via Artifact module.
- Implement background job hook (e.g., `ILiveSessionNotifier`) to send reminders.
- Add read model projection for analytics (materialized view or EF query type).

---

## Web API

- Endpoint group `LearningResources`.
- Endpoints: create/update/archive resource, download link retrieval, list resources, schedule/update/cancel sessions, record access (POST `/api/learning-resources/{id}/access`), fetch analytics.
- Authorization policies ensure teachers manage, students read.
- Response caching for library list where appropriate.

---

## Angular Frontend

Feature folder `features/learning-content`.

- **ResourceLibraryComponent** – DaisyUI `grid` of resource cards with filters chips.
- **ResourceDetailDrawerComponent** – slide-over showing metadata, versions, usage charts (using `daisyUI` `stats`).
- **LiveSessionListComponent** – table view with session status badges and join buttons.
- **ResourceFormModalComponent** – handles uploads & metadata entry; integrates artifact picker for existing files.
- Provide global search bar linking to this module.
- Signals store handles pagination, filter state, and analytics fetch.

UX Notes:
- Use type-specific iconography (e.g., `avatar` + `badge` for video vs link).
- Live sessions show countdown; disable join button until start window.
- Provide quick action to clone resource to other classes (ties into Quick Actions feature).

---

## Testing Strategy

- **Domain.UnitTests**: ensure schedule conflicts prevented, artifact validation enforced, versioning rules.
- **Application.UnitTests**: test command handlers for resource creation, live session updates, analytics queries.
- **Infrastructure.IntegrationTests**: EF mapping for owned tags/versions, concurrency tokens, log retention.
- **Web.AcceptanceTests**: API tests for scheduling and resource retrieval with permission boundaries.
- **Angular Tests**: component tests for filtering/responsive layout, service tests for store effects.

---

## Implementation Checklist

1. Domain models/events.
2. Application commands/queries/validators.
3. DbContext and configuration updates + migrations.
4. API endpoints and DI registration.
5. NSwag client regeneration.
6. Angular feature scaffolding, components, and services.
7. Tests across layers.
8. Run formatting/build/test commands.
9. Update documentation/navigation references.

---

## References

- Artifact Repository integration guide.
- DaisyUI `card`, `stats`, `badge` components.
- Angular CDK overlay for detail drawer.
- EF Core documentation on value conversions for tags arrays.
