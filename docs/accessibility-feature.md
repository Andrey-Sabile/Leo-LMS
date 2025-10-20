# Accessibility Support Feature Vertical Slice

Documentation for implementing accessibility support ensuring keyboard navigation and screen reader friendliness across LeoLMS.

---

## Feature Goals & Scope

- Guarantee keyboard navigability for all interactive components (forms, tables, dialogs) with logical focus order and visible focus states.
- Provide comprehensive ARIA semantics and screen reader labels for critical workflows (class workspace, assignments, forums, gradebook).
- Implement accessibility testing pipeline (automated + manual) integrated with CI/CD.
- Offer accessibility settings (font scaling, high contrast toggle) that respect institutional branding.
- Ensure compliance with WCAG 2.1 AA standards.

Non-goals:
- Complete localization in all languages (focus on accessibility rather than translation).
- Native mobile accessibility (web app only).

---

## Domain Design

Accessibility is cross-cutting; domain layer includes configuration and audit tracking.

### Aggregates & Entities

- **AccessibilitySetting (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `Scope` (Global, User), `HighContrastEnabled`, `FontScale`, `ReducedMotion`, `LastUpdatedBy`.
  - Behaviors: toggle settings, enforce allowed ranges.
- **AccessibilityAuditLog** – records accessibility issues found/resolved.

### Value Objects

- **AccessibilityPreference** storing user-level overrides.
- **AuditFinding** containing severity, description, component path.

### Invariants & Business Rules

- Global settings provide defaults; users can override within allowed ranges.
- High contrast and branding theme must remain compliant (validate color contrast when toggled).
- Accessibility issues logged must be assigned/resolved within SLA (documented procedure).

### Domain Events

- `AccessibilityPreferenceUpdatedEvent`, `AccessibilityIssueLoggedEvent`, `AccessibilitySettingChangedEvent`.

---

## Application Layer

Namespace `src/Application/Accessibility`.

### Commands

1. **UpdateAccessibilitySettingsCommand : IRequest** – adjust global defaults.
2. **UpdateUserAccessibilityPreferenceCommand : IRequest** – set user-level preferences.
3. **LogAccessibilityIssueCommand : IRequest<Guid>** – record issue discovered via testing.
4. **ResolveAccessibilityIssueCommand : IRequest** – mark issue resolved with notes.

### Queries

- **GetAccessibilitySettingsQuery** – returns global defaults and toggles.
- **GetUserAccessibilityPreferenceQuery** – returns user-specific overrides.
- **GetAccessibilityIssuesQuery** – list outstanding issues for tracking.

### Integration

- Provide service to supply accessibility tokens to Angular app (e.g., `data-theme` for high contrast).
- Hook into CI pipeline to file issues via API after automated tests (Pa11y/Axe).

### Validation & Mapping

- Validate font scale range (e.g., 0.8–1.5), ensure boolean toggles consistent.
- Map preferences to DTOs used by frontend.

---

## Infrastructure

- DbSets for settings, preferences, audit logs.
- Integration with identity to store per-user preferences.
- Provide service wrappers around third-party accessibility testing (store results).
- Logging of issue lifecycle for compliance.

---

## Web API

- Endpoint group `Accessibility`.
- Endpoints: get/update global settings, get/update user preferences, log issues, resolve issues, list issues.
- Enforce appropriate authorization (admins manage global settings; users manage own preferences).

---

## Angular Frontend

Shared accessibility utilities plus admin dashboard components.

- **AccessibilitySettingsComponent** – user-facing panel in profile settings for toggles.
- **AccessibilityAdminComponent** – view/manage logged issues with DaisyUI `table` and filters.
- **HighContrastToggleComponent** – switch in header to toggle theme with `data-theme` attribute.
- Implement focus management utilities (e.g., `FocusTrap` for modals) and skip links.
- Signals store handles preferences, ensures settings apply via CSS variables.

UX Considerations:
- Provide persistent skip-to-content link at top of page.
- Ensure focus outlines visible and meet contrast requirements.
- Offer real-time preview when adjusting font scale/high contrast.

---

## Testing Strategy

- **Domain.UnitTests**: preferences validation, issue lifecycle.
- **Application.UnitTests**: command handler tests for update/log/resolve operations.
- **Infrastructure.IntegrationTests**: persistence for settings, issue storage, integration with testing tools.
- **Web.AcceptanceTests**: API tests verifying permissions and data.
- **Accessibility Testing**: integrate Axe/Pa11y automated tests in CI; manual testing checklist.
- **Angular Tests**: ensure components respond to preference changes, high contrast toggle updates DOM.

---

## Implementation Checklist

1. Domain entities/preferences/events.
2. Application commands/queries/validators/services.
3. Infrastructure persistence and testing tool integration.
4. API endpoints & DI wiring.
5. NSwag regeneration.
6. Angular accessibility components/utilities/tests.
7. Integrate automated accessibility tests in CI.
8. Run build/test/format commands.
9. Update accessibility compliance documentation.

---

## References

- WCAG 2.1 AA guidelines.
- Axe-core/Pa11y tooling docs.
- DaisyUI accessibility recommendations (focus styles, high contrast theme).
- Angular CDK `a11y` utilities (FocusTrap, LiveAnnouncer).
