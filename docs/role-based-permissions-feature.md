# Role-Based Permissions & Audit Trails Feature Vertical Slice

Documentation for implementing role-based permissions with audit trails across the LeoLMS platform.

---

## Feature Goals & Scope

- Establish a centralized authorization system with role-based access control (RBAC) for teachers, students, admins, and parents.
- Provide fine-grained policy definitions for feature access (e.g., manage assignments, view gradebook, read-only forums).
- Implement audit logging for key actions (create/update/delete, permission changes) with traceability.
- Offer administrative tooling to review audits and adjust role policies when necessary.
- Integrate seamlessly with ASP.NET Identity/authorization pipeline and Angular route guards.

Non-goals:
- Attribute-based access control (beyond defined roles) – document future enhancements.
- External SSO provisioning (handled separately).
- Real-time anomaly detection (captured as future work).

---

## Domain Design

### Aggregates & Entities

- **RoleDefinition (Aggregate Root)** – inherits `BaseAuditableEntity`.
  - Properties: `Id`, `Name`, `DisplayName`, `Description`, `Permissions` (collection), `IsSystemRole`.
  - Behaviors: add/remove permissions, clone role, mark as inactive.
- **Permission** – value object representing capability (e.g., `Assignments.Manage`).
- **AuditEvent** – persisted entity capturing actions.
  - Properties: `Id`, `Timestamp`, `UserId`, `Action`, `EntityType`, `EntityId`, `MetadataJson`, `IpAddress`, `CorrelationId`.

### Value Objects

- **PermissionGrant** capturing `PermissionKey`, `Scope` (Global, Classroom, Student), `Constraints`.
- **AuditMetadata** storing humans-readable context.

### Invariants & Business Rules

- System roles (Teacher, Student, Admin, Parent) immutable by default; changes require elevated approval.
- Custom roles must be unique in name and cannot duplicate system role identifiers.
- Permissions defined centrally; modules reference constants to avoid drift.
- All sensitive actions produce audit events; retention policy configurable.

### Domain Events

- `RoleDefinitionUpdatedEvent`, `PermissionGrantedEvent`, `AuditEventCreatedEvent`.

---

## Application Layer

Namespace `src/Application/Authorization`.

### Commands

1. **CreateRoleDefinitionCommand : IRequest<Guid>** – define custom role with permissions.
2. **UpdateRoleDefinitionCommand : IRequest** – adjust permissions, description.
3. **AssignRoleToUserCommand : IRequest** – map role to user/classroom scope.
4. **RecordAuditEventCommand : IRequest** – invoked by modules to log actions.
5. **PurgeAuditEventsCommand : IRequest** – cleanup old events per retention policy.

### Queries

- **GetRoleDefinitionsQuery** – list roles with permissions.
- **GetUserPermissionsQuery** – resolve effective permissions for given user/class.
- **GetAuditEventsQuery** – search audit logs by user, action, date range.

### Validation & Mapping

- Validate permission keys exist in registry.
- Map role definitions and audits to DTOs consumed by admin UI.

### Integration

- Provide `IAuthorizationService`/policy provider hooking into ASP.NET Core authorization.
- Expose helper for Angular to fetch permission claims and guard routes/components.
- Use pipeline behaviors or interceptors to automatically record audit events on commands.

---

## Infrastructure

- DbSets for role definitions, role assignments (user-role-scope), audit events.
- Seeding mechanism for system roles/permissions.
- Configure indexes on `AuditEvent` (UserId, Timestamp, Action).
- Logging pipeline storing correlation IDs and request metadata.
- Integration with telemetry (e.g., Application Insights) for additional visibility.

---

## Web API

- Endpoint group `Authorization`.
- Endpoints: list roles, create/update roles, assign role, get user permissions, search audit events.
- Provide endpoints for Angular to fetch current user permissions and audit logs (admin-only).
- Secure endpoints with admin policy; use pagination for audit queries.

---

## Angular Frontend

Feature folder `features/authorization` for admin tooling; shared permission services for rest of app.

- **RoleManagementComponent** – table of roles with permission badges.
- **RoleEditorComponent** – tree view or grouped checklist for permissions.
- **AuditLogComponent** – searchable log using DaisyUI `table` with filters; export option.
- Shared `PermissionGuardService` and directive to control UI visibility.
- Signals store caches permissions and audit query state.

UX Considerations:
- Display system roles with lock icon (read-only).
- Provide search/filter for audit log with date pickers.
- Use DaisyUI `badge` to represent permissions groups.

---

## Testing Strategy

- **Domain.UnitTests**: ensure permission sets enforce invariants, audit event creation.
- **Application.UnitTests**: command handler coverage for create/update roles, assign roles, record audits.
- **Infrastructure.IntegrationTests**: seeding, mapping, audit storage throughput.
- **Web.AcceptanceTests**: API auth checks, audit query results.
- **Angular Tests**: component tests for role editor, audit log filters; guard tests verifying permission enforcement.

---

## Implementation Checklist

1. Domain role definitions/permissions/audits.
2. Application commands/queries/policy provider.
3. Infrastructure persistence, seeding, logging pipeline.
4. API endpoints + DI wiring.
5. NSwag regeneration & Angular permission services.
6. Angular admin components/tests.
7. Automated tests & formatting.
8. Update security documentation and admin playbooks.

---

## References

- ASP.NET Core Authorization policies & handlers docs.
- OWASP guidelines for audit logging.
- DaisyUI `table`, `badge`, `dropdown` for UI.
- Angular route guard and directive patterns.
