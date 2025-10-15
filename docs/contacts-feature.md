# Contacts Feature Vertical Slice

Documentation for implementing a contacts vertical slice that spans the Domain, Application, Infrastructure, and Web projects plus the Angular/DaisyUI frontend. The feature is the source of truth for student and guardian (parent/guardian) contact information.

---

## Feature Goals & Scope

- Allow teachers and staff to manage student records with one or more guardians.
- Capture for each student: full name, 8-digit public-facing student ID, and a home address independent of guardian addresses.
- Capture for each guardian: full name, email, primary phone number, mailing address, optional relationship label, and associated students.
- Support assigning existing guardians to new students and updating guardian details once so changes propagate to all linked students.
- Provide CRUD operations for students and guardians with soft-deletion semantics.
- Expose a paginated & searchable student list (search by student name) with guardian details.
- Mirror the Calendar feature’s architectural patterns (Clean Architecture folders, Minimal API endpoint group, NSwag client generation, Angular standalone component with signals and DaisyUI table styling).

Non-goals for this slice (document but defer):
- Authorization rules (teachers vs. staff).
- Notification workflows or external integrations.
- Bulk import/export.

---

## Domain Design

### Aggregate & Entities

- **Student (Aggregate Root)** – derives from `BaseAuditableEntity`.
  - Properties: `Id`, `StudentId` (string, exactly 8 numeric chars, unique), `FullName`, `Address` (owned value object), `IsDeleted`, `DeletedOn`.
  - Navigation: `ICollection<StudentGuardian>` (backing field with read-only projection).
  - Behaviors:
    - Factory `Create` enforces non-empty name, valid student ID, at least one guardian link supplied.
    - Methods to update name/address, assign guardians, remove guardians, perform soft delete/restore.
    - Guard against removing the final guardian association.

- **Guardian** – also derives from `BaseAuditableEntity`.
  - Properties: `Id`, `FullName`, `Email`, `PhoneNumber`, `Address` (owned value object), `Notes` (optional), `IsDeleted`, `DeletedOn`.
  - Navigation: `ICollection<StudentGuardian>`.
  - Behaviors:
    - Factory & update methods to validate email format and phone number presence.
    - Soft delete / restore.

- **StudentGuardian (Join Entity)** – inherits from `BaseAuditableEntity` (for auditing) or `BaseEntity` if audit not required.
  - Properties: `StudentId`, `GuardianId`, `Relationship` (e.g., “Mother”, “Guardian”), `PreferredContactOrder` (optional int), `IsPrimaryContact` (bool default false).
  - Keys: Composite primary key `(StudentId, GuardianId)`.
  - Soft delete not required separately if handled via parent soft deletes; otherwise include `IsDeleted`.

### Value Objects

- **StudentAddress** – owned by `Student`, fields: `Street1`, `Street2`, `City`, `State`, `PostalCode`, `Country`. Require `Street1`, `City`, `State`, `PostalCode`.
- **GuardianAddress** – identical shape; use a shared value object (e.g., `PostalAddress`) to avoid duplication. Mark as owned type for both entities.
- **GuardianContactInfo** optional if separating contact concerns; otherwise keep email/phone on entity.

### Invariants & Business Rules

- Student IDs must be unique, exactly 8 digits (`^\d{8}$`).
- Student must maintain at least one active guardian link.
- Guardian email required and unique per guardian (case-insensitive). Allow sharing guardians across students.
- Phone number required; apply E.164-like validation or simple numeric length check (documented to refine later).
- Soft-deleted students/guardians excluded from default queries while preserving audit columns.
- Restoring a student automatically restores associated join entries; if guardian is soft-deleted separately, it remains inactive until restored explicitly.

### Domain Events (optional enhancements)

- `StudentCreatedEvent` to notify future integrations.
- `GuardianUpdatedEvent` to trigger notifications when contact info changes.
- Document but defer handler implementations unless required.

---

## Application Layer

Place implementation under `src/Application/Contacts` with subfolders `Commands`, `Queries`, and feature-specific DTOs. Reuse the established CQRS + MediatR pattern.

