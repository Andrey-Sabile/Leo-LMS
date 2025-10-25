Implementation Plan

Switch component to ChangeDetectionStrategy.OnPush, import CommonModule, and expose trackBy helpers for slots and event overlays in src/Web/ClientApp/src/app/features/simple-calendar/components/simple-calendar/simple-calendar-day/simple-calendar-day.component.ts.

Define constants for 30-minute slot length (SLOT_MINUTES = 30) and minutes per day. Build a computed timeSlots signal that returns 48 slot descriptors (index, label, start/end minutes) for rendering and aria labeling.

Create a filteredEvents computed signal that keeps only CalendarEventBriefDto instances intersecting the provided dateRange. Normalize start/end using the range’s timezone, clamp to the day bounds (00:00–24:00), discard invalid ranges, and enforce a minimum duration when start ≈ end.

Derive positionedEvents with a sweep-line style algorithm:

Convert each filtered event to minutes-from-midnight (startMinutes, endMinutes).
Clamp and convert to percentages for placement: topPercent = (startMinutes / 1440) * 100, heightPercent = ((endMinutes - startMinutes) / 1440) * 100.
Partition overlapping events into columns by iterating sorted events, reusing free columns when intervals no longer overlap.
Compute columnCount per overlapping cluster and assign widthPercent = 100 / columnCount, leftPercent = columnIndex * widthPercent, and a rising zIndex so later events rest above earlier ones.
Store layout metadata in a new local interface:
interface PositionedEvent {
  event: CalendarEventBriefDto;
  topPercent: number;
  heightPercent: number;
  leftPercent: number;
  widthPercent: number;
  zIndex: number;
  ariaLabel: string;
}
Template (simple-calendar-day.component.html) layout:

<section class="relative flex">
  <div class="w-16 text-right pr-2">
    <div *ngFor="let slot of timeSlots(); trackBy: trackSlot" class="h-16 flex items-start">
      <span aria-hidden="true">{{ slot.label }}</span>
    </div>
  </div>

  <div class="flex-1 relative border-l border-base-300">
    <div *ngFor="let slot of timeSlots(); trackBy: trackSlot"
         class="h-16 border-b border-dashed border-base-200"
         [attr.aria-label]="slot.ariaLabel"></div>

    <article *ngFor="let item of positionedEvents(); trackBy: trackEvent"
             class="absolute rounded-lg bg-primary/80 text-primary-content px-2 py-1 overflow-hidden shadow-sm"
             [style.top.%]="item.topPercent"
             [style.height.%]="item.heightPercent"
             [style.left.%]="item.leftPercent"
             [style.width.%]="item.widthPercent"
             [style.zIndex]="item.zIndex"
             [attr.aria-label]="item.ariaLabel"
             role="button"
             tabindex="0">
      <h3 class="font-semibold text-xs truncate">{{ item.event.title }}</h3>
      <p class="text-[10px]">{{ item.event.start | date:'shortTime' }} – {{ item.event.end | date:'shortTime' }}</p>
    </article>
  </div>
</section>
h-16 corresponds to 30-minute vertical slots (adjust tailwind utility as needed).
Events overlay inside the relative container using absolute positioning.
Provide trackBy methods:

readonly trackSlot = (_: number, slot: TimeSlot) => slot.startMinutes;
readonly trackEvent = (_: number, item: PositionedEvent) => item.event.id;
Guard against huge event arrays by keeping computations inside Angular signals and keeping DOM updates minimal. Consider memoizing column layout logic if performance becomes an issue.

Next Steps

Implement the computed signals and helper interfaces in the component class.
Update the HTML template with the slot grid and overlay container.
After coding, run ng lint or relevant unit tests for the simple calendar feature to confirm no regressions.
