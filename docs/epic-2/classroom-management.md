# Classroom Management Feature Slice

## Domain Layer
- Introduce `Subject` aggregate with fields `Id`, `Name`, `Code`, and `Description`; enforce unique `Code` and expose repository interface.
- Add `Classroom` aggregate capturing `Id`, `Name`, `Description`, `SubjectId`, `TeacherId`, `CreatedOn`, and placeholder member collection for future assignments; raise `ClassroomCreatedEvent`.
- Prepare domain specifications/validators for classroom naming and subject linkage to keep invariants explicit.

## Application Layer
- Implement subject CRUD handlers (commands, queries, validators) and projection DTOs mapped from domain models.
- Add `CreateClassroomCommand` handler validating subject existence and teacher ownership; emit domain event and leverage existing authorization pipeline for Admin/Teacher roles.
- Update mapping profiles and policies so new handlers integrate with mediator and role-based access checks.

## Infrastructure Layer
- Extend `ApplicationDbContext` with `DbSet<Subject>` and `DbSet<Classroom>` plus repository implementations.
- Provide EF configurations (unique index on `Subject.Code`, relationships for `SubjectId` and `TeacherId`) and generate migration creating both tables.
- Update service registration for new repositories and seed strategy for initial subject catalog if required.

## Web Layer
- Expose REST endpoints for subject CRUD and classroom creation; align request/response contracts with mediator handlers and apply Admin/Teacher authorization.
- Document endpoints (Swagger/OpenAPI) and prepare Angular client service stubs to consume subject list and classroom creation APIs, leaving UI screens for later slices.

## Testing Plan
- Domain unit tests covering `Subject` uniqueness and `Classroom` invariants.
- Application handler tests for subject CRUD and classroom creation (happy path, validation errors, authorization).
- EF integration tests verifying table mappings and persistence logic; API functional tests for new controllers.
- Document migration + test prerequisites in roadmap/release notes to keep cross-team visibility.
