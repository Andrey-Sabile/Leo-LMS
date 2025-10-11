import { ChangeDetectionStrategy, Component, computed, inject, OnInit, signal } from '@angular/core';
import { CalendarWeekViewComponent } from './week-view/calendar-week-view.component';
import { CalendarEventBriefDto, CalendarEventsClient } from '@app/data-access/api/api-client';

@Component({
  selector: 'app-calendar',
  standalone: true,
  imports: [CalendarWeekViewComponent],
  templateUrl: './calendar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarComponent implements OnInit {

  private calendarEventsClient = inject(CalendarEventsClient);

  private readonly defaultViewMode = 'week';
  readonly viewMode = signal<CalendarViewMode>(this.defaultViewMode);
  readonly weekEvents = signal<CalendarEventBriefDto[]>([]);
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

  ngOnInit(): void {
    this.calendarEventsClient.getCalendarEventsWithPagination(
      null,
      null,
      null,
      null,
      null,
      null,
      null,
      1,
      1
    ).subscribe({
      next: result => this.weekEvents.set(result.items),
      error: error => console.error(error),
    })
  }

  setViewMode(mode: CalendarViewMode): void {
    this.viewMode.set(mode);
  }
}

type CalendarViewMode = 'day' | 'week' | 'month';