### Commands

1. **CreateStudentCommand : IRequest<int>**
   - Payload: `StudentId`, `FullName`, `StudentAddressDto`, `ICollection<GuardianAssignmentRequest>`.
   - `GuardianAssignmentRequest` supports either new guardian creation (`GuardianForCreateDto`) or linking an existing guardian by `GuardianId`.
   - Handler responsibilities:
     - Validate student ID uniqueness via context query (consider `AnyAsync`).
     - For new guardians, instantiate `Guardian` entity; for existing, load and ensure not soft-deleted.
     - Create join entities with relationship metadata.
     - Ensure at least one guardian association before persisting.
   - Return: newly created student numeric ID.

2. **UpdateStudentCommand : IRequest**
   - Payload: Student keys, updated name, address, guardian assignments collection (with ability to add/remove/reorder guardians).
   - Handler: Load aggregate (include guardians), apply domain methods, manage join entity additions/removals, enforce invariants.

3. **SoftDeleteStudentCommand : IRequest**
   - Marks `IsDeleted` and `DeletedOn`; optionally cascades to join table entries.

4. **RestoreStudentCommand : IRequest**
   - Clears `IsDeleted` and `DeletedOn`, reactivates join entries.

5. **UpdateGuardianCommand : IRequest**
   - Allows editing guardian contact info independent of student updates.
   - Ensure updates cascade naturally; return void.

6. **SoftDeleteGuardianCommand / RestoreGuardianCommand**
   - Soft delete guardians; leave student record accessible but flag guardians as inactive. Update queries to filter out inactive guardians from active students.

7. (Optional) **SearchGuardiansQueryHandler** to support selecting existing guardians from UI.

### Queries & DTOs

1. **GetStudentsWithPaginationQuery : IRequest<PaginatedList<StudentListItemDto>>**
   - Parameters: `Search` (string), `PageNumber`, `PageSize`.
   - Handler:
     - Start with `_context.Students.Where(s => !s.IsDeleted)`.
     - Apply search on `FullName` (case-insensitive). Consider indexing later.
     - Include guardians: project to DTO using AutoMapper `ProjectTo`.
     - Order by `FullName`.
   - Return `PaginatedList<StudentListItemDto>` with guardians summary (e.g., names + primary contact flags).

2. **GetStudentDetailQuery : IRequest<StudentDetailDto>**
   - Loads full student details including address and guardian list (with contact info) for view/edit.

3. **GetGuardianDetailQuery** for dedicated guardian edit surfaces.

4. **GetGuardiansLookupQuery : IRequest<IReadOnlyCollection<GuardianLookupDto>>**
   - Supports UI search-as-you-type when linking existing guardians.

### Validation

- Use FluentValidation under `Commands/...Validator.cs`.
  - `CreateStudentCommandValidator` checks name non-empty, student ID regex, address required fields, at least one guardian.
  - `GuardianForCreateDtoValidator` to confirm email format (`EmailAddress()`), phone not empty.
  - For update commands, ensure guardians collection not empty after removals.
- Add `GetStudentsWithPaginationQueryValidator` to enforce `PageNumber >= 1`, `1 <= PageSize <= 100`.

### Mapping

- Extend AutoMapper profiles in `Application/Common/Mappings` or create `ContactsProfile`.
- Map domain entities to DTOs, flattening value objects (address).
- Ensure join entity data is projected to appropriate DTOs for table view (e.g., `PrimaryGuardianName`, `GuardianCount`).

### Services & Helpers

- Extend `IApplicationDbContext` with `DbSet<Student> Students { get; }`, `DbSet<Guardian> Guardians { get; }`, `DbSet<StudentGuardian> StudentGuardians { get; }`.
- Create helper method for `PaginatedList` extension if necessary: `PaginatedListAsync`.
- Consider using `SplitQuery` or `AsNoTracking` for read queries to avoid cartesian explosion.

---

## Infrastructure Layer

### Entity Framework Configuration

1. **DbContext**
   - Add `DbSet<Student>`, `DbSet<Guardian>`, `DbSet<StudentGuardian>` to `ApplicationDbContext`.
   - Register entity configurations via `Configurations` folder.

