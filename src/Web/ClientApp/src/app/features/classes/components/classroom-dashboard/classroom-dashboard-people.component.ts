import { ChangeDetectionStrategy, Component, DestroyRef, computed, effect, inject, input, output, signal } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ClassroomStudentDto, ClassroomTeacherDto, ClassroomsClient, AddTeacherToClassroomCommand, TeachersClient, TeacherLookupDto } from '@app/data-access/api/api-client';
import { provideIcons, NgIcon } from '@ng-icons/core';
import { heroUserPlus, heroEllipsisVertical } from '@ng-icons/heroicons/outline';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-classroom-dashboard-people',
  templateUrl: './classroom-dashboard-people.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush,
  viewProviders: [provideIcons({ heroUserPlus, heroEllipsisVertical })],
  imports: [NgIcon, ReactiveFormsModule]
})

export class ClassroomDashboardPeopleComponent {
  private readonly teachersClient = inject(TeachersClient);
  private readonly destroyRef = inject(DestroyRef);
  private readonly fb = inject(NonNullableFormBuilder);
  private readonly classroomsClient = inject(ClassroomsClient);

  readonly teachers = input.required<readonly ClassroomTeacherDto[]>();
  readonly teachersLoaded = signal<TeacherLookupDto[]>([]);
  readonly students = input.required<readonly ClassroomStudentDto[]>();
  readonly classroomId = input.required<number>();
  readonly teacherAdded = output<void>();

  readonly teacherCount = computed(() => this.teachers().length);
  readonly studentCount = computed(() => this.students().length);

  readonly isSubmitting = signal(false);
  readonly submitError = signal<string | null>(null);
  readonly teacherSearchQuery = signal('');

  readonly addTeacherForm = this.fb.group({
    teacherId: ['', Validators.required],
  });

  private readonly refreshTeachersEffect = effect(
    () => {
      const search = this.teacherSearchQuery();
      this.loadTeachers(search);
    },
    { allowSignalWrites: true }
  );

  private loadTeachers(search: string): void {
    this.teachersClient.getTeacherLookup(search || null, 1, 20).subscribe({
      next: result => {
        this.teachersLoaded.set(result.items ?? []);
      }
    })
  }

  onSubmit(dialog: HTMLDialogElement): void {
    if (this.addTeacherForm.invalid || this.isSubmitting()) {
      this.addTeacherForm.markAllAsTouched();
      return;
    }

    const teacherIdValue = Number.parseInt(this.addTeacherForm.getRawValue().teacherId, 10);
    if (Number.isNaN(teacherIdValue)) {
      this.submitError.set('A valid teacher ID is required.');
      this.addTeacherForm.controls.teacherId.markAsTouched();
      return;
    }

    this.isSubmitting.set(true);
    this.submitError.set(null);

    const classroomId = this.classroomId();
    this.classroomsClient
      .addTeacherToClassroom(
        classroomId,
        new AddTeacherToClassroomCommand({
          classroomId,
          teacherId: teacherIdValue
        })
      )
      .pipe(
        finalize(() => this.isSubmitting.set(false)),
        takeUntilDestroyed(this.destroyRef)
      )
      .subscribe({
        next: () => {
          this.addTeacherForm.reset({ teacherId: '' });
          dialog.close();
          this.teacherAdded.emit();
        },
        error: error => {
          console.error('Failed to add teacher to classroom.', error);
          this.submitError.set('Unable to add teacher. Please try again.');
        }
      });
  }

  onSearchChange(value: string): void {
    this.teacherSearchQuery.set(value);
  }
}
