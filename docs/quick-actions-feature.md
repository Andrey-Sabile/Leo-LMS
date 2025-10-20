# Quick Actions Copy Feature Vertical Slice

Documentation for implementing the quick actions feature enabling teachers to copy or reuse content across classes or academic terms in a streamlined flow.

---

## Feature Goals & Scope

- Provide one-click shortcuts for teachers to copy lessons, assignments, assessments, and resources from one class/term to another.
- Offer configurable presets (e.g., "Copy last year’s unit", "Duplicate assignment to selected classes").
- Ensure copied content maintains links to relevant artifacts but generates new instances where required (e.g., assignments per class).
- Track history of quick actions for audit and rollback if needed.
- Integrate quick actions into class workspace, lesson planning, assignments, and learning content modules.

Non-goals:
- Cross-school content sharing (future feature).
- Automatic schedule adjustments beyond simple offsets.
- Bulk editing of copied content post-action (handled manually in respective modules).

---

## Domain Design

### Aggregates & Entities

- **QuickActionPreset (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `Name`, `SourceModule` (Lessons, Assignments, etc.), `DefaultSourceClassId`, `DefaultTargets`, `OptionsSchema`, `IsGlobal`.
  - Behaviors: execute action template, update defaults, publish/unpublish.
- **QuickActionExecution** – logs each run.
  - Properties: `Id`, `PresetId`, `ExecutorId`, `SourceContext`, `TargetContexts`, `ExecutedOn`, `Status` (Pending, Completed, Failed), `Summary`, `RollbackToken`.
- **QuickActionMapping** – value object mapping old IDs to new IDs for post-processing.

### Value Objects

- **ActionOption** capturing user inputs (date offsets, include attachments, etc.).
- **ExecutionStatus** enumerating state transitions.

### Invariants & Business Rules

- Presets reference valid modules and operations; validation ensures required parameters defined.
- Execution must run within transaction or orchestrated sequence to maintain data integrity across modules.
- Rollback available only if action supports reversal and logs necessary mapping info.
- Permissions: teacher may copy only from classes they own; target classes must be accessible.

### Domain Events

- `QuickActionExecutedEvent`, `QuickActionFailedEvent`, `QuickActionRolledBackEvent`.

---

## Application Layer

Namespace `src/Application/QuickActions`.

### Commands

1. **CreateQuickActionPresetCommand : IRequest<Guid>** – define preset with module-specific configuration.
2. **UpdateQuickActionPresetCommand : IRequest** – modify name/options/defaults.
3. **ExecuteQuickActionCommand : IRequest<Guid>** – orchestrates copy workflow by delegating to module-specific strategy.
4. **RollbackQuickActionCommand : IRequest** – revert when possible using stored mappings.

### Queries

- **GetQuickActionPresetsQuery** – list available presets filtered by module/class.
- **GetQuickActionHistoryQuery** – show execution history with status and summaries.
- **GetQuickActionPreviewQuery** – run dry-run to show items that will be copied.

### Validation & Mapping

- Validators ensure required fields, accessible classes, and options per module.
- Map to DTOs for Angular UI (preset info, execution results, preview data).

### Module Integration

- Implement strategy pattern (e.g., `IQuickActionHandler`) for each module (lessons, assignments, assessments, resources) to handle copy logic.
- Each handler responsible for cloning domain aggregates using existing application commands or dedicated APIs.

---

## Infrastructure

- DbSets for presets and executions.
- Persist execution logs, including serialized mapping data (JSON column) for rollback.
- Background job support for long-running copies (e.g., copying multiple lessons) with progress updates.
- Concurrency safeguards to prevent duplicate execution (idempotency keys).

---

## Web API

- Endpoint group `QuickActions`.
- Endpoints: create/update presets, list presets, preview action, execute action, rollback action, fetch history.
- Execution endpoint may return 202 Accepted with operation id for long-running tasks; progress via polling endpoint.
- Authorization ensures only permitted teachers/admins manage presets.

---

## Angular Frontend

Feature folder `features/quick-actions` (shared components reused by other modules).

- **QuickActionLauncherComponent** – button/dropdown integrated into module toolbars.
- **QuickActionWizardComponent** – modal guiding selection of source items, targets, options; DaisyUI `steps` component.
- **QuickActionHistoryComponent** – table of past executions with status badges and rollback buttons.
- Provide service to modules to open wizard with preselected context (e.g., from lesson planner).
- Signals store handles preset loading, execution state, progress updates.

UX Considerations:
- Show summary of items to be copied with counts; highlight modules affected.
- Provide progress indicator for long-running actions.
- Display rollback option when execution fails or teacher wants to revert.

---

## Testing Strategy

- **Domain.UnitTests**: validate preset constraints, execution status transitions, rollback metadata.
- **Application.UnitTests**: command handler coverage for execute/rollback (using mocked module handlers).
- **Infrastructure.IntegrationTests**: persistence of execution logs, background job integration.
- **Web.AcceptanceTests**: API tests for preview/execute/rollback flows, permissions.
- **Angular Tests**: wizard step validation, progress handling, integration with modules.

---

## Implementation Checklist

1. Domain entities/events for presets and executions.
2. Application commands/queries/strategy interfaces.
3. Infrastructure persistence & job handling.
4. API endpoints + DI registrations.
5. NSwag regeneration and Angular client updates.
6. Angular components/services integrated across modules.
7. Automated tests.
8. Run build/test/format commands.
9. Update teacher documentation/training resources.

---

## References

- Lesson Planning, Assignments, Learning Content modules for copy handlers.
- DaisyUI `steps`, `modal`, `badge` components.
- Background job scheduler documentation for async execution.
- Angular shared service patterns for cross-feature modals.
