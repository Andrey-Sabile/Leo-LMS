# Subject Forums & Q/A Feature Vertical Slice

Documentation for implementing the subject forums and Q/A vertical slice that delivers class-scoped discussions with teacher moderation and parent read-only access.

---

## Feature Goals & Scope

- Provide class-based discussion threads with support for topics (e.g., per lesson/assignment) and replies.
- Allow teachers to pin/highlight posts, mark answers, and moderate content (edit, hide, lock threads).
- Enable students to create posts/questions with rich text, attachments, and mentions.
- Offer parents read-only access to their child’s class forums with notification of teacher highlights.
- Integrate with notification center for new posts, replies, and teacher mentions.

Non-goals:
- Real-time chat (forums are asynchronous).
- Anonymous posting.
- External social media integration.

---

## Domain Design

### Aggregates & Entities

- **DiscussionThread (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `ClassroomId`, `TopicType` (General, Lesson, Assignment), `TopicReferenceId`, `Title`, `AuthorId`, `IsLocked`, `PinnedOn`, `HighlightPostId`.
  - Navigation: `ICollection<DiscussionPost>`.
  - Behaviors: create thread, lock/unlock, pin/unpin, mark highlight.
- **DiscussionPost** – individual message.
  - Properties: `Id`, `ThreadId`, `AuthorId`, `Body`, `BodyFormat` (Markdown/Plain), `ParentPostId`, `IsHidden`, `HiddenReason`, `AttachmentIds`, `IsAnswer`, `CreatedOn`.
  - Behaviors: edit, hide (moderation), mark answer, add attachments.
- **ThreadSubscription** – track user subscriptions/notifications.

### Value Objects

- **PostContent** ensuring sanitized HTML/Markdown.
- **Mention** list linking to user IDs.

### Invariants & Business Rules

- Threads scoped to a class; `TopicReferenceId` optional when tied to lesson/assignment.
- Only teachers can pin threads or mark highlight posts; students can mark accepted answer on their question if permitted.
- Hidden posts remain accessible to moderators with audit log.
- Parents have read-only access, no posting; enforcement via authorization.
- Attachments stored via artifact repository; ensure permission alignment.

### Domain Events

- `DiscussionThreadCreatedEvent`, `DiscussionPostCreatedEvent`, `DiscussionPostHiddenEvent`, `HighlightSetEvent`.

---

## Application Layer

Namespace `src/Application/Forums`.

### Commands

1. **CreateThreadCommand : IRequest<Guid>** – establishes thread with metadata, optional topic reference.
2. **CreatePostCommand : IRequest<Guid>** – adds post/reply, handles mentions, attachments.
3. **EditPostCommand : IRequest** – update body with version history.
4. **HidePostCommand : IRequest** – mark post hidden with reason, triggers notification.
5. **SetThreadPinCommand : IRequest** – pin/unpin thread.
6. **SetHighlightPostCommand : IRequest** – designate highlight/answer.
7. **SubscribeThreadCommand : IRequest** – manage user subscription preferences.

### Queries

- **GetThreadsForClassQuery** – list threads with pagination, filtering by topic.
- **GetThreadDetailQuery** – includes posts, author metadata, attachments.
- **GetUserForumSummaryQuery** – aggregated unread counts per class.

### Validation & Mapping

- Validators ensure body length, sanitized content, attachment count.
- DTO mapping for thread summary, post detail, subscription preferences.

---

## Infrastructure

- DbSets for threads, posts, subscriptions.
- Configure indexes on `ClassroomId`, `TopicType`, `AuthorId`.
- Implement full-text search support (e.g., PostgreSQL `tsvector`) for thread search.
- Integrate with notification system (teacher mentions, replies) and caching for unread counts.
- Soft delete/hide semantics using query filters.

---

## Web API

- Endpoint group `Forums`.
- Endpoints: create thread, create/edit/hide posts, pin thread, mark highlight, subscribe/unsubscribe, list threads, get thread detail, fetch user summary.
- Authorization policies: teacher/student posting rights; parent read-only (GET only), admin moderation rights.
- Rate limiting middleware to mitigate spam.

---

## Angular Frontend

Feature folder `features/forums`.

- **ForumListComponent** – displays threads with badges for type, unread counts, pinned indicator.
- **ThreadViewComponent** – nested replies UI using DaisyUI `chat` components or styled cards.
- **PostComposerComponent** – markdown editor with attachment picker (artifact integration).
- **ModerationPanelComponent** – teacher tools to hide, pin, highlight posts.
- **ParentViewBannerComponent** – indicates read-only mode for parent role.
- Signals-based store handles pagination, thread selection, unread state.

UX Considerations:
- Show pinned threads at top with DaisyUI `badge badge-primary`.
- Provide mention suggestions via typeahead.
- Display hidden posts collapsed with toggle for moderators.

---

## Testing Strategy

- **Domain.UnitTests**: enforce moderation rules, highlight logic, thread ownership.
- **Application.UnitTests**: command handlers for create/edit/hide, subscription flows.
- **Infrastructure.IntegrationTests**: verify full-text search configuration, query filters for hidden posts.
- **Web.AcceptanceTests**: API permission checks, thread list retrieval, parent restrictions.
- **Angular Tests**: component tests for thread view, composer validation, store for unread counts.

---

## Implementation Checklist

1. Domain entities/events.
2. Application commands/queries/validators.
3. DbContext configuration & migrations.
4. API endpoints + DI wiring.
5. Regenerate NSwag clients.
6. Angular components/stores/tests.
7. Execute automated tests & formatting.
8. Update documentation and onboarding tutorials.

---

## References

- DaisyUI `chat`, `badge`, `card` components.
- Angular markdown editor options.
- Notification center integration specs.
- Database search configuration guides.
