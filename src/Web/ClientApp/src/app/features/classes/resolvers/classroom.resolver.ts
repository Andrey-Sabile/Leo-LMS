import { inject } from '@angular/core';
import { ResolveFn, Router } from '@angular/router';
import { ClassroomDto, ClassroomsClient } from '@app/data-access/api/api-client';
import { EMPTY, catchError, map, of, switchMap } from 'rxjs';

export const classroomResolver: ResolveFn<ClassroomDto> = route => {
  const classroomsClient = inject(ClassroomsClient);
  const router = inject(Router);
  const classroomIdParam = route.paramMap.get('id');

  const classroomId = classroomIdParam ? Number(classroomIdParam) : Number.NaN;
  if (Number.isNaN(classroomId)) {
    router.navigate(['/classes']);
    return EMPTY;
  }

  return classroomsClient.getClassrooms().pipe(
    map(response => response.classrooms ?? []),
    map(classrooms => classrooms.find(classroom => classroom.id === classroomId) ?? null),
    switchMap(classroom => {
      if (classroom) {
        return of(classroom);
      }

      router.navigate(['/classes']);
      return EMPTY;
    }),
    catchError(error => {
      console.error('Failed to resolve classroom.', error);
      router.navigate(['/classes']);
      return EMPTY;
    })
  );
};
