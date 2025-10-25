import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import { CalendarEventBriefDto } from '@app/data-access/api/api-client';
import { CalendarDateRange } from '@app/features/simple-calendar/models/simple-calendar-view.models';
import { SimpleCalendarDayComponent } from '../simple-calendar-day/simple-calendar-day.component';


@Component({
  selector: 'app-simple-calendar-week',
  imports: [SimpleCalendarDayComponent],
  templateUrl: './simple-calendar-week.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styles: ``
})
export class SimpleCalendarWeekComponent {
  readonly calendarEvents = input.required<CalendarEventBriefDto[]>();
  readonly dateRange = input.required<CalendarDateRange>();

  // Array of 7 CalendarDateRange objects representing each day in the week view
  readonly dayRanges = computed(() => {
    const range = this.dateRange();
    const start = new Date(range.start);
    start.setHours(0, 0, 0, 0);

    const ranges: CalendarDateRange[] = [];
    for (let i = 0; i < 7; i++) {
      const dayStart = new Date(start);
      dayStart.setDate(start.getDate() + i);
      dayStart.setHours(0, 0, 0, 0);

      const dayEnd = new Date(dayStart);
      dayEnd.setHours(23, 59, 59, 999);

      ranges.push({ start: dayStart, end: dayEnd });
    }

    return ranges;
  });

  readonly calendarEventsByDay = computed(() => {
    const events = this.calendarEvents() ?? [];
    const ranges = this.dayRanges();

    const buckets: CalendarEventBriefDto[][] = ranges.map(() => []);

    for (const ev of events) {
      if (!ev.start) continue;

      const evStart = ev.start;
      const evEnd = ev.end ?? ev.start;

      for (let i = 0; i < ranges.length; i++) {
        const r = ranges[i];
        if (evStart <= r.end && evEnd >= r.start) {
          buckets[i].push(ev);
        }
      }
    }

    for (const bucket of buckets) {
      bucket.sort((a, b) => (a.start?.getTime() ?? 0) - (b.start?.getTime() ?? 0));
    }

    return buckets;
  });

}
