import { ChangeDetectionStrategy, Component, computed, input } from '@angular/core';
import { CalendarEventBriefDto } from '@app/data-access/api/api-client';
import { CalendarDateRange } from '@app/features/simple-calendar/models/simple-calendar-view.models';
import { getDayOfWeek, formatTimeLabel } from '@app/features/simple-calendar/utility/date-format';

interface TimeSlotDescriptor {
  index: number;
  label: string;
  ariaLabel: string;
  startMinutes: number;
  endMinutes: number;
  events: CalendarEventBriefDto[];
}

@Component({
  selector: 'app-simple-calendar-day',
  imports: [],
  templateUrl: './simple-calendar-day.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styles: ``
})

export class SimpleCalendarDayComponent {
  private static readonly MinutesPerDay = 24 * 60;
  private static readonly SlotMinutes = 60;
  private static readonly SlotsPerDay = SimpleCalendarDayComponent.MinutesPerDay / SimpleCalendarDayComponent.SlotMinutes;

  readonly calendarEvents = input.required<CalendarEventBriefDto[]>();
  readonly dateRange = input.required<CalendarDateRange>();

  readonly dayOfTheWeek = computed(() => {
    const dateRange = this.dateRange();
    return getDayOfWeek(dateRange.start);
  });

  readonly timeSlots = computed(() => this.buildTimeSlots());

  private buildTimeSlots(): TimeSlotDescriptor[] {
    const eventsBySlot = this.groupEventsBySlot();

    return Array.from({ length: SimpleCalendarDayComponent.SlotsPerDay }, (_, index) => {
      const startMinutes = index * SimpleCalendarDayComponent.SlotMinutes;
      const endMinutes = Math.min(startMinutes + SimpleCalendarDayComponent.SlotMinutes, SimpleCalendarDayComponent.MinutesPerDay);
      const startLabel = formatTimeLabel(startMinutes, SimpleCalendarDayComponent.MinutesPerDay);
      const endLabel = formatTimeLabel(endMinutes, SimpleCalendarDayComponent.MinutesPerDay);
      const events = eventsBySlot.get(index) ?? [];

      return {
        index,
        label: startLabel,
        ariaLabel: `Time slot from ${startLabel} to ${endLabel}`,
        startMinutes,
        endMinutes,
        events: events.length > 0 ? [...events] : []
      } satisfies TimeSlotDescriptor;
    });
  }

  private groupEventsBySlot(): Map<number, CalendarEventBriefDto[]> { // Returns a Map with the slot index as key and the events for the value
    const range = this.dateRange();

    const dayStart = new Date(range.start);
    dayStart.setHours(0, 0, 0, 0);

    const dayEnd = new Date(dayStart);
    dayEnd.setMinutes(dayEnd.getMinutes() + SimpleCalendarDayComponent.MinutesPerDay);

    const slots = new Map<number, CalendarEventBriefDto[]>();

    for (const event of this.calendarEvents()) {
      const evStart = event.start;
      if (!evStart) continue;

      const evEnd = event.end ?? evStart;

      if (evEnd <= dayStart || evStart >= dayEnd) continue;

      const clampedStart = evStart < dayStart ? new Date(dayStart) : new Date(evStart);
      const clampedEnd = evEnd > dayEnd ? new Date(dayEnd) : new Date(evEnd);

      const startMinutes = this.toMinutesFromMidnight(clampedStart);
      const endMinutes = Math.min(this.toMinutesFromMidnight(clampedEnd) + (clampedEnd.getSeconds() > 0 || clampedEnd.getMilliseconds() > 0 ? 0 : 0), SimpleCalendarDayComponent.MinutesPerDay);

      const firstSlot = Math.floor(startMinutes / SimpleCalendarDayComponent.SlotMinutes);
      const lastSlot = Math.floor(Math.max(0, Math.min(SimpleCalendarDayComponent.MinutesPerDay - 1, endMinutes - 1)) / SimpleCalendarDayComponent.SlotMinutes);

      for (let slotIndex = firstSlot; slotIndex <= lastSlot; slotIndex++) {
        if (slotIndex < 0 || slotIndex >= SimpleCalendarDayComponent.SlotsPerDay) continue;

        const bucket = slots.get(slotIndex);
        if (bucket) {
          bucket.push(event);
        } else {
          slots.set(slotIndex, [event]);
        }
      }
    }

    for (const bucket of slots.values()) {
      bucket.sort((first, second) => {
        const firstValue = first.start?.getTime() ?? 0;
        const secondValue = second.start?.getTime() ?? 0;
        return firstValue - secondValue;
      });
    }

    return slots;
  }

  private toMinutesFromMidnight(date: Date): number {
    return date.getHours() * 60 + date.getMinutes();
  }
}
