import { ChangeDetectionStrategy, Component, computed, effect, inject, signal } from '@angular/core';
import { CalendarDayViewComponent } from './day-view/calendar-day-view.component';
import { CalendarWeekViewComponent } from './week-view/calendar-week-view.component';
import { CalendarMonthViewComponent } from './month-view/calendar-month-view.component';
import type { WeekViewVm, DayVm, EventVm, MonthViewVm } from './calendar-view.models';
import { CalendarEventBriefDto, CalendarEventsClient } from '@app/data-access/api/api-client';

type CalendarViewMode = 'day' | 'week' | 'month';
export type CalendarDateRange = { start: Date; end: Date };

@Component({
  selector: 'app-calendar',
  standalone: true,
  imports: [CalendarDayViewComponent, CalendarMonthViewComponent, CalendarWeekViewComponent],
  templateUrl: './calendar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarComponent {
  private calendarEventsClient = inject(CalendarEventsClient);
  private readonly defaultViewMode = 'week';
  private readonly pageSize = 100;
  readonly viewMode = signal<CalendarViewMode>(this.defaultViewMode);
  readonly referenceDate = signal(new Date());
  readonly calendarEvents = signal<CalendarEventBriefDto[]>([]);
  readonly viewModeLabel = computed(() => {
    switch (this.viewMode()) {
      case 'day':
        return 'Day';
      case 'month':
        return 'Month';
      default:
        return 'Week';
    }
  });

  private readonly refreshEventsEffect = effect(
    () => {
      const range = this.currentDateRange();
      this.loadCalendarEvents(range);
    },
    { allowSignalWrites: true }
  );

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
        this.pageSize
      )
      .subscribe({
        next: result => this.calendarEvents.set(result.items),
        error: error => console.error(error),
      });
  }

  readonly currentDateRange = computed(() =>
    this.resolveDateRange(this.viewMode(), this.referenceDate())
  );

  private resolveDateRange(mode: CalendarViewMode, reference: Date): CalendarDateRange {
    switch (mode) {
      case 'day':
        return this.getDayRange(reference);
      case 'month':
        return this.getMonthRange(reference);
      default:
        return this.getWeekRange(reference);
    }
  }

  private getDayRange(reference: Date): CalendarDateRange {
    const start = this.startOfDay(reference);
    const end = this.endOfDay(start);
    return { start, end };
  }

  private getWeekRange(reference: Date): CalendarDateRange {
    const start = this.startOfWeek(reference);
    const end = this.endOfWeek(start);
    return { start, end };
  }

  private getMonthRange(reference: Date): CalendarDateRange {
    const start = new Date(reference.getFullYear(), reference.getMonth(), 1);
    const end = new Date(reference.getFullYear(), reference.getMonth() + 1, 0);
    return { start: this.startOfDay(start), end: this.endOfDay(end) };
  }

  private startOfDay(date: Date): Date {
    const result = new Date(date);
    result.setHours(0, 0, 0, 0);
    return result;
  }

  private endOfDay(date: Date): Date {
    const result = new Date(date);
    result.setHours(23, 59, 59, 999);
    return result;
  }

  private startOfWeek(reference: Date): Date {
    const result = this.startOfDay(reference);
    const day = result.getDay();
    const daysFromMonday = (day + 6) % 7;
    result.setDate(result.getDate() - daysFromMonday);
    return result;
  }

  private endOfWeek(start: Date): Date {
    const result = new Date(start);
    result.setDate(result.getDate() + 6);
    return this.endOfDay(result);
  }

  readonly currentRangeLabel = computed(() => {
    const mode = this.viewMode();
    const range = this.currentDateRange();

    switch (mode) {
      case 'day': {
        return this.formatDate(range.start, { month: 'short', day: 'numeric', year: 'numeric' });
      }
      case 'month': {
        return this.formatDate(range.start, { month: 'long', year: 'numeric' });
      }
      default: {
        const startLabel = this.formatDate(range.start, { month: 'short', day: 'numeric' });
        const endLabel = this.formatDate(range.end, { month: 'short', day: 'numeric' });
        return `${startLabel} – ${endLabel}`;
      }
    }
  });

  setViewMode(mode: CalendarViewMode): void {
    this.viewMode.set(mode);
    this.resetReferenceDate();
  }

  private resetReferenceDate(): void {
    this.referenceDate.set(new Date());
  }

  goToNextRange(): void {
    this.shiftReferenceDate(1);
  }

  goToPreviousRange(): void {
    this.shiftReferenceDate(-1);
  }

  goToToday(): void {
    this.resetReferenceDate();
  }

  readonly weekVm = computed<WeekViewVm>(() =>
    this.toWeekVm(this.currentDateRange(), this.calendarEvents())
  );

  readonly dayVm = computed<DayVm>(() =>
    this.toDayVm(this.currentDateRange(), this.calendarEvents())
  );

  readonly monthVm = computed<MonthViewVm>(() => {
    if (this.viewMode() !== 'month') {
      return { weeks: [] };
    }

    return this.toMonthVm(this.currentDateRange(), this.calendarEvents());
  });

  private toWeekVm(range: CalendarDateRange, events: CalendarEventBriefDto[]): WeekViewVm {
    const days: DayVm[] = [];
    const formatter = new Intl.DateTimeFormat('en-US', {
      weekday: 'short',
      month: 'short',
      day: 'numeric',
    });

    for (let i = 0; i < 7; i++) {
      const date = this.addDays(range.start, i);
      const dayEvents = this.toDayEvents(date, events);
      days.push({ date, label: formatter.format(date), events: dayEvents });
    }

    return { days };
  }

  private toDayVm(range: CalendarDateRange, events: CalendarEventBriefDto[]): DayVm {
    const date = this.startOfDay(range.start);
    const formatter = new Intl.DateTimeFormat('en-US', {
      weekday: 'long',
      month: 'short',
      day: 'numeric',
      year: 'numeric',
    });

    return {
      date,
      label: formatter.format(date),
      events: this.toDayEvents(date, events),
      isCurrentMonth: true,
      isToday: this.isSameDay(date, new Date()),
    };
  }

  private toMonthVm(range: CalendarDateRange, events: CalendarEventBriefDto[]): MonthViewVm {
    const monthStart = this.startOfDay(new Date(range.start));
    const firstVisibleDate = this.startOfWeek(monthStart);
    const dayLabelFormatter = new Intl.DateTimeFormat('en-US', {
      day: 'numeric',
    });
    const currentMonth = monthStart.getMonth();
    const today = new Date();

    const weeks = Array.from({ length: 6 }, (_, weekIndex) => {
      const days = Array.from({ length: 7 }, (_, dayIndex) => {
        const date = this.addDays(firstVisibleDate, weekIndex * 7 + dayIndex);
        return {
          date,
          label: dayLabelFormatter.format(date),
          events: this.toDayEvents(date, events),
          isCurrentMonth: date.getMonth() === currentMonth,
          isToday: this.isSameDay(date, today),
        };
      });

      return { index: weekIndex, days };
    });

    return { weeks };
  }

  private toDayEvents(date: Date, events: CalendarEventBriefDto[]): EventVm[] {
    const dayStart = this.startOfDay(date);
    const dayEnd = this.endOfDay(date);

    return events
      .filter(event => !!event.start && event.start! >= dayStart && event.start! <= dayEnd)
      .map((event, idx) => ({
        id:
          event.id != null
            ? String(event.id)
            : `${event.title ?? 'event'}-${event.start?.toISOString() ?? idx}`,
        title: event.title ?? 'Untitled',
        start: event.start!,
        end: event.end ?? event.start!,
        timeLabel: this.formatTimeRange(event.start!, event.end ?? event.start!),
      }))
      .sort((a, b) => a.start.getTime() - b.start.getTime());
  }

  private shiftReferenceDate(direction: 1 | -1): void {
    const mode = this.viewMode();
    const updatedReference = this.calculateReferenceDate(mode, this.referenceDate(), direction);
    this.referenceDate.set(updatedReference);
  }
  private calculateReferenceDate(
    mode: CalendarViewMode,
    reference: Date,
    direction: 1 | -1
  ): Date {
    switch (mode) {
      case 'day':
        return this.addDays(this.startOfDay(reference), direction);
      case 'month':
        return this.startOfDay(
          new Date(reference.getFullYear(), reference.getMonth() + direction, 1)
        );
      default:
        return this.addDays(this.startOfWeek(reference), 7 * direction);
    }
  }

  private isSameDay(first: Date, second: Date): boolean {
    return (
      first.getFullYear() === second.getFullYear() &&
      first.getMonth() === second.getMonth() &&
      first.getDate() === second.getDate()
    );
  }

  private addDays(reference: Date, amount: number): Date {
    const result = new Date(reference);
    result.setDate(result.getDate() + amount);
    return result;
  }

  private formatDate(date: Date, options: Intl.DateTimeFormatOptions): string {
    return new Intl.DateTimeFormat('en-US', options).format(date);
  }
  private formatTime(date: Date): string {
    return new Intl.DateTimeFormat('en-US', {
      hour: 'numeric',
      minute: '2-digit',
    }).format(date);
  }
  private formatTimeRange(start: Date, end: Date): string {
    const startLabel = this.formatTime(start);
    const endLabel = this.formatTime(end);
    return start.getTime() === end.getTime() ? startLabel : `${startLabel} – ${endLabel}`;
  }
}
