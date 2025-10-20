# Assessment Suite Feature Vertical Slice

Documentation for implementing the assessment suite covering question banks, exam creation, secure delivery, and scoring workflows.

---

## Feature Goals & Scope

- Maintain a reusable question bank with tagging (subject, difficulty, standard) and version history.
- Provide exam builder supporting question selection, randomization, sections, and accommodations.
- Deliver secure exam-taking experience with per-student tokens, timer, and optional lockdown guidance.
- Support automated scoring for objective questions and manual override for subjective items.
- Integrate results with gradebook and analytics dashboards.

Non-goals:
- Full proctoring or lockdown browser implementation (document integration points only).
- Adaptive testing (future extension).
- Question author collaboration workflow beyond single owner.

---

## Domain Design

### Aggregates & Entities

- **Question (Aggregate Root)** – `BaseAuditableEntity`.
  - Properties: `Id`, `Text`, `QuestionType` (MultipleChoice, TrueFalse, ShortAnswer, Essay, Matching, etc.), `Choices`, `CorrectResponses`, `Points`, `Tags`, `Version`, `IsPublished`.
  - Behaviors: publish/unpublish, create new version, validate answer data.
- **QuestionTag** – value object or reference table for taxonomy.
- **Assessment (Aggregate Root)** – exam/quiz entity.
  - Properties: `Id`, `Title`, `AssessmentType`, `ClassroomId`, `TotalPoints`, `TimeLimitMinutes`, `AvailabilityWindow`, `RandomizeQuestions`, `Sections`, `Instructions`, `IsActive`.
  - Navigation: `ICollection<AssessmentSection>`, `ICollection<AssessmentAssignment>`.
  - Behaviors: assemble from question bank, clone, publish, retire.
- **AssessmentSection** – holds ordered questions, optional randomization seed, section-level time limit.
- **AssessmentAssignment** – assignment to students with accommodations (extended time, alternate questions).
- **AssessmentSubmission** – records student responses, status, scores.

### Value Objects

- **QuestionVersion** capturing version metadata.
- **AvailabilityWindow** with start/end datetime and make-up window.
- **SecuritySettings** controlling attempts, password, IP restrictions.

### Invariants & Business Rules

- Questions require at least one tag and must be published to be included in active assessments.
- Assessment total points equals sum of section question points.
- Assessment cannot be activated without assigned students or schedule window.
- Submissions must complete within time limit unless accommodation overrides.
- Manual override marks as final grade even if auto score differs; history stored.

### Domain Events

- `QuestionPublishedEvent`, `AssessmentActivatedEvent`, `AssessmentSubmissionCompletedEvent`, `AssessmentScoreOverriddenEvent`.

---

## Application Layer

Namespace `src/Application/Assessments`.

### Commands

1. **CreateQuestionCommand : IRequest<Guid>** – adds new question with metadata, attachments.
2. **UpdateQuestionCommand : IRequest** – create new version or update existing if draft.
3. **CreateAssessmentCommand : IRequest<int>** – builds assessment from selected questions, sections.
4. **ActivateAssessmentCommand : IRequest** – enforces readiness, schedules availability.
5. **AssignAssessmentCommand : IRequest** – assign to students/classes, set accommodations.
6. **SubmitAssessmentCommand : IRequest<Guid>** – records responses, calculates auto score, triggers manual grading tasks when needed.
7. **OverrideScoreCommand : IRequest** – manual grade adjustments with audit log.

### Queries

- **GetQuestionBankQuery** – filter by tags, type, owner.
- **GetAssessmentDetailQuery** – sections, assignments, security settings.
- **GetAssessmentScheduleQuery** – upcoming exams timeline.
- **GetSubmissionsForAssessmentQuery** – grading queue with status/score.

### Validation & Mapping

- Validate question structures (choices count, correct answer presence).
- Map to DTOs for question editing, exam builder UI, and submissions.

---

## Infrastructure

- DbSets for questions, question versions, assessments, sections, assignments, submissions.
- Configure JSON columns for choices/responses (with converters) or normalized tables as needed.
- Implement concurrency tokens on questions to manage version race conditions.
- Provide stored procedure or query for randomization seeds generation (deterministic per student).
- Integrate with gradebook sync service for final scores.

---

## Web API

- Endpoint groups `QuestionBank` and `Assessments`.
- Endpoints: CRUD for questions, list/filter, manage tags; create/update/activate assessments; assign to classes; submit responses; override scores; fetch grading queue.
- Student submission endpoints require exam session token via `[Authorize]` with additional middleware verifying token.
- Upload endpoints for question assets (images, audio) using artifact repository.

---

## Angular Frontend

Feature folder `features/assessments`.

- **QuestionBankComponent** – table/grid with filter chips, tag management, inline version history modals.
- **QuestionEditorComponent** – handles dynamic form per question type; stepper for metadata/tags.
- **AssessmentBuilderComponent** – drag-and-drop interface for assembling sections; uses DaisyUI `steps` + Angular CDK.
- **AssessmentSchedulerComponent** – schedule window picker with timezone support.
- **AssessmentDeliveryComponent** – student-facing exam UI with timer, question navigation sidebar, autosave indicator.
- **GradingWorkspaceComponent** – manual grading view with rubric or scoring panel.
- Signals-based store orchestrates data loads and websocket updates for live status (optional).

UX Notes:
- Display question tags as DaisyUI `badge` elements.
- Show timer in fixed header; warn when time low.
- Provide `modal` overlay for confirm submit and manual override actions.

---

## Testing Strategy

- **Domain.UnitTests**: question validation, assessment activation rules, submission scoring logic.
- **Application.UnitTests**: command handler coverage for question/assessment workflows, accommodations, overrides.
- **Infrastructure.IntegrationTests**: verify EF mapping for complex JSON structures, randomization reproducibility.
- **Web.AcceptanceTests**: secure submission flow, activation restrictions, permission checks.
- **Angular Tests**: component tests for builder and delivery UI (timers, navigation), service tests for autosave.

---

## Implementation Checklist

1. Domain entities/value objects/events.
2. Application commands/queries/validators.
3. DbContext + configuration/migrations.
4. API endpoint groups & DI wiring.
5. NSwag regeneration & Angular client updates.
6. Angular feature components, services, styling.
7. Automated tests.
8. Build/test/format commands.
9. Documentation updates (navigation, teacher help docs).

---

## References

- Existing gradebook interfaces for score syncing.
- DaisyUI `steps`, `badge`, `modal` components.
- Angular CDK drag/drop and overlay resources.
- EF Core docs for JSON column mapping (if using PostgreSQL) or Owned types.
