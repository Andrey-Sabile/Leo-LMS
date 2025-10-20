# Assignments & Submissions Feature Vertical Slice

Documentation for implementing the assignments and submissions vertical slice that covers assignment authoring, rubric-based evaluation, and student submission workflows.

---

## Feature Goals & Scope

- Enable teachers to create assignments with instructions, due dates, grading criteria, and optional rubrics.
- Provide students with submission capabilities (file upload, text entry, embedded tools) and status tracking (Draft, Submitted, Resubmitted).
- Offer teachers an inline review workspace supporting annotations, rubric scoring, and feedback release.
- Track submission statuses, due date exceptions, and late penalties.
- Integrate with gradebook for score syncing and with notification center for alerts.

Non-goals:
- Peer review workflows (document for future).
- Automated plagiarism detection.
- Offline submission handling.

---

## Domain Design

### Aggregates & Entities

- **Assignment (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `ClassroomId`, `Title`, `Description`, `DueDate`, `AvailableDate`, `CloseDate`, `MaxScore`, `SubmissionType` (File, Text, Link, External), `AllowResubmissions`, `RubricId`, `IsPublished`.
  - Navigation: `ICollection<AssignmentSection>`, `ICollection<AssignmentException>`, `ICollection<AssignmentArtifact>`.
  - Behaviors: publish/unpublish, update details, duplicate, link to lessons.
- **AssignmentRubric** – hierarchical rubric with criteria and levels.
  - Properties: `Id`, `Name`, `Criteria` (value object collection), `TotalPoints`, `IsShared`.
- **StudentSubmission** – per student attempt.
  - Properties: `Id`, `AssignmentId`, `StudentId`, `SubmittedOn`, `Status`, `Score`, `Feedback`, `RubricScores`, `AttemptNumber`, `LatePenaltyApplied`, `ReviewedByTeacherId`.
- **SubmissionArtifact** – references upload(s) or embedded content (artifact ids, urls).
- **AssignmentException** – records extension or modified due date per student.

### Value Objects

- **RubricCriterion** with `Descriptor`, `Weight`, `Levels`.
- **SubmissionStatus** enumeration controlling transitions.
- **DueDatePolicy** capturing grace periods and penalty percentages.

### Invariants & Business Rules

- Assignment must be published before students can submit.
- `DueDate` must be after `AvailableDate`; `CloseDate` optional but if set, >= `DueDate`.
- Rubric total weight equals `MaxScore` when attached.
- Students cannot submit after `CloseDate` unless exception exists.
- Resubmissions track attempt number and retain history; gradebook sync uses latest graded attempt.
- Teacher feedback release optionally delayed until manually triggered.

### Domain Events

- `AssignmentPublishedEvent`, `SubmissionCreatedEvent`, `SubmissionGradedEvent`, `AssignmentDeadlineReminderEvent`.

---

## Application Layer

Namespace `src/Application/Assignments`.

### Commands

1. **CreateAssignmentCommand : IRequest<int>** – sets up assignment metadata, rubric linkage, initial publication status.
2. **UpdateAssignmentCommand : IRequest** – adjust instructions, due dates, attachments, sections.
3. **PublishAssignmentCommand : IRequest** – toggles `IsPublished`, triggers notifications.
4. **CreateSubmissionCommand : IRequest<Guid>** – invoked by student, handles artifact uploads, initial status Draft/Submitted.
5. **UpdateSubmissionCommand : IRequest** – supports resubmission flow with `AttemptNumber` increment.
6. **GradeSubmissionCommand : IRequest** – applies rubric scores, calculates total, syncs to gradebook via `IGradebookSyncService`.
7. **ApplyAssignmentExceptionCommand : IRequest** – set or remove student-specific due dates.

### Queries

- **GetAssignmentsForClassQuery** – list assignments with status, due dates, submission counts.
- **GetAssignmentDetailQuery** – includes sections, rubric, attachments, exceptions.
- **GetSubmissionDetailQuery** – returns attempt history, feedback, artifacts.
- **GetSubmissionQueueQuery** – for teacher grading backlog with filters.

### Validation & Mapping

- FluentValidation for date sequencing, `MaxScore` > 0, rubric integrity.
- AutoMapper DTOs for assignments, submissions, rubrics.

---

## Infrastructure

- Add DbSets for assignments, rubrics, submissions, exceptions.
- Configure owned types for rubric criteria and scoring (EF Core complex types).
- Ensure concurrency tokens on submissions to prevent double grading.
- Integrate with artifact repository for submission uploads.
- Background job scheduling for due date reminders (`IJobScheduler`).

---

## Web API

- Endpoint group `Assignments`.
- Routes: create/update/publish assignments, list class assignments, manage exceptions, download submissions, create/grade submissions, submission queue retrieval.
- Student/teacher-specific authorization policies.
- Provide streaming endpoints for large file download (proxy to artifact service).

---

## Angular Frontend

Feature folder `features/assignments`.

- **AssignmentsListComponent** – DaisyUI `table` with status chips, due countdown.
- **AssignmentEditorComponent** – multi-step form with rubric builder (accordion for criteria).
- **SubmissionWorkspaceComponent** – inline review UI with document viewer (embedding PDF) and rubric scoring side panel.
- **StudentSubmissionComponent** – submission form with artifact upload, status badges.
- **ExceptionManagerComponent** – teacher view for extensions.
- Use Angular signals store for assignments state (filters by class, status).

UX Considerations:
- Show late submissions with `badge badge-error` and highlight penalty info.
- Provide quick action to copy assignment to other classes/terms.
- Provide accessible keyboard shortcuts for rubric navigation.

---

## Testing Strategy

- **Domain.UnitTests**: verify resubmission rules, rubric scoring calculations, due date policies.
- **Application.UnitTests**: command handler coverage for create/publish/grade flows, exception application.
- **Infrastructure.IntegrationTests**: mapping for owned rubric structures, concurrency, artifact integration.
- **Web.AcceptanceTests**: ensure API respects permissions and due date constraints.
- **Angular Tests**: component tests for rubric builder and submission workspace; service tests for state store.

---

## Implementation Checklist

1. Domain models/events.
2. Application commands/queries/validators.
3. DbContext configuration, migrations, background jobs.
4. API endpoints + NSwag regeneration.
5. Angular components/services.
6. Tests across layers.
7. Execute build/test/format commands.
8. Update documentation/navigation.

---

## References

- Gradebook module interfaces for score sync.
- DaisyUI `steps`, `badge`, `drawer` components.
- Angular CDK drag/drop for rubric criteria ordering.
- FluentValidation for complex nested collections.
