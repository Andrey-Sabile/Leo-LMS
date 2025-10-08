import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

/**
 * Basic shape for calendar events used by the week view.
 * Extend or replace with the real DTO once available.
 */
export interface CalendarWeekEvent {
  id: number | string;
  title: string;
  start: Date;
  end: Date;
  description?: string;
  location?: string;
}

@Component({
  selector: 'app-calendar-week-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './calendar-week-view.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarWeekViewComponent {
  /**
   * The start of the visible week (assumed to already be normalized to the desired week start).
   */
  @Input({ required: true })
  set weekStart(value: Date) {
    this._weekStart = this.normalizeDate(value);
    this._daysInWeek = this.buildWeekDays(this._weekStart);
  }

  /**
   * Calendar events to render in the weekly grid.
   */
  @Input()
  set events(value: CalendarWeekEvent[]) {
    this._events = (value ?? []).map((event) => ({
      ...event,
      start: new Date(event.start),
      end: new Date(event.end),
    }));
  }

  private _weekStart: Date = this.normalizeDate(new Date());
  private _events: CalendarWeekEvent[] = [];
  private _daysInWeek = this.buildWeekDays(this._weekStart);

  readonly hours = Array.from({ length: 24 }, (_, index) => index);

  get daysInWeek(): Date[] {
    return this._daysInWeek;
  }

  get eventsByDay(): CalendarWeekEvent[][] {
    return this.daysInWeek.map((day) => {
      const startOfDay = new Date(day);
      startOfDay.setHours(0, 0, 0, 0);

      const endOfDay = new Date(day);
      endOfDay.setHours(23, 59, 59, 999);

      return this._events.filter(
        (event) => event.start <= endOfDay && event.end >= startOfDay
      );
    });
  }

  readonly trackHour = (_: number, hour: number) => hour;

  readonly trackDay = (_: number, day: Date) => day.toISOString();

  readonly trackEvent = (_: number, event: CalendarWeekEvent) => event.id;

  private normalizeDate(date: Date): Date {
    const normalized = new Date(date);
    normalized.setHours(0, 0, 0, 0);
    return normalized;
  }

  private buildWeekDays(start: Date): Date[] {
    return Array.from({ length: 7 }, (_, offset) => {
      const day = new Date(start);
      day.setDate(start.getDate() + offset);
      return day;
    });
  }
}
