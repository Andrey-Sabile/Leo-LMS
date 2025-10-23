import { inject } from '@angular/core';
import { ResolveFn, Router } from '@angular/router';
import { ClassroomDetailsDto, ClassroomsClient } from '@app/data-access/api/api-client';
import { EMPTY, catchError, map } from 'rxjs';

export const classroomResolver: ResolveFn<ClassroomDetailsDto> = route => {
  const classroomsClient = inject(ClassroomsClient);
  const router = inject(Router);
  const classroomIdParam = route.paramMap.get('id');

  const classroomId = classroomIdParam ? Number(classroomIdParam) : Number.NaN;
  if (Number.isNaN(classroomId)) {
    router.navigate(['/classes']);
    return EMPTY;
  }

  return classroomsClient.getClassroomDetails(classroomId).pipe(
    map(classroom => {
      if (classroom) {
        return classroom;
      }

      throw new Error(`Classroom with id ${classroomId} not found.`);
    }),
    catchError(error => {
      console.error('Failed to resolve classroom.', error);
      router.navigate(['/classes']);
      return EMPTY;
    })
  );
};
