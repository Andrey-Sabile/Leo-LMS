import { ChangeDetectionStrategy, Component, DestroyRef, computed, effect, inject, input, output, signal } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, ValidatorFn } from '@angular/forms';
import {
  ClassroomStudentDto,
  ClassroomTeacherDto,
  ClassroomsClient,
  AddTeacherToClassroomCommand,
  TeachersClient,
  TeacherLookupDto,
  AddStudentsToClassroomCommand,
  StudentsClient,
  StudentDto
} from '@app/data-access/api/api-client';
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
  private readonly studentsClient = inject(StudentsClient);
  private readonly destroyRef = inject(DestroyRef);
  private readonly fb = inject(NonNullableFormBuilder);
  private readonly classroomsClient = inject(ClassroomsClient);
  private readonly requireSelection: ValidatorFn = control => {
    const value = control.value as number[] | null | undefined;
    return value && value.length > 0 ? null : { required: true };
  };

  readonly teachers = input.required<readonly ClassroomTeacherDto[]>();
  readonly teachersLoaded = signal<TeacherLookupDto[]>([]);
  readonly students = input.required<readonly ClassroomStudentDto[]>();
  readonly studentsLoaded = signal<StudentDto[]>([]);
  readonly classroomId = input.required<number>();
  readonly teacherAdded = output<void>();
  readonly studentAdded = output<void>();
  readonly studentRemovedFromClassroom = output<void>();
  readonly teacherRemovedFromClassroom = output<void>();
  readonly selectedStudentIds = signal<number[]>([]);
  readonly selectedStudents = signal<StudentDto[]>([]);
  readonly selectedTeacherIds = signal<number[]>([]);
  readonly selectedTeachers = signal<TeacherLookupDto[]>([]);
  private readonly allStudents = signal<StudentDto[]>([]);

  readonly teacherCount = computed(() => this.teachers().length);
  readonly studentCount = computed(() => this.students().length);

  readonly isAddingTeachers = signal(false);
  readonly teacherSubmitError = signal<string | null>(null);
  readonly teacherSearchQuery = signal('');
  readonly isAddingStudents = signal(false);
  readonly studentSubmitError = signal<string | null>(null);
  readonly studentSearchQuery = signal('');

  readonly addTeacherForm = this.fb.group({
    teacherIds: this.fb.control<number[]>([], {
      validators: [this.requireSelection]
    }),
  });

  readonly addStudentForm = this.fb.group({
    studentIds: this.fb.control<number[]>([], {
      validators: [this.requireSelection]
    })
  });

  constructor() {
    this.loadTeachers('');
    this.fetchStudents();
    effect(
      () => {
        const currentSearch = this.studentSearchQuery();
        this.students();
        this.applyStudentFilter(currentSearch);
      },
      { allowSignalWrites: true }
    );
  }

  private loadTeachers(search: string): void {
    this.teachersClient
      .getTeacherLookup(search || null, 1, 20)
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: result => {
          this.teachersLoaded.set(result.items ?? []);
        },
        error: error => {
          console.error('Failed to load teachers.', error);
        }
      });
  }

  private fetchStudents(): void {
    this.studentsClient
      .getStudents()
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: result => {
          const students = result.students ?? [];
          this.allStudents.set(students);
          this.applyStudentFilter(this.studentSearchQuery());
        },
        error: error => {
          console.error('Failed to load students.', error);
        }
      });
  }

  private applyStudentFilter(search: string): void {
    const trimmed = search.trim().toLowerCase();
    const assignedIds = new Set(
      this.students()
        .map(student => student.id)
        .filter((id): id is number => id !== undefined && id !== null)
    );
    const filtered = this.allStudents().filter(student => {
      const matchesSearch =
        trimmed.length === 0 ||
        `${student.firstName ?? ''} ${student.lastName ?? ''}`.toLowerCase().includes(trimmed) ||
        (student.email ?? '').toLowerCase().includes(trimmed);
      const notAlreadyAssigned = !assignedIds.has(student.id ?? -1);
      return matchesSearch && notAlreadyAssigned;
    });

    this.studentsLoaded.set(filtered);
  }

  onTeacherSearchChange(value: string): void {
    this.teacherSearchQuery.set(value);
    this.loadTeachers(value);
  }

  onStudentSearchChange(value: string): void {
    this.studentSearchQuery.set(value);
    this.applyStudentFilter(value);
  }

  isTeacherSelected(teacherId: number | undefined): boolean {
    if (!teacherId) {
      return false;
    }
    return this.selectedTeacherIds().includes(teacherId);
  }

  toggleTeacherSelection(teacher: TeacherLookupDto): void {
    const teacherId = teacher?.id;
    if (!teacherId) {
      return;
    }

    const currentSelection = this.selectedTeacherIds();
    const currentTeachers = this.selectedTeachers();
    let updatedSelection: number[];
    let updatedTeachers: TeacherLookupDto[];

    if (currentSelection.includes(teacherId)) {
      updatedSelection = currentSelection.filter(id => id !== teacherId);
      updatedTeachers = currentTeachers.filter(t => t.id !== teacherId);
    } else {
      updatedSelection = [...currentSelection, teacherId];
      const teacherExists = currentTeachers.some(t => t.id === teacherId);
      updatedTeachers = teacherExists
        ? currentTeachers.map(t => (t.id === teacherId ? teacher : t))
        : [...currentTeachers, teacher];
    }

    this.selectedTeacherIds.set(updatedSelection);
    this.selectedTeachers.set(updatedTeachers);

    const control = this.addTeacherForm.controls.teacherIds;
    control.setValue(updatedSelection);
    control.markAsDirty();
    control.markAsTouched();
    this.teacherSubmitError.set(null);
  }

  removeSelectedTeacher(teacherId: number | undefined): void {
    if (teacherId === undefined) {
      return;
    }

    const teacher = this.selectedTeachers().find(t => t.id === teacherId);
    if (teacher) {
      this.toggleTeacherSelection(teacher);
    }
  }

  openTeacherDialog(dialog: HTMLDialogElement): void {
    this.teacherSearchQuery.set('');
    this.selectedTeacherIds.set([]);
    this.selectedTeachers.set([]);
    this.addTeacherForm.reset({ teacherIds: [] });
    this.teacherSubmitError.set(null);
    this.loadTeachers('');
    dialog.showModal();
  }

  submitTeachers(dialog: HTMLDialogElement): void {
    if (this.addTeacherForm.invalid || this.isAddingTeachers()) {
      this.addTeacherForm.markAllAsTouched();
      return;
    }

    const teacherIds = this.addTeacherForm.getRawValue().teacherIds;
    if (!teacherIds || teacherIds.length === 0) {
      this.teacherSubmitError.set('Select at least one teacher to add.');
      this.addTeacherForm.controls.teacherIds.markAsTouched();
      return;
    }

    this.isAddingTeachers.set(true);
    this.teacherSubmitError.set(null);

    const classroomId = this.classroomId();
    this.classroomsClient
      .addTeachersToClassroom(
        classroomId,
        new AddTeacherToClassroomCommand({
          classroomId,
          teacherIds
        })
      )
      .pipe(
        finalize(() => this.isAddingTeachers.set(false)),
        takeUntilDestroyed(this.destroyRef)
      )
      .subscribe({
        next: () => {
          this.selectedTeacherIds.set([]);
          this.selectedTeachers.set([]);
          this.addTeacherForm.reset({ teacherIds: [] });
          dialog.close();
          this.teacherAdded.emit();
        },
        error: error => {
          console.error('Failed to add teacher to classroom.', error);
          this.teacherSubmitError.set('Unable to add teacher. Please try again.');
        }
      });
  }

  isStudentSelected(studentId: number | undefined): boolean {
    if (studentId === undefined) {
      return false;
    }

    return this.selectedStudentIds().includes(studentId);
  }

  toggleStudentSelection(student: StudentDto): void {
    const studentId = student?.id;
    if (studentId === undefined || studentId === null) {
      return;
    }

    const currentSelection = this.selectedStudentIds();
    const currentStudents = this.selectedStudents();
    let updatedSelection: number[];
    let updatedStudents: StudentDto[];

    if (currentSelection.includes(studentId)) {
      updatedSelection = currentSelection.filter(id => id !== studentId);
      updatedStudents = currentStudents.filter(s => s.id !== studentId);
    } else {
      updatedSelection = [...currentSelection, studentId];
      const exists = currentStudents.some(s => s.id === studentId);
      updatedStudents = exists
        ? currentStudents.map(s => (s.id === studentId ? student : s))
        : [...currentStudents, student];
    }

    this.selectedStudentIds.set(updatedSelection);
    this.selectedStudents.set(updatedStudents);

    const control = this.addStudentForm.controls.studentIds;
    control.setValue(updatedSelection);
    control.markAsDirty();
    control.markAsTouched();
    this.studentSubmitError.set(null);
  }

  removeSelectedStudent(studentId: number | undefined): void {
    if (studentId === undefined) {
      return;
    }

    const student = this.selectedStudents().find(s => s.id === studentId);
    if (student) {
      this.toggleStudentSelection(student);
    }
  }

  openStudentDialog(dialog: HTMLDialogElement): void {
    this.studentSearchQuery.set('');
    this.selectedStudentIds.set([]);
    this.selectedStudents.set([]);
    this.addStudentForm.reset({ studentIds: [] });
    this.studentSubmitError.set(null);

    if (this.allStudents().length === 0) {
      this.fetchStudents();
    } else {
      this.applyStudentFilter('');
    }

    dialog.showModal();
  }

  submitStudents(dialog: HTMLDialogElement): void {
    if (this.addStudentForm.invalid || this.isAddingStudents()) {
      this.addStudentForm.markAllAsTouched();
      return;
    }

    const studentIds = this.addStudentForm.getRawValue().studentIds;
    if (!studentIds || studentIds.length === 0) {
      this.studentSubmitError.set('Select at least one student to add.');
      this.addStudentForm.controls.studentIds.markAsTouched();
      return;
    }

    this.isAddingStudents.set(true);
    this.studentSubmitError.set(null);

    const classroomId = this.classroomId();
    this.classroomsClient
      .addStudentsToClassroom(
        classroomId,
        new AddStudentsToClassroomCommand({
          classroomId,
          studentIds
        })
      )
      .pipe(
        finalize(() => this.isAddingStudents.set(false)),
        takeUntilDestroyed(this.destroyRef)
      )
      .subscribe({
        next: () => {
          this.selectedStudentIds.set([]);
          this.selectedStudents.set([]);
          this.addStudentForm.reset({ studentIds: [] });
          dialog.close();
          this.studentAdded.emit();
        },
        error: error => {
          console.error('Failed to add student to classroom.', error);
          this.studentSubmitError.set('Unable to add student. Please try again.');
        }
      });
  }

  removeStudentFromClassroom(studentId: number): void {
    this.classroomsClient
      .removeStudentFromClassroom(this.classroomId(), studentId,)
      .subscribe({
        next: result => {
          this.studentRemovedFromClassroom.emit();
        },
        error: error => {
          console.error("Failed to remove student from classroom.", error);
        }
      })
  }
  removeTeacherFromClassroom(teacherId: number): void {
    this.classroomsClient
      .removeTeacherFromClassroom(this.classroomId(), teacherId,)
      .subscribe({
        next: result => {
          this.teacherRemovedFromClassroom.emit();
        },
        error: error => {
          console.error("Failed to remove teacher from classroom.", error);
        }
      })
  }

}
