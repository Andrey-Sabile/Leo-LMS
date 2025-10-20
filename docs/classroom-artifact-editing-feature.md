# Classroom Artifact Editing Feature Vertical Slice (Future Extension)

Documentation outlining the future classroom artifact editing capability for collaborative whiteboards and notes tied to class artifacts.

---

## Feature Goals & Scope

- Enable teachers and students to collaboratively edit classroom artifacts such as whiteboards, shared notes, and annotated documents within LeoLMS.
- Provide real-time collaboration with presence indicators, undo history, and version snapshots saved to the artifact repository.
- Integrate edited artifacts with lesson planning and learning content modules for reuse and review.
- Support exporting edited artifacts as PDFs/images and linking to assignments for reference.

Non-goals (initial future iteration):
- Offline editing.
- Third-party embedded editors (build native experience using in-house components or integrate single provider later).
- Comprehensive real-time sync across low bandwidth (optimize later).

---

## Domain Design

### Aggregates & Entities

- **CollaborativeArtifact (Aggregate Root)** – extends existing `Artifact` with collaborative metadata.
  - Properties: `Id`, `ArtifactId`, `CollaborationType` (Whiteboard, Notes, DocumentAnnotation), `ActiveSessionId`, `IsLocked`, `LastEditedOn`.
  - Behaviors: start collaboration session, lock/unlock artifact, finalize snapshot.
- **CollaborationSession** – tracks real-time editing sessions.
  - Properties: `Id`, `ArtifactId`, `StartedOn`, `EndedOn`, `HostUserId`, `ParticipantIds`, `StateSnapshot`.
- **ArtifactSnapshot** – version history capturing serialized whiteboard/note data.

### Value Objects

- **CollaborationState** storing serialized canvas/note structure.
- **ParticipantPresence** for real-time status (online, idle, offline).

### Invariants & Business Rules

- Only one active session per artifact; additional users join same session.
- Snapshots automatically saved at intervals and when session ends.
- Locks prevent destructive edits while final snapshot being processed.
- Access restricted to class members; teachers can revoke participant access.

### Domain Events

- `CollaborationSessionStartedEvent`, `CollaborationSnapshotCreatedEvent`, `CollaborationSessionEndedEvent`.

---

## Application Layer

Namespace `src/Application/CollaborativeArtifacts` (future).

### Commands

1. **StartCollaborationSessionCommand : IRequest<Guid>** – initializes session and returns connection info.
2. **EndCollaborationSessionCommand : IRequest** – finalizes session, triggers snapshot storage.
3. **SaveCollaborationSnapshotCommand : IRequest** – persists snapshot captured periodically.
4. **LockCollaborativeArtifactCommand : IRequest** – manually lock/unlock artifact.
5. **InviteParticipantCommand : IRequest** – optional for controlled access.

### Queries

- **GetCollaborativeArtifactDetailQuery** – returns current state, recent snapshots, participants.
- **GetCollaborationSessionsQuery** – history of sessions for auditing.

### Real-Time Integration

- Use SignalR (or WebSocket service) for real-time updates, presence, and conflict resolution.
- Implement operational transformation or CRDT-based engine for whiteboard/notes.

### Validation & Mapping

- Validate user permissions, ensure artifact supports collaboration type.
- Map state data to DTOs for clients.

---

## Infrastructure

- Extend artifact repository with support for collaborative metadata and snapshots (JSON storage).
- Add caches for active sessions and participant presence (Redis recommended).
- Persist real-time events for playback if required.
- Integrate background jobs for auto-saving and cleanup of stale sessions.

---

## Web API

- Endpoint group `CollaborativeArtifacts`.
- Endpoints: start/end session, fetch artifact state, save snapshot, manage participants.
- Real-time hub for collaboration updates.
- Authorization ensures only class members join sessions.

---

## Angular Frontend

Future feature in `features/collaborative-artifacts`.

- **CollaborativeWhiteboardComponent** – canvas-based editor using libraries (e.g., Fabric.js) integrated with SignalR for real-time updates.
- **CollaborativeNotesComponent** – rich text editor with live cursors.
- **SnapshotHistoryComponent** – list of snapshots with preview thumbnails.
- **ParticipantSidebarComponent** – shows active participants and presence.
- Signals store manages connection state, local operations, reconciliation.

UX Considerations:
- Provide toolbar with drawing/text tools using DaisyUI buttons.
- Show presence indicators (avatars with status) and active cursor highlights.
- Offer snapshot revert feature with confirmation dialog.

---

## Testing Strategy

- **Domain.UnitTests**: session lifecycle, locking rules, snapshot triggers.
- **Application.UnitTests**: command handlers for start/end/save, permission checks.
- **Infrastructure.IntegrationTests**: storage of snapshots, real-time hub integration (SignalR testing harness).
- **Web.AcceptanceTests**: API flows for session management.
- **Angular Tests**: component tests focusing on state reconciliation, toolbar interactions (likely using integration tests with mocked SignalR).
- **Performance Testing**: simulate concurrent users to validate real-time engine.

---

## Implementation Checklist

1. Extend artifact domain to support collaboration metadata.
2. Build application services/commands/queries and real-time handlers.
3. Update infrastructure (storage, caching, SignalR hubs).
4. API endpoints + real-time hub configuration.
5. Angular collaborative components and state management.
6. Automated/unit/integration tests + load tests.
7. Security review for real-time connections.
8. Update documentation/training when feature ready.

---

## References

- SignalR documentation for real-time collaboration.
- Operational transformation/CRDT pattern resources.
- Artifact repository feature documentation.
- DaisyUI button/icon components for toolbars.
