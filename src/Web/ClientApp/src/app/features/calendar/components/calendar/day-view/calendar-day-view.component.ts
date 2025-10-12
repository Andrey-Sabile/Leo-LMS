import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import type { DayVm } from '../calendar-view.models';

@Component({
  selector: 'app-calendar-day-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './calendar-day-view.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarDayViewComponent {
  vm = input.required<DayVm>();
}
