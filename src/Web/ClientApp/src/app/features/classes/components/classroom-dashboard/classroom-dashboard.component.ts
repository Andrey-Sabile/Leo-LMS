import { ChangeDetectionStrategy, Component, computed, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClassroomDetailsDto, ClassroomsClient } from '@app/data-access/api/api-client';
import { toSignal } from '@angular/core/rxjs-interop';
import { catchError, filter, map, of, switchMap } from 'rxjs';
import { ClassroomDashboardPeopleComponent } from './classroom-dashboard-people.component';

@Component({
  selector: 'app-classroom-dashboard',
  imports: [ClassroomDashboardPeopleComponent],
  templateUrl: './classroom-dashboard.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClassroomDashboardComponent {
  private readonly classroomsClient = inject(ClassroomsClient);
  private readonly activatedRoute = inject(ActivatedRoute);

  private readonly classroom = toSignal(
    this.activatedRoute.paramMap.pipe(
      map(params => params.get('id')),
      filter((id): id is string => id !== null && id.trim().length > 0),
      map(id => Number.parseInt(id, 10)),
      filter((id): id is number => !Number.isNaN(id)),
      switchMap(id =>
        this.classroomsClient.getClassroomDetails(id).pipe(
          catchError(error => {
            console.error('Failed to load classroom details.', error);
            return of<ClassroomDetailsDto | null>(null);
          })
        )
      )
    ),
    { initialValue: null }
  );

  readonly classroomName = computed(() => this.classroom()?.name ?? 'Classroom');
  readonly description = computed(() => this.classroom()?.description ?? 'No description provided.');
  readonly createdOn = computed(() => this.classroom()?.createdOn ?? null);
  readonly teachers = computed(() => this.classroom()?.teachers ?? []);
  readonly students = computed(() => this.classroom()?.students ?? []);
  readonly classroomId = computed(() => this.classroom()?.id ?? null);
}
