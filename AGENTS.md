# Repository Guidelines

## Project Structure & Module Organization
LeoLMS mirrors the Clean Architecture layout referenced in `README.md`. Core code sits in `src/`: `Application` holds CQRS handlers, `Domain` models business types, `Infrastructure` connects persistence and other services, and `Web` hosts the ASP.NET Core UI. Tests live under `tests/` with unit, integration, functional, and acceptance suites; deployment scripts reside in `infra/`, and CI outputs land in `artifacts/`.

## Build, Test, and Development Commands
- `dotnet build -tl` — compile the entire solution with MSBuild task summary.
- `cd src/Web && dotnet watch run` — start the web UI with hot reload on https://localhost:5001.
- `dotnet test --filter "FullyQualifiedName!~AcceptanceTests"` — execute unit, integration, and functional suites.
- `cd src/Web && dotnet run` (in one terminal) plus `dotnet test` (in another) — run acceptance tests against a live instance.
Use `build.cake` targets when aligning with CI expectations; keep generated artifacts in `artifacts/`.

## Coding Style & Naming Conventions
Respect the solution-wide `.editorconfig`: C# files use four-space indentation and UTF-8 encoding. Apply PascalCase for classes, records, and public members; camelCase for locals and parameters; suffix async methods with `Async`. Run `dotnet format` before pushing to enforce whitespace, analyzer, and naming rules defined by the template.

## Testing Guidelines
Tests are written with xUnit and FluentAssertions. Name test projects `<Area>.<TestType>Tests` and test classes `<Subject>Tests`. Acceptance tests depend on a running web app; keep them idempotent and label any long-running scenarios with `[Trait("Category", "Acceptance")]` for filtering. For new scenarios, place integration tests beside the feature in `Infrastructure.IntegrationTests` and reuse existing fixtures.

## Commit & Pull Request Guidelines
Follow the existing Conventional Commits style seen in `git log` (`feat:`, `refactor:`, `chore:`). Each commit should be scoped to a single change to ease review and potential revert. Pull requests need a summary of changes, validation steps (commands run), and links to related issues or work items. Attach screenshots or GIFs when altering UI behavior, and note any configuration or migration steps required for deployment.

## Tooling & Scaffolding Tips
The solution ships with the Clean Architecture scaffolding templates. From `src/Application`, generate new use cases with commands such as:
```bash
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```
Keep generated files aligned with the feature module structure and update corresponding tests in `tests/Application.*`.
