import { ChangeDetectionStrategy, Component, DestroyRef, computed, effect, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClassroomDetailsDto, ClassroomsClient } from '@app/data-access/api/api-client';
import { takeUntilDestroyed, toSignal } from '@angular/core/rxjs-interop';
import { filter, map } from 'rxjs';
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
  private readonly destroyRef = inject(DestroyRef);

  private readonly routeClassroomId = toSignal(
    this.activatedRoute.paramMap.pipe(
      map(params => params.get('id')),
      filter((id): id is string => id !== null && id.trim().length > 0),
      map(id => Number.parseInt(id, 10)),
      filter((id): id is number => !Number.isNaN(id))
    ),
    { initialValue: null }
  );

  private readonly classroomDetails = signal<ClassroomDetailsDto | null>(null);
  private readonly reloadVersion = signal(0);

  readonly classroomName = computed(() => this.classroomDetails()?.name ?? 'Classroom');
  readonly description = computed(() => this.classroomDetails()?.description ?? 'No description provided.');
  readonly createdOn = computed(() => this.classroomDetails()?.createdOn ?? null);
  readonly teachers = computed(() => this.classroomDetails()?.teachers ?? []);
  readonly students = computed(() => this.classroomDetails()?.students ?? []);
  readonly classroomId = computed(() => this.routeClassroomId());

  constructor() {
    effect(
      () => {
        const id = this.routeClassroomId();
        this.reloadVersion();

        if (id === null) {
          return;
        }

        this.fetchClassroomDetails(id);
      },
      { allowSignalWrites: true }
    );
  }

  handleTeacherAdded(): void {
    this.reloadVersion.update(version => version + 1);
  }

  handleStudentAdded(): void {
    this.reloadVersion.update(version => version + 1);
  }

  private fetchClassroomDetails(id: number): void {
    this.classroomsClient
      .getClassroomDetails(id)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: classroom => this.classroomDetails.set(classroom),
        error: error => {
          console.error('Failed to load classroom details.', error);
        }
      });
  }
}