2. **Configurations (IEntityTypeConfiguration)**
   - `StudentConfiguration`:
     - Table name `Students`.
     - `StudentId` required, max length 8, unique index (`HasIndex(...).IsUnique()`).
     - Configure owned `Address` with column names (e.g., `Address_Street1`).
     - Global query filter `builder.HasQueryFilter(s => !s.IsDeleted)`.
     - Configure navigation to `StudentGuardians` with cascade delete disabled (soft delete is manual).
   - `GuardianConfiguration` similar, unique index on email, owned address, query filter for soft deletes.
   - `StudentGuardianConfiguration`:
     - Composite key, `Relationship` max length 64, `PreferredContactOrder` optional.
     - Configure relationships: `.HasOne(sg => sg.Student).WithMany(s => s.Guardians).HasForeignKey(sg => sg.StudentId)` etc.

3. **Soft Delete Infrastructure**
   - Introduce interface `ISoftDelete` with `bool IsDeleted`, `DateTimeOffset? DeletedOn`.
   - Optionally implement a `SoftDeleteInterceptor` that converts `Delete` operations to state modifications (or handle in domain methods only).
   - Update `AuditableEntityInterceptor` to set `DeletedOn` when `IsDeleted` toggled if necessary.

4. **Migrations**
   - Generate new migration after updating domain/infrastructure.
   - Migration should create `Students`, `Guardians`, and `StudentGuardians` tables plus indices.
   - Ensure cascade rules: deleting guardian should cascade remove join rows, but since we soft delete, configure `OnDelete(DeleteBehavior.NoAction)` and rely on soft delete logic.
   - Update `ApplicationDbContextInitialiser` if seeding scenarios needed (e.g., sample data).

5. **Data Access Patterns**
   - Use `AsSplitQuery()` when eager loading guardians to avoid duplication (EF Core recommended).
   - Ensure `PaginatedList.CreateAsync` works with projections; apply `ProjectTo` before pagination.

---

## Web API (Minimal APIs)

- Create new endpoint group `Contacts` under `src/Web/Endpoints/Contacts.cs`.
- Base path: `/api/Contacts` (automatically determined by `EndpointGroupBase`).

### Proposed Routes

| Verb | Route | Notes |
|------|-------|-------|
| GET | `/api/Contacts` | Accepts `search`, `pageNumber`, `pageSize`. Returns `PaginatedList<StudentListItemDto>`. Mirrors pattern in `CalendarEvents.GetCalendarEventsWithPagination`. |
| GET | `/api/Contacts/{id:int}` | Returns detailed student DTO including guardians. 404 if student missing or soft-deleted. |
| POST | `/api/Contacts` | Accepts `CreateStudentCommand` | returns `201 Created` with student ID. |
| PUT | `/api/Contacts/{id:int}` | Accepts `UpdateStudentCommand`, ensures route ID matches command. Returns `204 NoContent`. |
| DELETE | `/api/Contacts/{id:int}` | Triggers soft delete command. Returns `204`. |
| POST | `/api/Contacts/{id:int}/restore` | Restores a soft-deleted student. |
| GET | `/api/Contacts/guardians` | Query param `search`. Returns lightweight guardian lookup list. |
| GET | `/api/Contacts/guardians/{id:int}` | Detailed guardian view (optional). |
| PUT | `/api/Contacts/guardians/{id:int}` | Update guardian info. |
| DELETE | `/api/Contacts/guardians/{id:int}` | Soft delete guardian. |
| POST | `/api/Contacts/guardians/{id:int}/restore` | Restore guardian. |

- Use `.RequireAuthorization()` placeholders; actual policies configured later.
- For soft delete results, return 404 when requesting deleted entities unless client opts into `includeDeleted`.

### Request/Response Contracts

- Reuse command records for POST/PUT to avoid duplication.
- DTO shapes for list/detail responses should flatten addresses for ease of consumption.
  - Example `StudentListItemDto`: `{ id, studentId, fullName, addressSummary, guardianCount, primaryGuardianName, guardians: GuardianSummaryDto[] }`.
  - `GuardianSummaryDto`: `{ id, fullName, relationship, email, phoneNumber, isPrimaryContact }`.

