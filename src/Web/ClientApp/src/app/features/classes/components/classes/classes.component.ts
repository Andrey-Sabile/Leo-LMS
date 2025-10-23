import { ChangeDetectionStrategy, Component, computed, inject, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';
import { ClassroomDto, ClassroomsClient } from '@app/data-access/api/api-client';
import { catchError, map, of } from 'rxjs';

@Component({
  selector: 'app-classes',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './classes.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClassesComponent {
  private readonly classroomsClient = inject(ClassroomsClient);
  readonly classrooms = toSignal(
    this.classroomsClient.getClassrooms().pipe(
      map(response => response.classrooms ?? []),
      catchError(error => {
        console.error('Failed to load classrooms.', error);
        return of<ClassroomDto[]>([]);
      })
    ),
    { initialValue: [] }
  );
  readonly searchQuery = signal('');
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

  onSearchChange(value: string): void {
    this.searchQuery.set(value);
  }

  onSearchSubmit(value: string): void {
    this.searchQuery.set(value);
  }
}
