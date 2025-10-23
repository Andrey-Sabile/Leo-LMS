import {
  ChangeDetectionStrategy,
  Component,
  DestroyRef,
  inject,
  signal,
} from '@angular/core';
import {
  FormBuilder,
  ReactiveFormsModule,
  AbstractControl,
  ValidationErrors,
  ValidatorFn,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { finalize } from 'rxjs/operators';
import {
  ClassroomsClient,
  CreateClassroomCommand,
} from '@app/data-access/api/api-client';

const trimmedRequiredValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
  const value = control.value;
  if (value === null || value === undefined) {
    return { required: true };
  }
  if (typeof value === 'string' && value.trim().length === 0) {
    return { required: true };
  }
  return null;
};

const optionalPositiveIntegerValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
  const value = control.value;
  if (value === null || value === undefined || value === '') {
    return null;
  }

  const numeric = typeof value === 'string' ? Number(value) : value;
  if (!Number.isInteger(numeric) || numeric <= 0) {
    return { positiveInteger: true };
  }

  return null;
};

@Component({
  selector: 'app-create-class',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './create-class.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateClassComponent {
  private readonly fb = inject(FormBuilder);
  private readonly classroomsClient = inject(ClassroomsClient);
  private readonly router = inject(Router);
  private readonly destroyRef = inject(DestroyRef);

  readonly isSubmitting = signal(false);
  readonly errorMessage = signal<string | null>(null);

  readonly createClassForm = this.fb.group({
    name: ['', trimmedRequiredValidator],
    description: [''],
    subjectId: ['', optionalPositiveIntegerValidator],
    teacherId: ['', optionalPositiveIntegerValidator],
  });

  constructor() {
    this.createClassForm.valueChanges
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(() => {
        if (this.errorMessage()) {
          this.errorMessage.set(null);
        }
      });
  }

  hasControlError(controlName: string, errorKey?: string): boolean {
    const control = this.createClassForm.get(controlName);
    if (!control) {
      return false;
    }
    if (!control.touched && !control.dirty) {
      return false;
    }
    if (!errorKey) {
      return control.invalid;
    }
    return Boolean(control.errors?.[errorKey]);
  }

  navigateBack(): void {
    if (this.isSubmitting()) {
      return;
    }
    this.router.navigate(['/classes']);
  }

  submitCreateClass(): void {
    if (this.isSubmitting()) {
      return;
    }
    this.createClassForm.markAllAsTouched();
    if (this.createClassForm.invalid) {
      return;
    }

    const formValue = this.createClassForm.value;
    const trimmedName = (formValue.name ?? '').trim();
    const trimmedDescription = (formValue.description ?? '').toString().trim();
    const subjectId = this.parseOptionalNumber(formValue.subjectId);
    const teacherId = this.parseOptionalNumber(formValue.teacherId);

    const command = new CreateClassroomCommand({
      name: trimmedName,
      description: trimmedDescription.length ? trimmedDescription : undefined,
      subjectId: subjectId ?? undefined,
      teacherId: teacherId ?? undefined,
    });

    this.isSubmitting.set(true);
    this.errorMessage.set(null);

    this.classroomsClient
      .createClassroom(command)
      .pipe(
        finalize(() => {
          this.isSubmitting.set(false);
        }),
        takeUntilDestroyed(this.destroyRef)
      )
      .subscribe({
        next: id => {
          this.router.navigate(['/classes', id]);
        },
        error: error => {
          console.error('Failed to create classroom.', error);
          this.errorMessage.set('Unable to create the classroom. Please try again.');
        },
      });
  }

  private parseOptionalNumber(value: unknown): number | null {
    if (value === null || value === undefined || value === '') {
      return null;
    }

    const numeric = Number(value);
    if (!Number.isFinite(numeric)) {
      return null;
    }

    return numeric;
  }
}
