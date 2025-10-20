# Analytics Dashboards Feature Vertical Slice (Future Extension)

Documentation for implementing deeper analytics dashboards per class, subject, and grade level.

---

## Feature Goals & Scope

- Deliver data-rich dashboards summarizing performance trends, engagement metrics, attendance, and assessment outcomes across classes, subjects, and grade levels.
- Provide custom visualizations (charts, tables, heatmaps) with drill-down capabilities to student-level insights.
- Support filters by timeframe, demographic segments, and instructional groups.
- Allow exporting analytics data to CSV/PDF and optionally share with stakeholders.

Non-goals (initial release):
- Predictive analytics or machine learning-based insights.
- Real-time streaming dashboards; data can be refreshed periodically.
- Public/parent-facing dashboards (admin and teacher focus initially).

---

## Domain Design

### Aggregates & Entities

- **AnalyticsDashboardDefinition (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `Name`, `Scope` (Class, Subject, GradeLevel), `Widgets` (collection), `Filters`, `RefreshInterval`, `OwnerRole`.
  - Behaviors: update widget configuration, clone dashboard, schedule refresh.
- **AnalyticsWidget** – value object representing visualization config (chart type, query source, metrics).
- **AnalyticsDataSnapshot** – stored dataset for each dashboard execution.
  - Properties: `Id`, `DashboardId`, `GeneratedOn`, `DataJson`, `Status`, `Error`.

### Value Objects

- **FilterDefinition** capturing available filters (date range, class, demographic group).
- **VisualizationConfig** for chart-specific settings (axes, color palette).

### Invariants & Business Rules

- Dashboard definitions must reference valid data sources (assignment/assessment/attendance aggregates).
- Refresh interval cannot be shorter than system minimum to avoid overload.
- Data snapshots retained per retention policy; stale data flagged for refresh.
- Access controlled by role and assigned scope (e.g., teacher sees own classes only).

### Domain Events

- `AnalyticsDashboardCreatedEvent`, `AnalyticsSnapshotGeneratedEvent`, `AnalyticsDashboardSharedEvent`.

---

## Application Layer

Namespace `src/Application/Analytics`.

### Commands

1. **CreateAnalyticsDashboardCommand : IRequest<Guid>** – define dashboard with initial widgets.
2. **UpdateAnalyticsDashboardCommand : IRequest** – modify widgets, filters, refresh interval.
3. **GenerateAnalyticsSnapshotCommand : IRequest<Guid>** – triggers data aggregation and stores snapshot.
4. **ShareAnalyticsDashboardCommand : IRequest** – share with other users/roles.
5. **DeleteAnalyticsDashboardCommand : IRequest** – soft-delete definition and snapshots.

### Queries

- **GetAnalyticsDashboardQuery** – returns latest snapshot with metadata.
- **GetAnalyticsDashboardsListQuery** – list available dashboards per user.
- **GetAnalyticsDataExportQuery** – export prepared data.

### Data Aggregation Services

- Implement `IAnalyticsAggregator` interfaces for assignments, assessments, attendance, gradebook.
- Use background jobs for heavy aggregation or caching.

### Validation & Mapping

- Validate widget configuration (chart type vs data source), filters, refresh interval.
- Map snapshots to DTOs for Angular data visualization components.

---

## Infrastructure

- DbSets for dashboard definitions and snapshots.
- Data warehouse or aggregation tables (materialized views) to serve metrics efficiently.
- Integration with reporting engine (QuestPDF) for PDF exports.
- Background scheduler for automatic snapshot generation.
- Caching layer for frequently accessed dashboards.

---

## Web API

- Endpoint group `Analytics`.
- Endpoints: create/update/delete dashboard, list dashboards, generate snapshot, fetch latest data, export dataset, share dashboard.
- Authorization ensures user only accesses allowed scopes.

---

## Angular Frontend

Future feature folder `features/analytics`.

- **AnalyticsDashboardComponent** – grid of widgets with charts (use ngx-charts/Chart.js) styled with DaisyUI cards.
- **AnalyticsWidgetComponent** – renders specific visualization type (line graph, bar, heatmap).
- **DashboardFilterBarComponent** – filter controls with date pickers, dropdowns.
- **DashboardBuilderComponent** – admin interface to configure widgets via drag-and-drop.
- Signals store handles snapshot loading, filter application, refresh intervals.

UX Considerations:
- Provide loading skeletons for chart data.
- Allow saving filter presets per user.
- Support responsive layout with collapsible widgets on smaller screens.

---

## Testing Strategy

- **Domain.UnitTests**: widget validation, refresh rules, sharing permissions.
- **Application.UnitTests**: command handlers for create/update/generate, aggregator mocks.
- **Infrastructure.IntegrationTests**: data aggregation accuracy, snapshot persistence, export generation.
- **Web.AcceptanceTests**: API permission enforcement, data retrieval correctness.
- **Angular Tests**: component rendering for charts, filter interactions, builder UI tests.
- **Performance Testing**: ensure snapshot generation scales with dataset size.

---

## Implementation Checklist

1. Domain dashboard definitions/value objects/events.
2. Application commands/queries/aggregators.
3. Infrastructure data aggregation/caching, migrations.
4. API endpoints + DI wiring.
5. NSwag regeneration.
6. Angular analytics components, visualization integration, tests.
7. Automated/unit/integration/performance tests.
8. Build/test/format commands.
9. Documentation/training for interpreting dashboards.

---

## References

- Existing gradebook/assessment data models for metrics.
- Charting libraries (ngx-charts, ApexCharts) and DaisyUI card styling.
- Data warehousing best practices (materialized views, ETL scheduling).
- Accessibility guidelines for data visualization (color contrast, alt text).
