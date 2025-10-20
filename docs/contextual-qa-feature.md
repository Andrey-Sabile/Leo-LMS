# Contextual Q/A Entry Points Feature Vertical Slice

Documentation for implementing contextual Q/A entry points that connect lessons and assignments to relevant discussion threads and question prompts.

---

## Feature Goals & Scope

- Provide students with in-context access to forums/Q&A when viewing lessons or assignments, allowing quick question posting tied to specific content.
- Auto-tag questions with the originating lesson/assignment and surface teacher/peer responses in the same context.
- Display existing related Q/A threads inline to reduce duplicate questions.
- Notify teachers when new contextual questions arrive and link them to the relevant content view.
- Respect role permissions: students can ask, teachers respond/moderate, parents view read-only.

Non-goals:
- AI-generated answers (document future enhancements).
- Offline question composition.

---

## Domain Design

This feature reuses forums domain but introduces context linkage and preferences.

### Aggregates & Entities

- **ContextualQaPreference (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `UserId`, `ContextType` (Lesson, Assignment), `AutoSubscribe`, `ShowResolved`, `LastViewedOn`.
  - Behaviors: update preferences, toggle auto-subscribe.
- **ContextualQaLink** – association between content (lesson/assignment) and forum threads (if not already embedded in `DiscussionThread`). Could be value object if handled there.

### Value Objects

- **ContextReference** capturing module type, entity id, section reference (e.g., lesson segment id).
- **QaVisibilitySetting** controlling whether resolved questions remain visible inline.

### Invariants & Business Rules

- When question created via context entry, automatically link to corresponding thread/topic and ensure user subscribed if `AutoSubscribe`.
- Duplicate detection: if thread already exists for context, append as reply; else create new thread with context metadata.
- Teachers receive notifications via notification center; parents read-only.
- Inline view respects resolved/hidden status from forums feature.

### Domain Events

- `ContextualQuestionCreatedEvent`, `ContextualQuestionResolvedEvent`.

---

## Application Layer

Namespace `src/Application/ContextualQA`.

### Commands

1. **SetContextualQaPreferenceCommand : IRequest** – update user preferences.
2. **CreateContextualQuestionCommand : IRequest<Guid>** – wraps forum thread/post creation with context metadata.
3. **MarkContextualQuestionResolvedCommand : IRequest** – marks Q/A resolved, optionally linking accepted answer.
4. **SubscribeToContextCommand : IRequest** – manually subscribe user to context thread.

### Queries

- **GetContextualQaPreviewQuery** – returns top Q/A entries for given context.
- **GetContextualQaPreferencesQuery** – fetch user settings.

### Integration

- Use forums feature commands internally via mediator or service to create posts/threads with context flags.
- Notification center integration for question events.

### Validation & Mapping

- Validate user membership in class before posting.
- Map to DTOs for inline UI (question text, author, status, reply count).

---

## Infrastructure

- DbSet for `ContextualQaPreference` (if separate from forums).
- Extend forums persistence to store context metadata (e.g., additional columns on `DiscussionThread` for `ContextType`, `ContextId`).
- Ensure indexes on context fields for quick lookup.
- Provide caching of preview results for fast inline loading.

---

## Web API

- Endpoint group `ContextualQa` (or extend Forums endpoints with context parameters).
- Endpoints: get preview for context (`GET /api/contextual-qa/{contextType}/{contextId}`), create question, mark resolved, update preferences.
- Authorization tied to class membership; parents get read-only preview.

---

## Angular Frontend

Feature components integrated into lessons/assignments modules.

- **ContextualQaPanelComponent** – inline panel using DaisyUI `collapse` or `accordion` to show questions.
- **ContextualQaComposerComponent** – quick form for asking question with optional attachments.
- **ContextualQaListComponent** – displays existing Q/A with status badges (`badge-success` for resolved).
- **ContextualQaSettingsModal** – manage auto-subscribe preferences.
- Signals store per context handles loading, posting, and updates.

UX Considerations:
- Present inline panel collapsed by default with count badge; expand to show top replies.
- Indicate teacher/peer responses with avatars/badges.
- Provide button to open full forum thread when deeper discussion needed.

---

## Testing Strategy

- **Domain.UnitTests**: preference updates, auto-subscription logic.
- **Application.UnitTests**: command handlers for create question/resolved, context lookups.
- **Infrastructure.IntegrationTests**: verify forum context columns, indexing, caching.
- **Web.AcceptanceTests**: API flows for preview/post/resolved, permission checks.
- **Angular Tests**: component interactions for inline panel, composer validation, store updates.

---

## Implementation Checklist

1. Domain preferences/context metadata.
2. Application commands/queries leveraging forums.
3. Infrastructure updates (DB columns/indexes, caching).
4. API endpoints (or extended forums) + DI.
5. NSwag regeneration.
6. Angular inline components integrated into lessons/assignments.
7. Automated tests.
8. Run build/test/format commands.
9. Update user guides explaining contextual Q/A usage.

---

## References

- Forums feature documentation for thread/post handling.
- DaisyUI `collapse`, `badge`, `avatar` components.
- Notification center integration specs.
- Angular shared component patterns.