### Error Handling

- Validation failures bubble through `ValidationException` pipeline. Ensure consistent problem details responses.
- `404 NotFound` for missing/soft-deleted resources.

### OpenAPI & NSwag

- Update `OpenApiDocument.cs` (if present) or run `dotnet build` to regenerate swagger.
- Regenerate Angular client using existing `nswag.json` or `npm run api-client` script (check project’s standard command).
- Commit regenerated `api-client.ts` alongside backend changes.

---

## Angular Frontend Implementation

Feature lives under `src/Web/ClientApp/src/app/features/contacts`.

### Routing & Structure

- Add a lazy-loaded route entry in `src/Web/ClientApp/src/app/app.routes.ts` (follow calendar route pattern).
- Feature directory structure:
  ```
  features/contacts/
    components/
      contacts-page/contacts-page.component.{ts,html}
      contacts-table/contacts-table.component.{ts,html}
      student-detail-drawer/student-detail-drawer.component.{ts,html}
      student-form-modal/student-form-modal.component.{ts,html}
      guardian-picker/guardian-picker.component.{ts,html}
    services/
      contacts.store.ts  (signals-based state holder)
    models/
      contacts.view-models.ts
  ```
- Components should be standalone, use `ChangeDetectionStrategy.OnPush`, leverage Angular signals for state.

### Data Access

- After backend swagger update, NSwag generates `ContactsClient` similar to `CalendarEventsClient`.
- Compose a `ContactsStore` service that wraps API client calls, maintains signals:
  - `searchTerm = signal('')`, `pageSize = signal(20)`, `pageNumber = signal(1)`.
  - `students = signal<StudentListItemDto[]>([])`, `totalCount`, `isLoading`.
  - Effects: when search/page change, call `contactsClient.getStudentsWithPagination(...)`.

### Page Layout (DaisyUI + Tailwind)

- Follow calendar layout with header containing:
  - Title “Contacts”.
  - Search input (daisyUI `input input-bordered`) with debounced updates to store.
  - “Add Student” button (`btn btn-primary`) opening modal.
- Main content: card container `div` with `rounded-box border border-base-200 bg-base-100 p-4`.
- Within card, a responsive table using:
  ```html
  <div class="overflow-x-auto">
    <table class="table">
      <thead>...</thead>
      <tbody>
        @for (student of students()) {
          <tr (click)="selectStudent(student)">
            <td>
              <div class="font-medium">{{ student.fullName }}</div>
              <div class="text-sm text-base-content/70">{{ student.studentId }}</div>
            </td>
            <td>
              <div class="flex flex-wrap gap-2">
                @for (guardian of student.guardians) {
                  <span class="badge badge-outline">{{ guardian.fullName }}</span>
                }
              </div>
            </td>
            <td class="text-right">
              <button type="button" class="btn btn-ghost btn-sm" (click)="editStudent(student, $event)">Edit</button>
            </td>
          </tr>
        }
      </tbody>
    </table>
  </div>
  ```
- Incorporate pagination controls (daisyUI `join` buttons) mirroring calendar navigation.

### Student Create/Edit Modal

- Use daisyUI `modal` or `dialog` component for forms.
- Form fields:
  - Student name, student ID (input with pattern `\d{8}`).
  - Address fields grouped.
  - Guardians section:
    - Search existing guardians (auto-complete) via `GuardianPickerComponent`.
    - Chip list showing selected guardians with ability to mark primary, set relationship.
    - Button to open guardian creation inline (modal inside modal or drawer).
- Use Angular Reactive Forms (`FormBuilder`, but maintain values in signals for view state).

### Guardian Management UI

- Provide drawer or side panel showing guardian details when selecting a row.
- Guardian edit modal reuses same form component; updates via `ContactsClient.updateGuardian`.
- When guardians soft-deleted, visually badge row (e.g., `badge badge-error`).

### State & Effects

