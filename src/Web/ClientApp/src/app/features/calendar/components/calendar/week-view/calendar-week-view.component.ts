import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import type { DayVm, EventVm, WeekViewVm } from '../calendar-view.models';

type HourSlotEventVm = {
  event: EventVm;
  startsInSlot: boolean;
  endsInSlot: boolean;
};

type HourSlotVm = {
  hour: number;
  label: string;
  events: HourSlotEventVm[];
  isCurrentHour: boolean;
};

type WeekDayColumnVm = {
  day: DayVm;
  hourSlots: HourSlotVm[];
  isToday: boolean;
};

@Component({
  selector: 'app-calendar-week-view',

  imports: [CommonModule],
  templateUrl: './calendar-week-view.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarWeekViewComponent {
  vm = input.required<WeekViewVm>();

  private readonly hourLabelFormatter = new Intl.DateTimeFormat('en-US', {
    hour: 'numeric',
  });

  readonly dayColumns = computed<WeekDayColumnVm[]>(() => {
    const week = this.vm();
    const now = new Date();
    const nowTime = now.getTime();

    return week.days.map(day => {
      const startOfDay = this.toStartOfDay(day.date);
      const isToday = this.isSameDay(startOfDay, now);

      const hourSlots = Array.from({ length: 24 }, (_, hour) => {
        const slotStart = new Date(startOfDay);
        slotStart.setHours(hour, 0, 0, 0);
        const slotStartTime = slotStart.getTime();
        const slotEndTime = slotStartTime + 60 * 60 * 1000;

        const events = day.events
          .filter(event => this.eventOverlapsSlot(event, slotStartTime, slotEndTime))
          .map<HourSlotEventVm>(event => ({
            event,
            startsInSlot: this.isWithinInterval(event.start.getTime(), slotStartTime, slotEndTime),
            endsInSlot:
              this.getEventEffectiveEndTime(event) > slotStartTime &&
              event.end.getTime() <= slotEndTime,
          }));

        return {
          hour,
          label: this.hourLabelFormatter.format(slotStart),
          events,
          isCurrentHour: isToday && this.isWithinInterval(nowTime, slotStartTime, slotEndTime),
        };
      });

      return { day, hourSlots, isToday };
    });
  });

  private toStartOfDay(date: Date): Date {
    const result = new Date(date);
    result.setHours(0, 0, 0, 0);
    return result;
  }

  private eventOverlapsSlot(event: EventVm, slotStartTime: number, slotEndTime: number): boolean {
    const eventStartTime = event.start.getTime();
    const eventEffectiveEndTime = this.getEventEffectiveEndTime(event);
    return eventStartTime < slotEndTime && eventEffectiveEndTime > slotStartTime;
  }

  private isWithinInterval(value: number, start: number, end: number): boolean {
    return value >= start && value < end;
  }

  private getEventEffectiveEndTime(event: EventVm): number {
    const start = event.start.getTime();
    const end = event.end.getTime();
    return start === end ? end + 1 : end;
  }

  private isSameDay(first: Date, second: Date): boolean {
    return (
      first.getFullYear() === second.getFullYear() &&
      first.getMonth() === second.getMonth() &&
      first.getDate() === second.getDate()
    );
  }
}
