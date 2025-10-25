import { Routes } from '@angular/router';
import { HOME_ROUTES } from '@app/features/home/home.routes';
import { COUNTER_ROUTES } from '@app/features/counter/counter.routes';
import { TODO_ROUTES } from '@app/features/todo/todo.routes';
import { CALENDAR_ROUTES } from '@app/features/calendar/calendar.routes';
import { STUDENT_DIRECTORY_ROUTES } from './features/student-directory/student-directory.routes';
import { CLASSES_ROUTES } from './features/classes/classes.routes';
import { SIMPLE_CALENDAR_ROUTES } from './features/simple-calendar/simple-calendar.routes';

export const routes: Routes = [
  ...HOME_ROUTES,
  ...COUNTER_ROUTES,
  ...TODO_ROUTES,
  ...CALENDAR_ROUTES,
  ...STUDENT_DIRECTORY_ROUTES,
  ...CLASSES_ROUTES,
  ...SIMPLE_CALENDAR_ROUTES,
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
