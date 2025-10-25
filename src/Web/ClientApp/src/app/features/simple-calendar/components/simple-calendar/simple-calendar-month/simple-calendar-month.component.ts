import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import { CalendarEventBriefDto } from '@app/data-access/api/api-client';
import { CalendarDateRange } from '@app/features/simple-calendar/models/simple-calendar-view.models';
import { SimpleCalendarDayComponent } from '../simple-calendar-day/simple-calendar-day.component';

@Component({
  selector: 'app-simple-calendar-month',
  imports: [SimpleCalendarDayComponent],
  templateUrl: './simple-calendar-month.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styles: ``
})
export class SimpleCalendarMonthComponent {
  readonly calendarEvents = input.required<CalendarEventBriefDto[]>();
  readonly dateRange = input.required<CalendarDateRange>();

  // Array of CalendarDateRange objects for every day in the month represented by `dateRange`.
  readonly dayRanges = computed(() => {
    const range = this.dateRange();
    // normalize to the first day of the month at 00:00
    const monthStart = new Date(range.start.getFullYear(), range.start.getMonth(), 1);
    monthStart.setHours(0, 0, 0, 0);

    const daysInMonth = new Date(monthStart.getFullYear(), monthStart.getMonth() + 1, 0).getDate();

    const ranges: CalendarDateRange[] = [];
    for (let i = 0; i < daysInMonth; i++) {
      const dStart = new Date(monthStart);
      dStart.setDate(monthStart.getDate() + i);
      dStart.setHours(0, 0, 0, 0);

      const dEnd = new Date(dStart);
      dEnd.setHours(23, 59, 59, 999);

      ranges.push({ start: dStart, end: dEnd });
    }

    return ranges;
  });

  // For each day in `dayRanges`, a bucket of events that intersect that day.
  readonly calendarEventsByDay = computed(() => {
    const events = this.calendarEvents() ?? [];
    const ranges = this.dayRanges();
    const buckets: CalendarEventBriefDto[][] = ranges.map(() => []);

    if (ranges.length === 0) return buckets;

    const monthStart = ranges[0].start;
    const monthEnd = ranges[ranges.length - 1].end;
    const msPerDay = 24 * 60 * 60 * 1000;

    for (const ev of events) {
      if (!ev.start) continue;

      const evStart = ev.start;
      const evEnd = ev.end ?? ev.start;

      // skip events that don't intersect the month
      if (evEnd < monthStart || evStart > monthEnd) continue;

      const clampedStart = evStart < monthStart ? new Date(monthStart) : new Date(evStart);
      const clampedEnd = evEnd > monthEnd ? new Date(monthEnd) : new Date(evEnd);

      const firstIndex = Math.floor((clampedStart.getTime() - monthStart.getTime()) / msPerDay);
      const lastIndex = Math.floor((clampedEnd.getTime() - monthStart.getTime()) / msPerDay);

      const startIdx = Math.max(0, firstIndex);
      const endIdx = Math.min(ranges.length - 1, lastIndex);

      for (let i = startIdx; i <= endIdx; i++) {
        buckets[i].push(ev);
      }
    }

    // sort events in each day by start time
    for (const bucket of buckets) {
      bucket.sort((a, b) => (a.start?.getTime() ?? 0) - (b.start?.getTime() ?? 0));
    }

    return buckets;
  });

}
