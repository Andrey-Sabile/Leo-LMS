import { ChangeDetectionStrategy, Component, DestroyRef, computed, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ClassroomDto, ClassroomsClient } from '@app/data-access/api/api-client';
import { finalize } from 'rxjs/operators';
import { catchError, map, of } from 'rxjs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-classes',
  imports: [RouterLink],
  templateUrl: './classes.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClassesComponent {
  private readonly classroomsClient = inject(ClassroomsClient);
  private readonly destroyRef = inject(DestroyRef);
  private readonly router = inject(Router);

  readonly classrooms = signal<ClassroomDto[]>([]);
  readonly searchQuery = signal('');
  readonly loadError = signal<string | null>(null);
  readonly isLoading = signal(false);

  readonly filteredClassrooms = computed(() => {
    const searchTerm = this.searchQuery().trim().toLowerCase();
    const classrooms = this.classrooms();
    if (!searchTerm) {
      return classrooms;
    }

    return classrooms.filter(classroom => {
      const name = classroom.name?.toLowerCase() ?? '';
      const description = classroom.description?.toLowerCase() ?? '';
      return name.includes(searchTerm) || description.includes(searchTerm);
    });
  });

  constructor() {
    this.loadClassrooms();
  }

  onSearchChange(value: string): void {
    this.searchQuery.set(value);
  }

  onSearchSubmit(value: string): void {
    this.searchQuery.set(value);
  }

  private loadClassrooms(): void {
    this.isLoading.set(true);
    this.loadError.set(null);

    this.classroomsClient
      .getClassrooms()
      .pipe(
        map(response => response.classrooms ?? []),
        catchError(error => {
          console.error('Failed to load classrooms.', error);
          this.loadError.set('Unable to load classrooms. Please try again.');
          return of<ClassroomDto[]>([]);
        }),
        finalize(() => {
          this.isLoading.set(false);
        }),
        takeUntilDestroyed(this.destroyRef)
      )
      .subscribe(classrooms => {
        this.classrooms.set(classrooms);
      });
  }

  navigateToCreateClass(): void {
    this.router.navigate(['/classes', 'create']);
  }
}
