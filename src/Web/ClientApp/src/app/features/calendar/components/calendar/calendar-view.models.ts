export type CalendarDateRange = { start: Date; end: Date };

export type CalendarEventDropPayload = {
  eventId: string;
  fromStart: Date;
  fromEnd: Date;
  targetStart: Date;
  targetEnd: Date;
};

export interface WeekViewVm {
  days: DayVm[];
}

export interface MonthViewVm {
  weeks: MonthWeekVm[];
}

export interface MonthWeekVm {
  index: number;
  days: DayVm[];
}

export interface DayVm {
  date: Date;
  label: string;
  events: EventVm[];
  isCurrentMonth?: boolean;
  isToday?: boolean;
}

export interface EventVm {
  id: string;
  title: string;
  start: Date;
  end: Date;
  timeLabel: string;
  isMultiDay: boolean;
  isStart: boolean;
  isEnd: boolean;
  isContinuation: boolean;
}
