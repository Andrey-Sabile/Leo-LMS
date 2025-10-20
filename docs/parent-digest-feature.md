# Parent Digest Feature Vertical Slice

Documentation for implementing the parent digest that summarizes student workload, recent grades, and announcements with optional email alerts.

---

## Feature Goals & Scope

- Provide parents/guardians with a consolidated digest view summarizing their child’s upcoming assignments, recent grades, attendance highlights, and announcements.
- Support configurable delivery: in-app dashboard plus scheduled email digest (daily/weekly).
- Allow parents to acknowledge key items and request follow-up with teachers.
- Respect privacy: parents only see content related to linked student(s) and class-level permissions.
- Integrate with notifications and announcements modules for cross-feature consistency.

Non-goals:
- Real-time push notifications (handled separately).
- Parent ability to edit student data.
- Multi-language translation beyond UI localization (document as future enhancement).

---

## Domain Design

### Aggregates & Entities

- **ParentDigestPreference (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `GuardianId`, `DeliveryFrequency` (Daily, Weekly, Manual), `DeliveryChannels` (InApp, Email), `QuietHours`, `LastSentOn`, `IncludedSections` (Assignments, Grades, Attendance, Announcements).
  - Behaviors: update preferences, pause/resume digest.
- **ParentDigestSnapshot** – stores generated digest content per run for auditing.
  - Properties: `Id`, `GuardianId`, `StudentId`, `GeneratedOn`, `ContentJson`, `DeliveryStatus`, `EmailMessageId`.
- **ParentAcknowledgment** – records acknowledgments for digest items.

### Value Objects

- **DigestSection** containing summary data metadata.
- **AcknowledgeTarget** referencing item (assignment, grade, announcement).

### Invariants & Business Rules

- Preferences unique per guardian; guardians with multiple students may set per-student preferences (optional future) – initial scope global per guardian.
- Email digests generated according to schedule; ensure idempotent sends per period.
- Acknowledgment allowed only on items tagged as requiring parent awareness.
- Guardians must be linked to student; unlinked guardians cannot access digest.

### Domain Events

- `ParentDigestPreferenceUpdatedEvent`, `ParentDigestGeneratedEvent`, `ParentDigestAcknowledgedEvent`.

---

## Application Layer

Namespace `src/Application/ParentDigest`.

### Commands

1. **UpdateParentDigestPreferenceCommand : IRequest** – set frequency, channels, sections.
2. **GenerateParentDigestCommand : IRequest<Guid>** – orchestrates data collection for guardian, produces snapshot.
3. **SendParentDigestCommand : IRequest** – triggers email delivery based on snapshot (could be background job).
4. **RecordParentAcknowledgmentCommand : IRequest** – mark digest item acknowledged and notify teacher if necessary.
5. **PauseParentDigestCommand : IRequest** – temporarily disable automatic sends.

### Queries

- **GetParentDigestSummaryQuery** – returns latest digest content for guardian.
- **GetParentDigestPreferencesQuery** – fetch preference settings.
- **GetParentAcknowledgmentsQuery** – list of acknowledged items.

### Integration

- Aggregates data from assignments (upcoming due), gradebook (recent grades), attendance (absences), announcements (latest relevant), forums (optional highlight).
- Uses notification/email service for scheduled sends.

### Validation & Mapping

- Validate guardian-student links, frequency values, quiet hours.
- Map aggregated digest content to DTOs for in-app display and email templates.

---

## Infrastructure

- DbSets for preferences, snapshots, acknowledgments.
- Background scheduler to run digest generation per frequency (nightly job grouping guardians by preference).
- Email templating system integration (Razor templates or third-party service).
- Ensure audit logging for emails sent.

---

## Web API

- Endpoint group `ParentDigest`.
- Endpoints: get latest digest, get/update preferences, acknowledge item, manual generate (admin override), pause/resume.
- Authorization ensures guardian role only sees linked student data; admin override with caution.

---

## Angular Frontend

Feature folder `features/parent-digest` (if parent UI separate) or integrated into parent dashboard.

- **ParentDigestComponent** – shows digest sections with DaisyUI `collapse` or `card` components per category.
- **DigestPreferencesComponent** – manage frequency, channels, quiet hours.
- **DigestAcknowledgmentComponent** – list items requiring acknowledgment with `checkbox`/`button` actions.
- Provide email template preview for guardians.
- Signals store handles data loading, preference updates, acknowledgment actions.

UX Considerations:
- Highlight urgent items with `badge badge-warning`.
- Provide timeline for upcoming due dates similar to student timeline but read-only.
- Ensure readability and accessible typography for parent audience.

---

## Testing Strategy

- **Domain.UnitTests**: preference updates, acknowledgment rules, scheduling invariants.
- **Application.UnitTests**: command handlers for generate/send/acknowledge, integration with data sources.
- **Infrastructure.IntegrationTests**: scheduler execution, email templating, data aggregation correctness.
- **Web.AcceptanceTests**: API security, digest generation flows.
- **Angular Tests**: component rendering for sections/preferences, store tests for acknowledgments.

---

## Implementation Checklist

1. Domain entities/preferences/events.
2. Application commands/queries/aggregators.
3. Infrastructure persistence, scheduler, email integration.
4. API endpoints & DI wiring.
5. NSwag regeneration.
6. Angular parent components/stores/tests.
7. Automated tests & formatting.
8. Update parent onboarding/support documentation.

---

## References

- Assignments, Gradebook, Attendance, Announcements modules for data inputs.
- DaisyUI `card`, `collapse`, `badge` components.
- Email templating best practices.
- Privacy/compliance guidelines for guardian communications.
