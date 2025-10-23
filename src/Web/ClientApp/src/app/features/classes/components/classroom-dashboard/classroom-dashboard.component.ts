import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import { ClassroomDetailsDto } from '@app/data-access/api/api-client';
import { ClassroomDashboardPeopleComponent } from './classroom-dashboard-people.component';

@Component({
  selector: 'app-classroom-dashboard',
  standalone: true,
  imports: [ClassroomDashboardPeopleComponent],
  templateUrl: './classroom-dashboard.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClassroomDashboardComponent {
  readonly classroom = input.required<ClassroomDetailsDto>();
  readonly classroomName = computed(() => this.classroom().name ?? 'Classroom');
  readonly description = computed(() => this.classroom().description ?? 'No description provided.');
  readonly createdOn = computed(() => this.classroom().createdOn ?? null);
  readonly teachers = computed(() => this.classroom().teachers ?? []);
  readonly students = computed(() => this.classroom().students ?? []);
}
