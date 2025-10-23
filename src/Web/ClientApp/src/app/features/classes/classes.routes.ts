import { Routes } from '@angular/router';
import { ClassesComponent } from './components/classes/classes.component';
import { ClassroomDashboardComponent } from './components/classroom-dashboard/classroom-dashboard.component';
import { classroomResolver } from './resolvers/classroom.resolver';

export const CLASSES_ROUTES: Routes = [
    {
        path: 'classes',
        children: [
            {
                path: '',
                component: ClassesComponent
            },
            {
                path: ':id',
                component: ClassroomDashboardComponent,
                resolve: {
                    classroom: classroomResolver
                }
            }
        ]
    }
];
