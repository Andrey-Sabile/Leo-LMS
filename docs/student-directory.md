# student-directory.md

## Objectives
- Deliver Option A: a dedicated Student Directory application use case that serves a paged/searchable list and a student detail read model including guardians.
- Keep read concerns isolated from existing `Students` queries while reusing existing update commands where possible.
- Enable the Web layer to orchestrate edits for authorized users without leaking infrastructure concerns into the application layer.

## Assumptions
- Directory list responses must include guardian summaries alongside student data.
- Search must match on student first/last name and guardian first/last name.
- Paging/filter parameters should align with the patterns in `GetCalendarEventsWithPaginationQuery`.
- Existing commands (`UpdateStudentCommand`, guardian edits) remain the source of truth for write operations; a thin orchestration command may be introduced if edits need to span both aggregates atomically.

## Proposed Application Structure
- `Application/StudentDirectory/Queries/GetStudentDirectoryPage`
  - `GetStudentDirectoryPageQuery` record: properties for `Search`, `PageNumber`, `PageSize`, optional filters (placeholder for future expansion), plus an enum or flag for sort order if needed.
  - `GetStudentDirectoryPageQueryValidator`: reuse pagination rules from `GetCalendarEventsWithPaginationQueryValidator` and enforce non-empty search-length rules if required.
  - `StudentDirectoryListItemDto`: student id, full name, email, address summary, collection of `GuardianSummaryDto` (id, name, phone/email), and any display metadata.
  - `StudentDirectoryPageVm`: wraps `PaginatedList<StudentDirectoryListItemDto>` or equivalent.
  - Handler: compose EF Core query against `_context.Students` with `AsNoTracking()`, filter on search term using `EF.Functions.ILike`/`Contains` across student and guardian names, apply ordering, and call `.PaginatedListAsync(pageNumber, pageSize, cancellationToken)` after projecting via AutoMapper.

- `Application/StudentDirectory/Queries/GetStudentDirectoryDetail`
  - `GetStudentDirectoryDetailQuery` record with `StudentId`.
  - Validator ensuring `StudentId > 0`.
  - `StudentDirectoryDetailDto`: full student profile, guardians with contact/address details, plus any computed fields required by the UI.
  - Handler using `_context.Students.Where(s => s.Id == request.StudentId)` with `ProjectTo<StudentDirectoryDetailDto>` and `FirstOrDefaultAsync`, throwing `NotFoundException` when no match.

- Shared Mapping Profile
  - Add AutoMapper nested `Mapping` classes in DTOs mirroring existing patterns, or a dedicated `StudentDirectoryProfile` if mappings become extensive.
  - Ensure guardian projections reuse existing value-object to DTO conversions where practical.

- Optional Orchestration Command (for future edit consolidation)
  - Stub `UpdateStudentDirectoryEntryCommand` that accepts both student and guardian changes, delegating to existing commands or repository methods. Keep implementation minimal until UI requirements are concrete.

## Query Logic Details
- Search Implementation:
  - Normalize search term (trim/lowercase).
  - Apply combined predicate: `s.FirstName.Contains(term) || s.LastName.Contains(term) || s.Guardians.Any(g => g.FirstName.Contains(term) || g.LastName.Contains(term))`.
  - Consider splitting search into tokens to improve matching once requirements clarify; document trade-offs in handler comments.

- Paging & Sorting:
  - Default `PageNumber = 1`, `PageSize = 10` (matching calendar events); enforce minimum 1.
  - Default sort by student last name, first name; allow hook for future sort parameters.

- Projection:
  - Use `ProjectTo` to avoid loading full entities; ensure AutoMapper configuration includes guardian child collections and address value objects.
  - For list DTO guardian summaries, limit fields to those needed by the grid to keep payload compact.

## Validation & Authorization
- Apply `[Authorize]` attribute on queries via `AuthorizeAttribute` metadata or request pipeline behaviors, consistent with other secured queries.
- Extend `GetStudentDirectoryDetailQuery` to verify caller has access to student data if role-based rules exist (future placeholder).

## Tests
- Unit tests for both validators ensuring pagination rules and search requirements behave as expected.
- Application-layer handler tests (using in-memory DbContext or existing testing infrastructure) covering:
  - Search across student vs guardian names.
  - Paging boundaries (first page, last page).
  - Detail query not found scenario.
- Integration tests under `tests/Application.StudentDirectory.Queries` mirroring existing naming conventions.

## Sequencing
1. Scaffold `Application/StudentDirectory/Queries` folders and DTO shells.
2. Implement AutoMapper mappings and register profiles if needed.
3. Build list query + validator leveraging pagination helpers.
4. Build detail query + validator with not-found handling.
5. Add unit/integration tests.
6. Wire Web layer endpoints (new `StudentDirectory` endpoint group) once application layer is validated.
7. Evaluate necessity of orchestration command for edit flows after confirming UI contract.
