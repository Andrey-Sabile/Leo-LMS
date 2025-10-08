import { Routes } from '@angular/router';
import { HOME_ROUTES } from '@app/features/home/home.routes';
import { COUNTER_ROUTES } from '@app/features/counter/counter.routes';
import { FETCH_DATA_ROUTES } from '@app/features/fetch-data/fetch-data.routes';
import { TODO_ROUTES } from '@app/features/todo/todo.routes';
import { CALENDAR_ROUTES } from '@app/features/calendar/calendar.routes';

export const routes: Routes = [
  ...HOME_ROUTES,
  ...COUNTER_ROUTES,
  ...FETCH_DATA_ROUTES,
  ...TODO_ROUTES,
  ...CALENDAR_ROUTES,
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
