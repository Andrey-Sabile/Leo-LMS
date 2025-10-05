# Repository Guidelines

## Project Structure & Module Organization
LeoLMS.sln anchors the solution and wires together the core layers under `src/`. Use `src/Application` for orchestration logic and CQRS handlers, `src/Domain` for entities plus domain events, `src/Infrastructure` for persistence and integrations, and `src/Web` for the ASP.NET Core front end. Shared build props live in `Directory.Build.props` and `Directory.Packages.props`. Tests are grouped by concern in `tests/`, mirroring the production namespaces (`Application.FunctionalTests`, `Domain.UnitTests`, etc.), while deploy-time assets and environment scaffolding live under `infra/`. Artifacts from local packaging land in `artifacts/`.

## Build, Test, and Development Commands
- `dotnet build -tl` – compile all projects with the default logger configuration.
- `dotnet watch run --project src/Web/Web.csproj` – hot-reload the web app at https://localhost:5001.
- `dotnet test --filter "FullyQualifiedName!~AcceptanceTests"` – run unit, integration, and functional suites.
- `dotnet test --project tests/Web.AcceptanceTests/Web.AcceptanceTests.csproj` – execute acceptance scenarios (requires the web app running separately).
- `dotnet format` – apply `.editorconfig` conventions; run before opening a PR.

## Coding Style & Naming Conventions
Target the .NET 9 SDK declared in `global.json`. C# files use four-space indentation, `PascalCase` for classes and public members, `camelCase` for locals, and `SCREAMING_SNAKE_CASE` only for constants. Keep namespaces aligned with folder paths (e.g., `LeoLMS.Application.*`). Prefer records for immutable models and guard domain logic with value objects. Enforce analyzers by addressing warnings; never suppress without justification in code comments.

## Testing Guidelines
Tests inherit naming from their source layers (e.g., `Application.FunctionalTests`). Name classes after the type under test plus the scenario (`TodoServiceTests`). Use `MethodName_State_ExpectedResult` for test methods. Maintain fast feedback by isolating acceptance tests behind the dedicated project. When adding features, extend coverage in the matching test project and ensure failures reproduce the reported issue before fixing.

## Commit & Pull Request Guidelines
Write imperative, present-tense subject lines under 72 characters (e.g., `Add enrollment progress summary`). Reference issues in the body with `Fixes #123` when applicable. Each PR should describe scope, testing performed, and any follow-up tasks; attach screenshots or API samples if behavior changes. Keep commits focused on a single concern and ensure all builds and impacted test suites pass locally before requesting review.
