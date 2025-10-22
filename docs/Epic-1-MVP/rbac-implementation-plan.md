# Epic 1.0 – RBAC Implementation Plan

Establish Teacher, Student, and Administrator roles with end-to-end enforcement across the Clean Architecture layers.

## 1. Domain Layer
- Expand `src/Domain/Constants/Roles.cs` with `Teacher` and `Student`; keep `Administrator`.
- Add role-focused guards/policies in `src/Domain/Constants/Policies.cs` when specific permissions (e.g., classroom management) emerge.
- Link people aggregates to identity:
  - Add an immutable `IdentityUserId` (string) to `Teacher` and `Student`.
  - Introduce factory overloads/update methods that require the identity id.
  - Ensure invariants keep a 1:1 relationship between domain aggregate and identity user.

## 2. Application Layer
- Update request pipeline usage:
  - Decorate relevant commands/queries with `[Authorize(Roles = Roles.Teacher)]`, etc.
  - Introduce new policies if we need finer permission granularity beyond simple roles.
- Extend CQRS handlers:
  - Provision commands/queries for onboarding teachers/students that validate role assignments and domain aggregate creation.
  - Add query endpoints to expose the current user’s role profile for the web client.
- Ensure `AuthorizationBehaviour` handles multiple roles (already supported) and provides meaningful error responses.

## 3. Infrastructure Layer
- Identity setup:
  - Configure migrations to add `IdentityUserId` foreign keys in the EF model (Teacher ↔ ApplicationUser, Student ↔ ApplicationUser).
  - Update `ApplicationDbContext` mappings for new relationships.
- Role & user seeding:
  - In `ApplicationDbContextInitialiser` (or dedicated seed contributor), create default Identity roles (`Administrator`, `Teacher`, `Student`).
  - Seed baseline users for each role (optional but useful for QA) and assign roles.
  - Wire seed data to create matching domain aggregates tied to the identity users.
- Services:
  - Extend `IdentityService` with helpers for role assignment during onboarding workflows.

## 4. Web/API Layer
- Authentication pipeline:
  - Confirm JWT/cookie auth is emitting role claims (`ClaimTypes.Role`) for the three roles.
  - Update `CurrentUser` service if additional metadata is required (e.g., teacher/student profile id).
- API endpoints:
  - Introduce endpoints for admin-managed user onboarding (create teacher/student, update roles).
  - Gate existing endpoints with the new `[Authorize]` attributes, mapping to policies where appropriate.
- Razor minimal endpoints / controllers:
  - Review route handlers to ensure unauthorized users receive consistent responses (401/403).

## 5. Web Client (Angular + DaisyUI)
- State & routing:
  - Add a role-aware auth service that wraps the existing identity endpoints and stores role claims (consider Angular signals for reactive updates).
  - Create route guards/components that branch UI by role (Teacher dashboard, Student home, Admin console).
- UI composition:
  - Tailwind/DaisyUI helpers for conditional navigation menus, quick role badges, and access-denied messaging.
  - Ensure components read role state from the signal-based store instead of ad hoc checks.

## 6. Testing Strategy
- Unit tests:
  - Cover new domain invariants for `IdentityUserId`.
  - Test authorization attributes and policies on application handlers.
- Integration tests:
  - Validate seeding produces required roles/users and aggregates.
  - Exercise API endpoints to confirm role-restricted access behaves correctly.
- UI/functional tests:
  - Add Playwright/Cypress (or existing tooling) scenarios to ensure each role sees the right navigation and is blocked from restricted actions.

## 7. Deployment & Ops Considerations
- Document migration steps for existing environments (create roles, update users).
- Provide scripts or admin tooling to promote users between roles.
- Update RBAC reference (`docs/References/rbac-reference.md`) as changes land.

Deliverables from this plan should close the Epic 1.0 RBAC checkbox by providing measurable role enforcement from login through UI behavior.
