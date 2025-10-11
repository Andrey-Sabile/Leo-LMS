import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import type { WeekViewVm } from './week-view.models';

/**
 * Basic shape for calendar events used by the week view.
 * Extend or replace with the real DTO once available.
 */
@Component({
  selector: 'app-calendar-week-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './calendar-week-view.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarWeekViewComponent {
  vm = input.required<WeekViewVm>();
}
