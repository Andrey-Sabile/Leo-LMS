# Lesson Planning Feature Vertical Slice

Documentation for implementing the lesson planning slice that enables teachers to author reusable templates, plan units/lessons, and track readiness.

---

## Feature Goals & Scope

- Provide day-by-day lesson planning with support for objectives, activities, resources, and outcomes.
- Allow teachers to create reusable templates and clone lessons across classes or terms.
- Attach artifacts (files, links, embedded media) to lessons while keeping version history in the artifact repository.
- Track lesson status (Draft, Ready, Delivered, Needs Revision) and surface readiness indicators in dashboards.
- Integrate with assignments/exams to link planned assessments and with gradebook for expected score distributions.

Non-goals:
- Automatic curriculum sequencing from standards (document for future).
- Content authoring beyond structured fields (no WYSIWYG dependency yet).
- Collaborative editing (single author flow for now).

---

## Domain Design

### Aggregates & Entities

- **LessonPlan (Aggregate Root)** – derived from `BaseAuditableEntity`.
  - Properties: `Id`, `ClassroomId`, `Title`, `InstructionalDay` (date or relative sequence), `Objective`, `Activities` (collection), `Outcomes`, `Status`, `TemplateId`, `IsPublished`.
  - Navigation: `ICollection<LessonAttachment>`, `ICollection<LessonSegment>`, `ICollection<LinkedAssessment>`.
  - Behaviors: create from template, update content, change status with validation (e.g., cannot mark Delivered before scheduled date), publish/unpublish.
- **LessonTemplate** – stores reusable structures.
  - Properties: `Id`, `Name`, `SubjectTagId`, `DefaultDuration`, `Sections` (owned collection), `SharedWith` (school, grade-level).
  - Behaviors: maintain versioning, clone into `LessonPlan`.
- **LessonSegment** – structured block (e.g., Warm-up, Instruction, Practice) with timings and notes.
- **LessonAttachment** – metadata linking to Artifact Repository asset ids.
- **LinkedAssessment** – references assignments/exams (`AssessmentId`, `Type`, `ExpectedDate`).

### Value Objects

- **LessonStatus** enumeration or value object controlling transitions (Draft → Ready → Delivered, etc.).
- **LessonSchedule** to manage start/end times per day.
- **SectionDefinition** for templates.

### Invariants & Business Rules

- Lesson must belong to one `Classroom` or be template-only; cross-class clones produce new aggregate.
- `Status` transitions require validations (e.g., `Ready` requires objectives and at least one segment defined).
- Attachments require valid artifact ids and ensure version recorded.
- Templates track version numbers; editing published template spawns new version while preserving existing links.
- Deleting a lesson uses soft-delete; archived lessons remain visible in history but not on dashboards.

### Domain Events

- `LessonPlanCreatedEvent`, `LessonStatusChangedEvent`, `LessonTemplateVersionCreatedEvent`.

---

## Application Layer

Namespace `src/Application/LessonPlanning`.

### Commands

1. **CreateLessonCommand : IRequest<int>** – builds lesson from template or blank; populates segments and attachments.
2. **UpdateLessonCommand : IRequest** – updates objectives, segments, status; ensures attachments validated via artifact service.
3. **ChangeLessonStatusCommand : IRequest** – explicit workflow transitions; enforces prerequisites (objectives, segments, linked assessments when required).
4. **CreateTemplateCommand : IRequest<int>** – create or clone template with sections and default settings.
5. **UpdateTemplateCommand : IRequest** – create new version when significant change flagged.
6. **LinkAssessmentToLessonCommand : IRequest** – associates assignment/exam with plan.

### Queries

- **GetLessonCalendarQuery** – returns lessons for class across date range with statuses.
- **GetLessonDetailQuery** – loads segments, attachments, linked assessments.
- **GetTemplatesQuery** – filtered by subject/tag, grade level, owner.

### Validation & Mapping

- Validators ensure `Title`, `Objective`, `InstructionalDay` set; segments follow chronological order.
- Map templates and lessons to DTOs used by API/Angular (e.g., `LessonSegmentDto`).

---

## Infrastructure

- Add `DbSet<LessonPlan>`, `DbSet<LessonTemplate>`, `DbSet<LessonSegment>`, `DbSet<LessonAttachment>`.
- Configure owned collections for segments and template sections.
- Implement concurrency/version columns for templates.
- Provide repository services for timeline queries (SQL view or projection for `InstructionalDay`).
- Integrate with artifact storage via `ILessonArtifactService` bridging to Artifact Repository module.

---

## Web API

- Endpoint group `LessonPlans` (`src/Web/Endpoints/LessonPlans.cs`).
- Routes: create/update lessons, change status, list for class, manage templates, link assessments.
- Provide filter query for `status`, `classroomId`, `dateRange`.
- Ensure endpoints emit events to notification center (e.g., driving readiness alerts).

---

## Angular Frontend

Feature folder: `.../lesson-planning`.

- **LessonPlannerComponent** – calendar view (daisyUI `tabs`/`steps`), displays day list with status badges.
- **LessonEditorComponent** – reactive form with segment repeater using DaisyUI `collapse` or `accordion` to manage sections.
- **TemplateLibraryComponent** – list of templates with filtering and preview modals.
- **AttachmentPanelComponent** – integrates artifact picker modal.
- Provide timeline view using DaisyUI `timeline` semantics (or custom) showing statuses.
- Use Angular signals to manage selected lesson, editing state, and async loads via `LessonPlansClient`.

UX Considerations:
- Display status with DaisyUI `badge` (`badge-success` for Ready, etc.).
- Offer quick copy actions to clone upcoming week (ties into Quick Actions feature).
- Provide diff view when applying template updates (initially informational modal).

---

## Testing Strategy

- **Domain.UnitTests**: verify status transitions, template cloning, attachment validation.
- **Application.UnitTests**: command handlers ensuring prerequisites, template versioning, linking assessments.
- **Infrastructure.IntegrationTests**: EF mapping for owned collections, concurrency tokens, cross-module integration with artifact references.
- **Web.AcceptanceTests**: API tests verifying timeline retrieval and status change security.
- **Angular Tests**: component tests for planner timeline and editor dynamic segments; store tests for state transitions.

---

## Implementation Checklist

1. Domain entities/value objects, events.
2. Commands/queries/validators & DTO mappings.
3. DbContext + configuration updates, migration for lesson tables.
4. API endpoints with policy guards.
5. NSwag client regeneration.
6. Angular components/interfaces plus Tailwind/DaisyUI styling.
7. Tests across layers.
8. Run solution/test/lint/format commands.
9. Update navigation/links in web UI documentation.

---

## References

- Contacts feature doc for vertical slice organization.
- DaisyUI `timeline`, `collapse`, `modal` components.
- Angular CDK drag/drop if needed for reordering segments.
- EF Core owned entity documentation.
