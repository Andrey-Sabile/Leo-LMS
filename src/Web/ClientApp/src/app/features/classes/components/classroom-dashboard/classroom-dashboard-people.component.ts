import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import { ClassroomStudentDto, ClassroomTeacherDto } from '@app/data-access/api/api-client';
import { provideIcons, NgIcon } from '@ng-icons/core';
import { heroUserPlus, heroEllipsisVertical } from '@ng-icons/heroicons/outline';

@Component({
  selector: 'app-classroom-dashboard-people',
  templateUrl: './classroom-dashboard-people.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush,
  viewProviders: [provideIcons({ heroUserPlus, heroEllipsisVertical })],
  imports: [NgIcon]
})

export class ClassroomDashboardPeopleComponent {
  readonly teachers = input.required<readonly ClassroomTeacherDto[]>();
  readonly students = input.required<readonly ClassroomStudentDto[]>();

  readonly teacherCount = computed(() => this.teachers().length);
  readonly studentCount = computed(() => this.students().length);
}
