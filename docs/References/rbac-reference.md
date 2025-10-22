# Epic 1.0 – RBAC Reference

## Role definitions
- `src/Domain/Constants/Roles.cs`: centralizes role names; currently only `Administrator` is defined and used across the stack.
- `src/Domain/Constants/Policies.cs`: exposes the policy name `CanPurge`, providing a single source of truth for policy identifiers.

## Infrastructure wiring
- `src/Infrastructure/DependencyInjection.cs`: registers ASP.NET Core Identity with role support (`AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>()`) and maps the `CanPurge` policy to the `Administrator` role via `policy.RequireRole(Roles.Administrator)`.
- `src/Infrastructure/Identity/IdentityService.cs`: wraps `UserManager`/`IAuthorizationService` to check role membership (`IsInRoleAsync`) and evaluate policies (`AuthorizeAsync`) for the application layer.
- `src/Web/DependencyInjection.cs` & `src/Web/Services/CurrentUser.cs`: expose the current user's identifier and assigned roles via `IUser`, enabling request-level role checks.

## Application-layer enforcement
- `src/Application/Common/Security/AuthorizeAttribute.cs`: custom attribute applied to MediatR requests to declare required roles and policies.
- `src/Application/Common/Behaviours/AuthorizationBehaviour.cs`: MediatR pipeline behavior that enforces `[Authorize]` metadata by ensuring the user is authenticated, belongs to specified roles, and satisfies referenced policies.
- Example usage: `src/Application/TodoLists/Commands/PurgeTodoLists/PurgeTodoLists.cs` is decorated with `[Authorize(Roles = Roles.Administrator)]` and `[Authorize(Policy = Policies.CanPurge)]`, so only admins fulfilling the policy can execute the purge command.

## General RBAC pattern
1. **Define the contract**: add or update entries in `Roles` and `Policies` so role names and policy identifiers stay consistent across layers.
2. **Wire infrastructure**: update `Infrastructure.DependencyInjection` to seed roles, register new policies, and pair them with the required roles or custom `IAuthorizationHandler`s.
3. **Expose identity**: rely on `IdentityService` and the `IUser` abstraction (`CurrentUser`) to surface the caller's id, roles, and policy evaluation to the application layer.
4. **Secure the use case**: decorate the relevant MediatR request with `[Authorize(Roles = …, Policy = …)]`; the `AuthorizationBehaviour` enforces both role and policy checks before the handler runs.
5. **Validate the workflow**: cover the new configuration with integration tests and extend seeding/bootstrapping scripts so environments know about the newly declared roles and policies.

## Extending RBAC
- Add new roles to `Roles` and seed them via Identity to surface them throughout the system.
- Register additional policies in `DependencyInjection.AddInfrastructureServices`, mapping them to roles or custom `IAuthorizationHandler`s as needed.
- Decorate new MediatR requests with `[Authorize]` attributes to opt in to RBAC; the pipeline will enforce them automatically.
