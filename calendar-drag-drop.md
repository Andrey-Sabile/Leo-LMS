# calendar-drag-drop.md

## Approach Overview
- Keep `CalendarComponent` as the source of truth: continue passing derived view models down and surface all user interactions back up through new outputs so the same pattern scales to week/month views.
- Adopt Angular CDK drag & drop: render each event card as a `cdkDrag` and each hour slot as a constrained `cdkDropList` that snaps to the slot’s hour boundary; enforce day-only moves in the day view.
- Reuse a shared drop payload contract: emit the original and target ranges so the parent can call `CalendarEventsClient.updateCalendarEvent` and optimistically refresh local signal state before the server response.
- Enable quick event creation: emit a slot-selection output on click, seed the create modal with the one-hour range, and reuse the new signal for future week/month slot selections.
- Prepare for broader reuse: mirror the same outputs in week/month components later, allowing cross-day drops by adjusting their slot calculations without changing parent logic.

## Step 1 · Add Angular CDK Drag & Drop
- **Libraries:** `@angular/cdk`
- **Files:** package manager (`src/Web/ClientApp/package.json`)
- **Sample:**
  ```bash
  npm install @angular/cdk
  ```

## Step 2 · Provide DragDropModule
- **Libraries:** `@angular/cdk/drag-drop`
- **Files:** `src/Web/ClientApp/src/app/app.config.ts`
- **Sample:**
  ```ts
  import { DragDropModule } from '@angular/cdk/drag-drop';

  export const appConfig: ApplicationConfig = {
    providers: [
      // …existing providers,
      importProvidersFrom(BrowserModule, DragDropModule),
    ],
  };
  ```

## Step 3 · Extend Day View Contracts
- **Libraries:** none
- **Files:** `src/Web/ClientApp/src/app/features/calendar/components/calendar/calendar-view.models.ts`
- **Sample:**
  ```ts
  export type CalendarEventDropPayload = {
    eventId: string;
    fromStart: Date;
    fromEnd: Date;
    targetStart: Date;
    targetEnd: Date;
  };
  ```

## Step 4 · Add Outputs & Drag Logic to Day View Component
- **Libraries:** `@angular/cdk/drag-drop`
- **Files:** `calendar-day-view.component.ts`
- **Sample:**
  ```ts
  import { CdkDragDrop } from '@angular/cdk/drag-drop';
  import { output } from '@angular/core';

  export class CalendarDayViewComponent {
    readonly eventDropped = output<CalendarEventDropPayload>();
    readonly timeSlotSelected = output<CalendarDateRange>();

    handleDrop({ item, container }: CdkDragDrop<HourSlotVm>) {
      const { event, slot } = item.data as { event: EventVm; slot: HourSlotVm };
      const durationMs = event.end.getTime() - event.start.getTime();
      const nextStart = slot.start;
      const nextEnd = new Date(nextStart.getTime() + Math.max(durationMs, 60 * 60 * 1000));

      this.eventDropped.emit({
        eventId: event.id,
        fromStart: event.start,
        fromEnd: event.end,
        targetStart: nextStart,
        targetEnd: nextEnd,
      });
    }

    emitSlotSelection(slot: HourSlotVm) {
      this.timeSlotSelected.emit({ start: slot.start, end: slot.end });
    }
  }
  ```

## Step 5 · Wire CDK Directives in Day View Template
- **Libraries:** `@angular/cdk/drag-drop`
- **Files:** `calendar-day-view.component.html`
- **Sample:**
  ```html
  <div
    cdkDropList
    [cdkDropListData]="slot"
    (cdkDropListDropped)="handleDrop($event)"
    (click)="emitSlotSelection(slot)"
    class="flex gap-4 rounded-box border border-base-200 p-3"
  >
    <div
      cdkDrag
      *ngFor="let entry of slot.events; track entry.event.id"
      [cdkDragData]="{ event: entry.event, slot }"
      class="rounded-box bg-base-200/60 p-2"
    >
      <!-- existing event card -->
    </div>
  </div>
  ```

## Step 6 · Handle Drops & Slot Clicks in Calendar Component
- **Libraries:** `@angular/cdk/drag-drop`
- **Files:** `calendar.component.ts`
- **Sample:**
  ```ts
  readonly selectedCreateRange = signal<CalendarDateRange>(this.currentDateRange());

  onEventDropped(payload: CalendarEventDropPayload) {
    const event = this.calendarEvents().find(e => String(e.id ?? '') === payload.eventId);
    if (!event || !event.id) {
      return;
    }

    const command = new UpdateCalendarEventCommand({
      id: event.id,
      title: event.title,
      start: payload.targetStart,
      end: payload.targetEnd,
      status: event.status,
      type: event.type,
      scope: event.scope,
      classId: event.classId,
      subjectId: event.subjectId,
    });

    this.calendarEventsClient.updateCalendarEvent(event.id, command).subscribe({
      next: () => {
        this.calendarEvents.update(items =>
          this.sortEventsByStart(
            items.map(item =>
              item.id === event.id ? { ...item, start: payload.targetStart, end: payload.targetEnd } : item
            )
          )
        );
      },
      error: error => console.error(error),
    });
  }

  onTimeSlotSelected(range: CalendarDateRange) {
    this.selectedCreateRange.set(range);
    this.openCreateEventModal();
  }
  ```

## Step 7 · Bind Outputs in Calendar Template
- **Libraries:** none
- **Files:** `calendar.component.html`
- **Sample:**
  ```html
  <app-calendar-day-view
    [vm]="dayVm()"
    (eventDropped)="onEventDropped($event)"
    (timeSlotSelected)="onTimeSlotSelected($event)"
  ></app-calendar-day-view>

  <app-create-calendar-event-modal
    [open]="isCreateEventModalOpen()"
    [initialRange]="selectedCreateRange()"
    (eventCreated)="handleEventCreated($event)"
    (dismissed)="closeCreateEventModal()"
  ></app-create-calendar-event-modal>
  ```

## Step 8 · Reuse Pattern for Week/Month Views
- **Libraries:** `@angular/cdk/drag-drop`
- **Files:** `calendar-week-view.component.*`, `calendar-month-view.component.*`
- **Sample:**
  ```ts
  // Forward the same outputs so parent logic stays shared
  readonly eventDropped = output<CalendarEventDropPayload>();
  readonly timeSlotSelected = output<CalendarDateRange>();
  ```
