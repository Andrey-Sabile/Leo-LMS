export interface WeekViewVm {
  days: DayVm[];
}

export interface DayVm {
  date: Date;
  label: string;
  events: EventVm[];
}

export interface EventVm {
  id: string;
  title: string;
  start: Date;
  end: Date;
  timeLabel: string;
}

