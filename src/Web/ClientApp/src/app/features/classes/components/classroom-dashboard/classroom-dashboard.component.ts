import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ClassroomDto } from '@app/data-access/api/api-client';

@Component({
  selector: 'app-classroom-dashboard',
  standalone: true,
  imports: [RouterLink, DatePipe],
  templateUrl: './classroom-dashboard.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ClassroomDashboardComponent {
  readonly classroom = input.required<ClassroomDto>();
  readonly classroomName = computed(() => this.classroom().name ?? 'Classroom');
}
