import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CalendarWeekViewComponent } from './week-view/calendar-week-view.component';

interface DemoWeekEvent {
  id: number;
  title: string;
  start: Date;
  end: Date;
  description?: string;
  location?: string;
}

@Component({
  selector: 'app-calendar',
  standalone: true,
  imports: [CalendarWeekViewComponent],
  templateUrl: './calendar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarComponent {
  readonly weekStart = this.getWeekStart(new Date());

  readonly demoEvents: DemoWeekEvent[] = [
    {
      id: 1,
      title: 'Homeroom Check-in',
      start: new Date(this.weekStart.getFullYear(), this.weekStart.getMonth(), this.weekStart.getDate(), 8, 30),
      end: new Date(this.weekStart.getFullYear(), this.weekStart.getMonth(), this.weekStart.getDate(), 9, 15),
      description: 'Welcome back and share announcements.',
      location: 'Room 302',
    },
    {
      id: 2,
      title: 'Parent Conference',
      start: new Date(this.weekStart.getFullYear(), this.weekStart.getMonth(), this.weekStart.getDate() + 2, 15, 0),
      end: new Date(this.weekStart.getFullYear(), this.weekStart.getMonth(), this.weekStart.getDate() + 2, 15, 45),
      location: 'Counselors Office',
    },
    {
      id: 3,
      title: 'Science Lab Prep',
      start: new Date(this.weekStart.getFullYear(), this.weekStart.getMonth(), this.weekStart.getDate() + 4, 11, 0),
      end: new Date(this.weekStart.getFullYear(), this.weekStart.getMonth(), this.weekStart.getDate() + 4, 12, 0),
      description: 'Set up microscopes and materials.',
    },
  ];

  private getWeekStart(date: Date): Date {
    const result = new Date(date);
    const dayOfWeek = result.getDay();
    const offset = dayOfWeek === 0 ? -6 : 1 - dayOfWeek; // Monday as the first day
    result.setDate(result.getDate() + offset);
    result.setHours(0, 0, 0, 0);
    return result;
  }
}
