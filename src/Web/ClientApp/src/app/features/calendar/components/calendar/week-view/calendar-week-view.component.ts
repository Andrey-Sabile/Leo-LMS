import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { CalendarEventBriefDto } from '@app/data-access/api/api-client';
import type { CalendarDateRange } from '../calendar.component';

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
  @Input({ required: true }) dateRange!: CalendarDateRange;
  @Input({ required: true }) events!: CalendarEventBriefDto[];
}
