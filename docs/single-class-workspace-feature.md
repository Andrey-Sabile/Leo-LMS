# Single Class Workspace Feature Vertical Slice

Documentation for implementing the unified class workspace that consolidates lesson plans, assignments, assessments, and gradebook controls into one teacher dashboard.

---

## Feature Goals & Scope

- Present teachers with a single workspace per class combining upcoming lessons, assignments, assessments, attendance snapshot, and gradebook highlights.
- Provide quick navigation between planning, delivery, and evaluation tasks without leaving the workspace.
- Surface actionable alerts (submissions to grade, attendance anomalies, unread forum posts) in context.
- Enable customizable layout (widgets/cards) and saved views per teacher preference.
- Integrate deep links to related vertical slices (lesson planning, assignments, gradebook) while maintaining consistent state.

Non-goals:
- Global multi-class dashboard (handled by Class Management feature).
- Teacher collaboration on workspace layout (single owner for now).
- Offline workspace mode.

---

## Domain Design

As the workspace aggregates data from multiple modules, domain focus is on configuration.

### Aggregates & Entities

- **ClassWorkspaceConfiguration (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `ClassroomId`, `TeacherId`, `LayoutDefinition`, `WidgetPreferences`, `DefaultFilters`, `LastVisitedSection`.
  - Behaviors: update layout, reorder widgets, reset to default, toggle widget visibility.
- **WorkspaceWidgetState** – value object representing widget-specific settings (e.g., show next 7 days of lessons).
- **WorkspaceShortcut** – saved quick actions (e.g., "Create Assignment"), stored as value objects.

### Value Objects

- **LayoutDefinition** capturing arrangement (grid positions) of widgets.
- **WidgetPreference** for per-widget configuration.

### Invariants & Business Rules

- Configuration unique per teacher/class combination.
- Ensure layout definition matches available widgets; fallback to defaults when modules disabled.
- Widget availability controlled by feature flags/permissions (e.g., gradebook widget requires gradebook enabled).
- Quick actions reference valid command endpoints.

### Domain Events

- `WorkspaceLayoutUpdatedEvent`, `WorkspaceWidgetToggledEvent` for telemetry and guidance.

---

## Application Layer

Namespace `src/Application/ClassWorkspace`.

### Commands

1. **UpsertWorkspaceConfigurationCommand : IRequest** – create or update configuration for teacher/class.
2. **UpdateWidgetPreferencesCommand : IRequest** – adjust settings per widget (e.g., default filter ranges).
3. **RecordWorkspaceVisitCommand : IRequest** – log last visited section/time for analytics.
4. **AddQuickActionCommand : IRequest** – create shortcut entries.

### Queries

- **GetWorkspaceSnapshotQuery** – aggregates data from dependent modules (lessons, assignments, submissions, attendance) via orchestrator service.
- **GetWorkspaceConfigurationQuery** – returns layout/prefs for UI.
- **GetWorkspaceAlertsQuery** – collects alert data (via notification service + module APIs).

### Validation & Mapping

- Validators ensuring layout grid positions valid, widget IDs recognized.
- Map snapshot data into consolidated DTO (e.g., `WorkspaceDashboardDto`) combining nested sections.

---

## Infrastructure

- DbSet for `ClassWorkspaceConfiguration`.
- Provide orchestrator service `IWorkspaceAggregator` that queries other modules via repositories or read models.
- Implement caching layer for snapshot data (e.g., per teacher/class, refreshed on demand).
- Telemetry logging for widget interactions.

---

## Web API

- Endpoint group `ClassWorkspaces`.
- Endpoints: get snapshot (`GET /api/classes/{id}/workspace`), get/update configuration, update widget preferences, manage quick actions.
- Snapshot endpoint orchestrates multiple module queries; consider background caching/resolver to prevent slow responses.
- Authorization ensures only assigned teachers/co-teachers access/edit workspace.

---

## Angular Frontend

Feature folder `features/class-workspace`.

- **ClassWorkspaceComponent** – grid layout using CSS grid + DaisyUI cards for widgets.
- **WorkspaceWidget** components for each module (lessons list, submissions to grade, attendance summary, forums highlights, gradebook summary).
- **WorkspaceSettingsDrawerComponent** – adjust layout & widget preferences.
- **QuickActionsBarComponent** – row of action buttons or `dropdown` linking to commands.
- Signals store loads snapshot, configuration, alerts; handles widget drag/drop (use Angular CDK drag-drop) and persists layout changes.

UX Considerations:
- Provide skeleton loaders while snapshot fetching.
- Allow resizing widgets by selecting layout presets (1x1, 1x2 etc.).
- Support theme coherence via DaisyUI `card` color variants for different widget types.

---

## Testing Strategy

- **Domain.UnitTests**: validate layout constraints, widget toggle behaviors.
- **Application.UnitTests**: orchestrator tests using stubbed module services, config updates.
- **Infrastructure.IntegrationTests**: persistence of configuration, caching behavior.
- **Web.AcceptanceTests**: ensure snapshot endpoint aggregates data correctly and respects permissions.
- **Angular Tests**: component tests for layout interactions, store tests for configuration persistence.

---

## Implementation Checklist

1. Domain configuration entity/value objects.
2. Application commands/queries and orchestrator service.
3. Infrastructure persistence + caching.
4. API endpoints + DI wiring.
5. NSwag regeneration.
6. Angular components, widget implementations, settings UI.
7. Automated tests across layers.
8. Run build/test/format commands.
9. Update teacher documentation/training materials.

---

## References

- Existing dashboard components for style guidance.
- DaisyUI `card`, `drawer`, `dropdown` components.
- Angular CDK drag-drop for widget arrangement.
- Notification center to supply alert feeds.
