import { CommonModule } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  computed,
  input,
  output,
  signal,
} from '@angular/core';
import {
  CdkDrag,
  CdkDragDrop,
  CdkDragEnd,
  CdkDragStart,
  CdkDropList,
  CdkDropListGroup,
} from '@angular/cdk/drag-drop';
import type {
  DayVm,
  EventVm,
  CalendarDateRange,
  CalendarEventDropPayload,
} from '../calendar-view.models';

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

  imports: [CommonModule, CdkDropListGroup, CdkDropList, CdkDrag],
  templateUrl: './calendar-day-view.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarDayViewComponent {
  vm = input.required<DayVm>();
  readonly eventDropped = output<CalendarEventDropPayload>();
  readonly timeSlotSelected = output<CalendarDateRange>();

  private readonly hourLabelFormatter = new Intl.DateTimeFormat('en-US', {
    hour: 'numeric',
  });
  private readonly isDragging = signal(false);

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

  handleDrop(
    targetSlot: HourSlotVm,
    event: CdkDragDrop<HourSlotVm, HourSlotVm, EventVm>
  ): void {
    const draggedEvent = event.item.data;
    if (!draggedEvent) {
      return;
    }

    const fromStart = draggedEvent.start;
    const fromEnd = draggedEvent.end;
    const durationMs = Math.max(fromEnd.getTime() - fromStart.getTime(), 60 * 60 * 1000);
    const dayStart = this.toStartOfDay(targetSlot.start);
    const dayEnd = this.toEndOfDay(dayStart).getTime();
    const nextStart = new Date(targetSlot.start);
    const proposedEnd = nextStart.getTime() + durationMs;
    const nextEnd = new Date(Math.min(proposedEnd, dayEnd));

    if (
      fromStart.getTime() === nextStart.getTime() &&
      fromEnd.getTime() === nextEnd.getTime()
    ) {
      this.isDragging.set(false);
      return;
    }

    this.isDragging.set(false);
    this.eventDropped.emit({
      eventId: draggedEvent.id,
      fromStart,
      fromEnd,
      targetStart: nextStart,
      targetEnd: nextEnd,
    });
  }

  emitSlotSelection(slot: HourSlotVm): void {
    if (this.isDragging()) {
      return;
    }

    this.timeSlotSelected.emit({ start: slot.start, end: slot.end });
  }

  onDragStarted(_event: CdkDragStart<EventVm>): void {
    this.isDragging.set(true);
  }

  onDragEnded(_event: CdkDragEnd<EventVm>): void {
    this.isDragging.set(false);
  }

  private toStartOfDay(date: Date): Date {
    const result = new Date(date);
    result.setHours(0, 0, 0, 0);
    return result;
  }

  private toEndOfDay(date: Date): Date {
    const result = new Date(date);
    result.setHours(23, 59, 59, 999);
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
