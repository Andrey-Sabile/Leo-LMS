# Theming & Institutional Branding Feature Vertical Slice

Documentation for implementing consistent theming aligned with institutional branding options across the LeoLMS web application.

---

## Feature Goals & Scope

- Provide configurable themes that reflect institutional branding (colors, typography, logos) while maintaining accessibility.
- Allow admins to manage theme presets (primary/secondary colors, accent, neutral palettes) applied across Angular app and ASP.NET UI.
- Support per-tenant branding (if multi-school) or per-instance configuration.
- Ensure DaisyUI/Tailwind classes adapt to theme values and components remain visually consistent.
- Offer preview mode before publishing theme changes.

Non-goals:
- User-specific custom themes (future enhancement).
- Dynamic runtime theming for mobile apps.
- CSS framework changes beyond Tailwind/DaisyUI.

---

## Domain Design

### Aggregates & Entities

- **ThemeConfiguration (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `Name`, `PrimaryColor`, `SecondaryColor`, `AccentColor`, `NeutralColor`, `InfoColor`, `SuccessColor`, `WarningColor`, `ErrorColor`, `LogoUrl`, `TypographySettings`, `IsActive`, `PreviewToken`.
  - Behaviors: activate theme, update colors/branding assets, clone theme, schedule activation.
- **ThemeVersion** – optional entity for version history and rollback.
- **ThemeAssignment** – if supporting multi-tenant, mapping theme to institution.

### Value Objects

- **ColorPalette** enforcing hex format and contrast requirements.
- **TypographySettings** capturing font families/sizes.

### Invariants & Business Rules

- Active theme unique; activating new theme deactivates previous.
- Validate color contrast ratios (WCAG AA) for primary/secondary vs text; fail theme save if not compliant.
- Logo assets must be stored via artifact repository with appropriate dimensions.
- Preview mode accessible via tokenized URL and does not affect existing users until published.

### Domain Events

- `ThemeActivatedEvent`, `ThemePreviewRequestedEvent`, `ThemeRolledBackEvent`.

---

## Application Layer

Namespace `src/Application/Theming`.

### Commands

1. **CreateThemeCommand : IRequest<Guid>** – define new theme configuration.
2. **UpdateThemeCommand : IRequest** – modify colors, typography, logos; run contrast validation.
3. **ActivateThemeCommand : IRequest** – set theme active, optionally schedule future activation.
4. **GenerateThemePreviewCommand : IRequest<string>** – produce preview token and staging assets.
5. **RollbackThemeCommand : IRequest** – revert to previous theme version.

### Queries

- **GetThemeSettingsQuery** – return active theme for runtime use.
- **GetThemeVersionsQuery** – list versions for admin management.
- **GetThemePreviewQuery** – fetch preview theme by token.

### Validation & Mapping

- Validators for color hex, contrast ratio (maybe use service `IColorContrastService`).
- Map theme DTOs for API consumption by Angular theming service.

---

## Infrastructure

- DbSets for themes, versions, assignments.
- Integrate with artifact repository for logo storage.
- Provide service to generate CSS variables / DaisyUI theme definitions (Tailwind config update via runtime? use CSS custom properties served by API or configuration file).
- Cache active theme in memory/redis for fast access.
- Background job to purge expired preview themes.

---

## Web API

- Endpoint group `Theming`.
- Endpoints: create/update theme, activate, rollback, fetch active settings, fetch preview by token.
- Admin-only access; preview endpoint allows token-based auth.
- Provide `GET /api/theme/runtime` returning CSS variables or JSON for Angular app to apply.

---

## Angular Frontend

Shared service for runtime theming plus admin UI components in `features/theming`.

- **ThemeAdminComponent** – displays list of themes with status (active, draft).
- **ThemeEditorComponent** – form with color pickers (Tailwind-compatible) and logo upload.
- **ThemePreviewComponent** – iframe or overlay showing app preview using selected theme.
- Runtime: `ThemeService` loads active theme JSON, updates CSS variables on root element, leverages DaisyUI `data-theme` attribute.
- Signals store handles editing state, preview tokens, activation.

UX Considerations:
- Provide live contrast indicators (pass/fail) near color pickers.
- Offer sample component preview panel to show effect on cards, buttons, text.
- Ensure form accessible with keyboard and color-blind friendly indicators.

---

## Testing Strategy

- **Domain.UnitTests**: color validation, activation rules, preview token lifecycle.
- **Application.UnitTests**: command handler tests for create/update/activate, preview generation.
- **Infrastructure.IntegrationTests**: persistence of themes, caching, artifact storage for logos.
- **Web.AcceptanceTests**: API permission checks, runtime theme retrieval.
- **Angular Tests**: theme service applying CSS variables, component tests for editor/preview.

---

## Implementation Checklist

1. Domain theme entities/value objects.
2. Application commands/queries/validators/services.
3. Infrastructure persistence, caching, artifact integration.
4. API endpoints & DI wiring.
5. NSwag regeneration.
6. Angular admin components/runtime service/tests.
7. Automated tests & formatting.
8. Update documentation on branding configuration.

---

## References

- DaisyUI theming documentation (custom themes via data-theme).
- WCAG contrast ratio guidelines.
- Tailwind configuration patterns for dynamic theming (CSS variables).
- Artifact storage guidelines for logos.
