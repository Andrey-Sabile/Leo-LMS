import { Routes } from '@angular/router';
import { HOME_ROUTES } from '@app/features/home/home.routes';
import { COUNTER_ROUTES } from '@app/features/counter/counter.routes';
import { TODO_ROUTES } from '@app/features/todo/todo.routes';
import { CALENDAR_ROUTES } from '@app/features/calendar/calendar.routes';
import { STUDENT_DIRECTORY_ROUTES } from './features/student-directory/student-directory.routes';

export const routes: Routes = [
  ...HOME_ROUTES,
  ...COUNTER_ROUTES,
  ...TODO_ROUTES,
  ...CALENDAR_ROUTES,
  ...STUDENT_DIRECTORY_ROUTES,
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
