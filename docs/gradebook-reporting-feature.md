# Gradebook & Reporting Feature Vertical Slice

Documentation for implementing the gradebook and reporting vertical slice enabling score entry, weighting, progress summaries, and exports.

---

## Feature Goals & Scope

- Provide teachers with a grid-based gradebook per class supporting manual entry, bulk edits, and quick filters.
- Configure grading categories with weights and aggregation rules (points, percentages, standards-based).
- Generate progress summaries per student and class, including trends and missing work indicators.
- Export grades and reports to CSV/PDF for administrative sharing.
- Sync with assignments, assessments, and attendance modules to gather inputs and trigger alerts.

Non-goals:
- Standards-based mastery reporting beyond basic category breakdown (document future plan).
- Direct SIS export (future integration).
- Parent portal interactions (covered via Parent Digest feature).

---

## Domain Design

### Aggregates & Entities

- **Gradebook (Aggregate Root)** – per class/term entity inheriting `BaseAuditableEntity`.
  - Properties: `Id`, `ClassroomId`, `AcademicTermId`, `GradingScheme` (Points, WeightedCategories, Standards), `IsLocked`.
  - Navigation: `ICollection<GradebookCategory>`, `ICollection<GradebookEntry>`.
  - Behaviors: configure categories, lock/unlock grading periods, recalculate aggregates.
- **GradebookCategory** – category weight configuration.
  - Properties: `Id`, `GradebookId`, `Name`, `Weight`, `DropLowestCount`, `CalculationMethod`.
- **GradebookEntry** – per student per assignment/exam entry.
  - Properties: `Id`, `GradebookId`, `AssessmentId` (assignment/exam/other), `StudentId`, `Score`, `MaxScore`, `Status` (Missing, Excused, Completed), `CategoryId`, `Comment`, `LastSyncedOn`.
- **ProgressSnapshot** – aggregated metrics stored for reporting (optional persisted view).

### Value Objects

- **GradingScheme** encapsulating weights and calculation algorithms.
- **ExportRequest** capturing parameters for generated reports.
- **TrendDataPoint** for progress graphs.

### Invariants & Business Rules

- Category weights must sum to 100% when using weighted scheme.
- Gradebook entries sourced from assignments/assessments should not be edited directly unless teacher overrides enabled; maintain audit trail.
- Locking gradebook prevents further edits except admin overrides.
- Missing work flagged when due date passed with no score; triggers notification events.
- Export operations must respect data privacy (teacher-only or admin roles).

### Domain Events

- `GradebookConfiguredEvent`, `GradebookEntryUpdatedEvent`, `GradebookLockedEvent`, `MissingWorkDetectedEvent`.

---

## Application Layer

Namespace `src/Application/Gradebook`.

### Commands

1. **ConfigureGradebookCommand : IRequest** – set scheme, categories, default policies.
2. **UpdateCategoryWeightsCommand : IRequest** – adjust weights with validation.
3. **UpsertGradebookEntryCommand : IRequest** – handles manual edits, overrides, comments.
4. **LockGradebookCommand : IRequest** – marks gradebook locked, emits event.
5. **GenerateReportCommand : IRequest<Guid>** – triggers background job for CSV/PDF generation.
6. **SyncAssessmentScoresCommand : IRequest** – invoked from assignments/assessments modules to update entries.

### Queries

- **GetGradebookForClassQuery** – returns grid with categories, entries, student list.
- **GetStudentProgressQuery** – per student summary and trends.
- **GetReportingDashboardQuery** – aggregated metrics (class averages, completion rates).
- **GetExportStatusQuery** – monitors background report generation.

### Validation & Mapping

- Validators for category sums, non-negative scores.
- AutoMapper to transform entries into `GradebookEntryDto`, `StudentProgressDto`.

---

## Infrastructure

- DbSets for gradebooks, categories, entries, exports.
- Configure indexes on `GradebookId`, `StudentId`, `CategoryId`.
- Implement database functions/materialized views for trend calculations (optional) or use background job to precompute snapshots.
- Integrate with reporting service (e.g., using QuestPDF) for PDF generation stored in artifact repository.
- Ensure concurrency control to prevent conflicting updates (rowversion).

---

## Web API

- Endpoint group `Gradebooks`.
- Endpoints: configure gradebook, update categories, upsert entries, lock gradebook, fetch gradebook grid, get student progress, trigger export, check export status, download export artifact.
- Authorization ensuring only teachers/co-teachers and admins can modify.
- Support WebSocket or signalR hub for realtime grade updates (optional future step).

---

## Angular Frontend

Feature folder `features/gradebook`.

- **GradebookGridComponent** – virtualized grid using table + sticky headers; inline edit cells with DaisyUI inputs.
- **CategoryConfigComponent** – manage category list with weight sliders (`input[type=range]` styled via DaisyUI).
- **ProgressSummaryComponent** – charts using library (e.g., ngx-charts) with DaisyUI cards.
- **ExportPanelComponent** – shows export history and download links.
- **GradebookStore** – signals-based state handling entries, filters, loading.

UX Notes:
- Color-code statuses (missing, excused) with DaisyUI `badge`.
- Provide keyboard navigation for cells (arrow keys) and bulk actions.
- Display lock indicator with `badge badge-secondary`.

---

## Testing Strategy

- **Domain.UnitTests**: validate weight sums, lock behavior, missing work detection.
- **Application.UnitTests**: command handler coverage for configure/upsert/sync flows, report generation triggers.
- **Infrastructure.IntegrationTests**: EF configuration, concurrency tokens, export storage.
- **Web.AcceptanceTests**: verify API permissions, export flows.
- **Angular Tests**: grid editing interactions, store calculations, export panel.

---

## Implementation Checklist

1. Domain models/events.
2. Application commands/queries/validators.
3. DbContext configuration & migrations; reporting integration.
4. API endpoints and DI registration.
5. Regenerate NSwag clients.
6. Angular feature components/state/tests.
7. Automated testing across layers.
8. Build/test/format.
9. Documentation updates and teacher help resources.

---

## References

- Assignments/Assessments modules for score sync contracts.
- DaisyUI table/cards/badge patterns.
- QuestPDF or equivalent for report generation.
- Angular CDK for virtual scrolling if needed.