- Example effect to load students:
  ```ts
  effect(() => {
    const term = this.searchTerm();
    const page = this.pageNumber();
    const size = this.pageSize();
    this.isLoading.set(true);
    this.contactsClient.getStudentsWithPagination(term, page, size).subscribe({
      next: result => {
        this.students.set(result.items);
        this.totalCount.set(result.totalCount);
        this.isLoading.set(false);
      },
      error: err => {
        this.isLoading.set(false);
        // TODO: surface toast notification
      },
    });
  });
  ```
- Use computed signals for derived state, e.g., `totalPages`, `hasNextPage`.
- For modals, use `signal<boolean>` toggles and pass `student`/`guardian` data via `signal<StudentDetailDto | null>`.

### UX Considerations

- Indicate soft-deleted students in UI (e.g., `badge badge-warning` with “Inactive”). Provide filter toggle `Include inactive`.
- When search yields no results, show `daisyUI` `alert` component.
- Keep layout responsive: table wraps on small screens, use `overflow-x-auto`.

---

## Testing Strategy

- **Domain.UnitTests**
  - Verify invariants: prevent invalid student IDs, enforce guardian requirement, ensure soft delete toggles `IsDeleted`.
  - Confirm address value object equality and validation.
- **Application.UnitTests**
  - Use `FakeApplicationDbContext` or `Testing` infrastructure to validate command/validator logic.
  - Test `CreateStudentCommand` handles new + existing guardians correctly.
  - `UpdateGuardianCommand` ensures persisted changes visible across students.
  - Query tests verifying pagination, search filtering, excludes soft-deleted entities.
- **Infrastructure.IntegrationTests**
  - Use in-memory or test container to assert EF mappings: unique constraints, query filters, owned types.
  - Round-trip creating student with guardians and verifying join table persisted.
- **Web.AcceptanceTests**
  - Add acceptance scenarios once UI is wired (requires running web host). For now, document placeholders.
- **Angular Tests**
  - Component test for `ContactsTableComponent` verifying rendering of guardians (use Angular testing harness).
  - Store tests using `jasmine-marbles` or manual to assert API call triggers.
  - E2E tests (Playwright) later to verify full workflow.

---

## Implementation Checklist

1. **Domain**
   - Add entities/value objects and domain methods.
   - Update `Domain.csproj` if additional packages required (e.g., for regex? typically not).
2. **Application**
   - Create commands, queries, DTOs, validators, mappings within `src/Application/Contacts`.
   - Register new AutoMapper profile if needed.
3. **Infrastructure**
   - Update `IApplicationDbContext` interface and `ApplicationDbContext`.
   - Add EF configurations and migration.
   - Implement query filters and ensure interceptors handle audit for soft delete.
4. **Web API**
   - Add `Contacts` endpoint group with routes and handlers.
   - Update dependency injection and ensure swagger includes new endpoints.
5. **NSwag Client**
   - Regenerate API clients (`dotnet build` or configured NSwag command).
   - Verify new `ContactsClient` is generated.
6. **Angular**
   - Scaffold feature folder, components, store, and routing entry.
   - Implement data fetching, search, pagination, modals, and forms using DaisyUI classes.
   - Wire guardian picker to API lookup endpoints.
7. **Testing**
   - Add unit/integration tests across layers.
   - Optionally scaffold Angular component tests or at least TODO placeholders.
8. **Validation**
   - Run `dotnet test --filter "FullyQualifiedName!~AcceptanceTests"` and relevant Angular lint/test commands.
   - Execute `dotnet format`.
9. **Documentation**
   - Update README or internal docs to mention new feature route/usage if needed.

---

## References

- Entity Framework Core documentation — many-to-many relationships (`/dotnet/entityframework.docs`, topic: “many-to-many relationships”).
- Angular v20 signals primitives (`/angular/angular/20.0.0`, topic: “signals computed effect”).
- Internal references: `src/Web/Endpoints/CalendarEvents.cs`, `src/Application/CalendarEvents/...`, `src/Web/ClientApp/.../calendar.component.*` for pattern alignment.

