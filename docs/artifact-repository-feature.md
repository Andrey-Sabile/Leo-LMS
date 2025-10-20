# Artifact Repository Feature Vertical Slice

Documentation for implementing the artifact repository vertical slice providing class-linked storage for lesson materials, media, and documents with version history.

---

## Feature Goals & Scope

- Offer centralized storage for artifacts (documents, media, images) linked to classes, lessons, assignments, and announcements.
- Maintain version history, metadata, and access permissions for each artifact.
- Support upload, download, preview (where possible), and archival of artifacts.
- Provide tagging and search capabilities to quickly locate resources.
- Integrate with dependent features (Lesson Planning, Learning Content, Assignments) via APIs and shared identifiers.

Non-goals:
- Real-time collaborative editing.
- Large-scale video transcoding pipeline (assume external services if needed).
- End-user quota management (document future requirement).

---

## Domain Design

### Aggregates & Entities

- **Artifact (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `FriendlyName`, `FileName`, `ContentType`, `SizeBytes`, `StorageKey`, `OwnerId`, `ClassroomId` (optional), `Tags`, `Version`, `IsArchived`.
  - Navigation: `ICollection<ArtifactVersion>`, `ICollection<ArtifactLink>`.
  - Behaviors: upload new version, update metadata/tags, archive/restore.
- **ArtifactVersion** – stores version-specific metadata.
  - Properties: `Id`, `ArtifactId`, `VersionNumber`, `StorageKey`, `Checksum`, `CreatedOn`, `CreatedBy`.
- **ArtifactLink** – references usage context (Lesson, Assignment, Announcement) with `LinkedEntityType`, `LinkedEntityId`.
- **ArtifactAccessLog** – record user access for auditing.

### Value Objects

- **ArtifactTag** containing `Code`, `DisplayName`.
- **StorageLocation** capturing bucket/container info.
- **Checksum** to verify integrity.

### Invariants & Business Rules

- Artifacts must have at least one version; uploading new version increments `VersionNumber` and preserves previous versions.
- Deleting artifact uses soft delete; prevent removal if actively referenced unless forced with audit.
- Access logs generated when downloads or previews occur; maintain retention policy.
- Permissions: owners plus class instructors have manage rights; students read-only via linked contexts.
- File size/type validation enforced per policy.

### Domain Events

- `ArtifactUploadedEvent`, `ArtifactVersionCreatedEvent`, `ArtifactArchivedEvent`, `ArtifactAccessedEvent`.

---

## Application Layer

Namespace `src/Application/Artifacts`.

### Commands

1. **UploadArtifactCommand : IRequest<Guid>** – handles upload metadata, storage interaction, initial link.
2. **UploadArtifactVersionCommand : IRequest** – adds new version to existing artifact.
3. **UpdateArtifactMetadataCommand : IRequest** – rename, retag, assign class.
4. **ArchiveArtifactCommand : IRequest** – soft-delete and remove from search index.
5. **LinkArtifactCommand : IRequest** – associate artifact with domain entity (lesson, assignment, etc.).
6. **RecordArtifactAccessCommand : IRequest** – log download/preview events.

### Queries

- **GetArtifactLibraryQuery** – search/filter artifacts by class, tags, owner.
- **GetArtifactDetailQuery** – metadata, versions, links.
- **GetArtifactUsageQuery** – where artifact is referenced.

### Validation & Mapping

- Validators for file size, allowed content types, tag lengths.
- DTO mapping to expose artifact data to other modules and Angular client.

---

## Infrastructure

- Integrate with storage provider (Azure Blob, S3, local) via `IArtifactStorageService` abstraction.
- DbSets for artifacts, versions, links, access logs.
- Indexes on `ClassroomId`, `OwnerId`, `Tags` for search.
- Implement background job for virus scanning or asynchronous processing (if required).
- Provide pre-signed URL generation service for uploads/downloads.

---

## Web API

- Endpoint group `Artifacts`.
- Endpoints: upload, upload version, update metadata, archive, list/search, detail, usage, generate download link, record access.
- Use streaming endpoints and support chunked uploads for large files.
- Authorization ensures only permitted roles upload/manage; read access based on linked entity membership.

---

## Angular Frontend

Feature folder `features/artifacts`.

- **ArtifactLibraryComponent** – table/grid with filtering, sorting, tag chips.
- **ArtifactUploadComponent** – modal with drag-and-drop upload, progress bar.
- **ArtifactDetailDrawerComponent** – show versions, activity, usage links.
- **ArtifactLinkerComponent** – re-usable component to attach artifact to contexts (used across modules).
- Signals store handles search state, selection, upload progress.

UX Considerations:
- Display file type icons; show `badge` for archived state.
- Provide inline actions (download, copy link) with DaisyUI `dropdown`.
- Show upload progress via `progress` component; handle chunked resume (document future).

---

## Testing Strategy

- **Domain.UnitTests**: version increment logic, archive rules, permission checks (via domain services).
- **Application.UnitTests**: command handler coverage for upload/version/metadata updates, linking.
- **Infrastructure.IntegrationTests**: storage provider integration tests using emulator, EF mapping for versions/links.
- **Web.AcceptanceTests**: API tests for upload/download flows, authorization.
- **Angular Tests**: component tests for library filtering, upload progress; service tests for store.

---

## Implementation Checklist

1. Domain entities/value objects/events.
2. Application commands/queries/validators.
3. Storage abstraction + DbContext configuration/migrations.
4. API endpoints + DI registration.
5. NSwag regeneration for Angular client.
6. Angular components/stores/tests.
7. Automated tests across layers.
8. Run build/test/format commands.
9. Document storage quotas/policies.

---

## References

- Storage provider SDK documentation.
- DaisyUI `table`, `modal`, `progress`, `dropdown` components.
- Angular CDK drag/drop for upload interactions.
- Security best practices for pre-signed URLs.
