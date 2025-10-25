import { ChangeDetectionStrategy, Component, computed, signal, inject, effect } from '@angular/core';
import { SimpleCalendarDayComponent } from './simple-calendar-day/simple-calendar-day.component';
import { SimpleCalendarWeekComponent } from './simple-calendar-week/simple-calendar-week.component';
import { SimpleCalendarMonthComponent } from './simple-calendar-month/simple-calendar-month.component';
import { CalendarEventsClient, CalendarEventBriefDto } from '@app/data-access/api/api-client';
import { CalendarDateRange } from '../../models/simple-calendar-view.models';
type viewModes = 'day' | 'week' | 'month';

@Component({
  selector: 'app-simple-calendar',
  imports: [SimpleCalendarDayComponent, SimpleCalendarWeekComponent, SimpleCalendarMonthComponent],
  templateUrl: './simple-calendar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class SimpleCalendarComponent {
  private calendarEventsClient = inject(CalendarEventsClient);

  readonly activeViewMode = signal<viewModes>('day');
  readonly anchorDay = signal(new Date()); // Default: Today
  readonly viewTabs: ReadonlyArray<{ mode: viewModes; label: string }> = [
    { mode: 'day', label: 'Day' },
    { mode: 'week', label: 'Week' },
    { mode: 'month', label: 'Month' },
  ];

  readonly calendarEvents = signal<CalendarEventBriefDto[]>([]);

  setActiveView(mode: viewModes): void {
    if (this.activeViewMode() === mode) return;
    this.activeViewMode.set(mode);
  }

  readonly currentDateRange = computed(() =>
    this.resolveDateRange(this.activeViewMode(), this.anchorDay())
  );

  // Returns the date range of the current view mode
  private resolveDateRange(viewMode: viewModes, referenceDate: Date): CalendarDateRange {
    switch (viewMode) {
      case 'day':
        return this.getDayRange(referenceDate)
      case 'week':
        return this.getWeekRange(referenceDate);
      case 'month':
        return this.getMonthRange(referenceDate);

    }
  }

  private getDayRange(referenceDate: Date): CalendarDateRange {
    const start = new Date(referenceDate);
    start.setHours(0, 0, 0, 0);
    const end = new Date(referenceDate);
    end.setHours(23, 59, 59, 999);
    return { start, end };
  }

  private getWeekRange(referenceDate: Date): CalendarDateRange {
    const day = (referenceDate.getDay() + 6) % 7; // 0 = Monday, ..., 6 = Sunday

    const start = new Date(referenceDate);
    start.setDate(referenceDate.getDate() - day);
    start.setHours(0, 0, 0, 0);

    const end = new Date(start);
    end.setDate(start.getDate() + 6);
    end.setHours(23, 59, 59, 999);

    return { start, end };
  }

  private getMonthRange(referenceDate: Date): CalendarDateRange {
    const start = new Date(referenceDate.getFullYear(), referenceDate.getMonth(), 1);
    start.setHours(0, 0, 0, 0);

    const end = new Date(referenceDate.getFullYear(), referenceDate.getMonth() + 1, 0); // last day of month
    end.setHours(23, 59, 59, 999);

    return { start, end };
  }

  private shiftAnchorDate(direction: 1 | -1): void {
    const updatedAnchorDate = new Date(this.anchorDay());
    switch (this.activeViewMode()) {
      case 'day':
        updatedAnchorDate.setDate(updatedAnchorDate.getDate() + direction);
        break;

      case 'week':
        updatedAnchorDate.setDate(updatedAnchorDate.getDate() + direction * 7);
        break;

      case 'month': {
        const originalDay = updatedAnchorDate.getDate();
        updatedAnchorDate.setDate(1);
        updatedAnchorDate.setMonth(updatedAnchorDate.getMonth() + direction);
        const daysInTargetMonth = new Date(
          updatedAnchorDate.getFullYear(),
          updatedAnchorDate.getMonth() + 1,
          0
        ).getDate();
        updatedAnchorDate.setDate(Math.min(originalDay, daysInTargetMonth));
        break;
      }
    }

    this.anchorDay.set(updatedAnchorDate);
  }

  goToNextRange(): void {
    this.shiftAnchorDate(1);
  }

  goToPreviousRange(): void {
    this.shiftAnchorDate(-1);
  }

  goToToday(): void {
    this.resetAnchorDate();
  }

  private resetAnchorDate(): void {
    this.anchorDay.set(new Date());
  }

  private formatDate(date: Date, options: Intl.DateTimeFormatOptions): string {
    return new Intl.DateTimeFormat('en-US', options).format(date);
  }

  private readonly refreshEvents = effect(() => {
    const range = this.currentDateRange();
    this.loadCalendarEvents(range);
    { allowSignalWrites: true }

  });

  private loadCalendarEvents(range: CalendarDateRange): void {
    this.calendarEventsClient
      .getCalendarEventsWithPagination(
        range.start,
        range.end,
        null,
        null,
        null,
        null,
        null,
        1,
        100
      )
      .subscribe({
        next: result => this.calendarEvents.set(result.items),
        error: error => console.error(error),
      });
  }


}
