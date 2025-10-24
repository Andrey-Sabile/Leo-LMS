import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import type { DayVm, EventVm } from '../calendar-view.models';

type HourSlotEventVm = {
  event: EventVm;
  startsInSlot: boolean;
  endsInSlot: boolean;
};

type HourSlotVm = {
  hour: number;
  label: string;
  start: Date;
  end: Date;
  events: HourSlotEventVm[];
  isCurrentHour: boolean;
};

@Component({
  selector: 'app-calendar-day-view',

  imports: [CommonModule],
  templateUrl: './calendar-day-view.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarDayViewComponent {
  vm = input.required<DayVm>();

  private readonly hourLabelFormatter = new Intl.DateTimeFormat('en-US', {
    hour: 'numeric',
  });

  readonly hourSlots = computed<HourSlotVm[]>(() => {
    const vm = this.vm();
    const startOfDay = this.toStartOfDay(vm.date);
    const isToday = vm.isToday ?? false;
    const now = new Date();
    const nowTime = now.getTime();

    return Array.from({ length: 24 }, (_, hour) => {
      const slotStart = new Date(startOfDay);
      slotStart.setHours(hour, 0, 0, 0);
      const slotStartTime = slotStart.getTime();
      const slotEnd = new Date(slotStartTime + 60 * 60 * 1000);
      const slotEndTime = slotEnd.getTime();

      const events = vm.events
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
        start: slotStart,
        end: slotEnd,
        events,
        isCurrentHour: isToday && this.isWithinInterval(nowTime, slotStartTime, slotEndTime),
      };
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
}
