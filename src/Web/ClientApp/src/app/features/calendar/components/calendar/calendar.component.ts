import { ChangeDetectionStrategy, Component, computed, effect, inject, signal } from '@angular/core';
import { CalendarWeekViewComponent } from './week-view/calendar-week-view.component';
import { CalendarEventBriefDto, CalendarEventsClient } from '@app/data-access/api/api-client';

@Component({
  selector: 'app-calendar',
  standalone: true,
  imports: [CalendarWeekViewComponent],
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
  readonly currentDateRange = computed(() =>
    this.resolveDateRange(this.viewMode(), this.referenceDate())
  );
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

  private readonly refreshEventsEffect = effect(
    () => {
      const range = this.currentDateRange();
      this.loadCalendarEvents(range);
    },
    { allowSignalWrites: true }
  );

  setViewMode(mode: CalendarViewMode): void {
    this.viewMode.set(mode);
    this.resetReferenceDate();
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
  private addDays(reference: Date, amount: number): Date {
    const result = new Date(reference);
    result.setDate(result.getDate() + amount);
    return result;
  }
  private resetReferenceDate(): void {
    this.referenceDate.set(new Date());
  }
  private formatDate(date: Date, options: Intl.DateTimeFormatOptions): string {
    return new Intl.DateTimeFormat('en-US', options).format(date);
  }
}

type CalendarViewMode = 'day' | 'week' | 'month';
export type CalendarDateRange = { start: Date; end: Date };
