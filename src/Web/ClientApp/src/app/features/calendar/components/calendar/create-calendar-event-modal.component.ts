import {
  ChangeDetectionStrategy,
  Component,
  DestroyRef,
  effect,
  inject,
  input,
  output,
  signal,
} from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { finalize } from 'rxjs/operators';
import {
  CalendarEventBriefDto,
  CalendarEventStatus,
  CalendarEventsClient,
  CreateCalendarEventCommand,
  EventScope,
  EventType,
} from '@app/data-access/api/api-client';

type CalendarDateRange = { start: Date; end: Date };

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

const createPositiveIntegerValidator = (required: boolean): ValidatorFn => {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    if (value === null || value === undefined || value === '') {
      return required ? { required: true } : null;
    }

    const numeric = typeof value === 'string' ? Number(value) : value;
    if (!Number.isInteger(numeric) || numeric <= 0) {
      return { positiveInteger: true };
    }

    return null;
  };
};

const optionalPositiveIntegerValidator = createPositiveIntegerValidator(false);
const requiredPositiveIntegerValidator = createPositiveIntegerValidator(true);

const timeRangeValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
  if (!(control instanceof FormGroup)) {
    return null;
  }

  const startValue = control.get('start')?.value;
  const endValue = control.get('end')?.value;

  if (!startValue || !endValue) {
    return null;
  }

  const startDate = new Date(startValue);
  const endDate = new Date(endValue);

  if (Number.isNaN(startDate.getTime()) || Number.isNaN(endDate.getTime())) {
    return { invalidDate: true };
  }

  if (startDate >= endDate) {
    return { timeRangeInvalid: true };
  }

  return null;
};

const toDateTimeLocalInput = (date: Date): string => {
  const local = new Date(date);
  local.setSeconds(0, 0);
  const year = local.getFullYear();
  const month = String(local.getMonth() + 1).padStart(2, '0');
  const day = String(local.getDate()).padStart(2, '0');
  const hours = String(local.getHours()).padStart(2, '0');
  const minutes = String(local.getMinutes()).padStart(2, '0');
  return `${year}-${month}-${day}T${hours}:${minutes}`;
};

const addHours = (date: Date, hours: number): Date => {
  const result = new Date(date);
  result.setHours(result.getHours() + hours);
  return result;
};

@Component({
  selector: 'app-create-calendar-event-modal',

  imports: [ReactiveFormsModule],
  templateUrl: './create-calendar-event-modal.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateCalendarEventModalComponent {
  private readonly fb = inject(FormBuilder);
  private readonly destroyRef = inject(DestroyRef);
  private readonly calendarEventsClient = inject(CalendarEventsClient);

  readonly open = input(false);
  readonly initialRange = input<CalendarDateRange | null>(null);
  readonly eventCreated = output<CalendarEventBriefDto>();
  readonly dismissed = output<void>();

  readonly isSubmitting = signal(false);
  readonly errorMessage = signal<string | null>(null);

  readonly createEventForm = this.fb.group(
    {
      title: ['', trimmedRequiredValidator],
      description: ['', trimmedRequiredValidator],
      start: ['', Validators.required],
      end: ['', Validators.required],
      status: [null as CalendarEventStatus | null],
      type: [null as EventType | null],
      scope: [null as EventScope | null],
      classId: ['', optionalPositiveIntegerValidator],
      subjectId: ['', optionalPositiveIntegerValidator],
    },
    { validators: timeRangeValidator }
  );

  readonly statusOptions = [
    { value: CalendarEventStatus.Draft, label: 'Draft' },
    { value: CalendarEventStatus.Cancelled, label: 'Cancelled' },
    { value: CalendarEventStatus.Scheduled, label: 'Scheduled' },
  ];

  readonly typeOptions = [
    { value: EventType.Exam, label: 'Exam' },
    { value: EventType.Holiday, label: 'Holiday' },
    { value: EventType.Announcement, label: 'Announcement' },
  ];

  readonly scopeOptions = [
    { value: null, label: 'No scope' },
    { value: EventScope.School, label: 'School' },
    { value: EventScope.Class, label: 'Class' },
    { value: EventScope.Subject, label: 'Subject' },
  ];

  readonly eventScope = EventScope;

  constructor() {
    this.setupScopeValidation();
    let wasOpen = false;
    effect(
      () => {
        const isOpen = this.open();
        const range = this.initialRange();

        if (isOpen && !wasOpen) {
          this.prefillForm(range);
          this.errorMessage.set(null);
        }

        if (!isOpen && wasOpen) {
          this.resetFormState();
        }

        wasOpen = isOpen;
      },
      { allowSignalWrites: true }
    );
  }

  get isTimeRangeInvalid(): boolean {
    if (!this.createEventForm.hasError('timeRangeInvalid')) {
      return false;
    }

    const startControl = this.createEventForm.get('start');
    const endControl = this.createEventForm.get('end');

    return (
      !!startControl &&
      !!endControl &&
      (startControl.dirty || startControl.touched) &&
      (endControl.dirty || endControl.touched)
    );
  }

  hasControlError(controlName: string, errorCode?: string): boolean {
    const control = this.createEventForm.get(controlName);
    if (!control) {
      return false;
    }

    if (errorCode) {
      return control.hasError(errorCode) && (control.dirty || control.touched);
    }

    return control.invalid && (control.dirty || control.touched);
  }

  get selectedScope(): EventScope | null {
    return (this.createEventForm.get('scope')?.value ?? null) as EventScope | null;
  }

  onDismiss(): void {
    this.dismissed.emit();
  }

  submitCreateEvent(): void {
    if (this.createEventForm.invalid) {
      this.createEventForm.markAllAsTouched();
      this.createEventForm.updateValueAndValidity();
      return;
    }

    const formValue = this.createEventForm.value;

    const startDate = new Date(formValue.start as string);
    const endDate = new Date(formValue.end as string);
    const classId = formValue.classId ? Number(formValue.classId) : null;
    const subjectId = formValue.subjectId ? Number(formValue.subjectId) : null;

    this.isSubmitting.set(true);
    this.errorMessage.set(null);

    const command = new CreateCalendarEventCommand({
      title: (formValue.title ?? '').trim(),
      description: (formValue.description ?? '').trim(),
      start: startDate,
      end: endDate,
      status: formValue.status ?? undefined,
      type: formValue.type ?? undefined,
      scope: formValue.scope ?? undefined,
      classId: classId ?? undefined,
      subjectId: subjectId ?? undefined,
    });

    this.calendarEventsClient
      .createCalendarEvent(command)
      .pipe(
        finalize(() => {
          this.isSubmitting.set(false);
        })
      )
      .subscribe({
        next: id => {
          const createdEvent = new CalendarEventBriefDto({
            id,
            title: (formValue.title ?? '').trim(),
            description: (formValue.description ?? '').trim(),
            status: formValue.status ?? undefined,
            type: formValue.type ?? undefined,
            scope: formValue.scope ?? undefined,
            start: startDate,
            end: endDate,
            classId: classId ?? undefined,
            subjectId: subjectId ?? undefined,
          });

          this.eventCreated.emit(createdEvent);
        },
        error: error => {
          console.error(error);
          this.errorMessage.set('Unable to create the event. Please try again.');
        },
      });
  }

  private setupScopeValidation(): void {
    const scopeControl = this.createEventForm.get('scope');
    if (!scopeControl) {
      return;
    }

    scopeControl.valueChanges.pipe(takeUntilDestroyed(this.destroyRef)).subscribe(scope => {
      this.applyScopeValidators(scope as EventScope | null);
    });

    this.applyScopeValidators(scopeControl.value as EventScope | null);
  }

  private applyScopeValidators(scope: EventScope | null): void {
    const classControl = this.createEventForm.get('classId');
    const subjectControl = this.createEventForm.get('subjectId');

    if (!classControl || !subjectControl) {
      return;
    }

    switch (scope) {
      case EventScope.Class: {
        classControl.setValidators(requiredPositiveIntegerValidator);
        subjectControl.setValidators(optionalPositiveIntegerValidator);
        break;
      }
      case EventScope.Subject: {
        classControl.setValidators(optionalPositiveIntegerValidator);
        subjectControl.setValidators(requiredPositiveIntegerValidator);
        break;
      }
      case EventScope.School: {
        classControl.setValidators(optionalPositiveIntegerValidator);
        subjectControl.setValidators(optionalPositiveIntegerValidator);
        classControl.setValue('', { emitEvent: false });
        subjectControl.setValue('', { emitEvent: false });
        break;
      }
      default: {
        classControl.setValidators(optionalPositiveIntegerValidator);
        subjectControl.setValidators(optionalPositiveIntegerValidator);
        break;
      }
    }

    classControl.updateValueAndValidity();
    subjectControl.updateValueAndValidity();
  }

  private prefillForm(range: CalendarDateRange | null): void {
    const now = new Date();
    const defaultStart = range ? new Date(range.start) : now;
    const defaultEndCandidate = range ? new Date(range.end) : addHours(defaultStart, 1);
    const defaultEnd =
      defaultEndCandidate > defaultStart ? defaultEndCandidate : addHours(defaultStart, 1);

    this.createEventForm.reset({
      title: '',
      description: '',
      start: toDateTimeLocalInput(defaultStart),
      end: toDateTimeLocalInput(defaultEnd),
      status: null,
      type: null,
      scope: null,
      classId: '',
      subjectId: '',
    });

    this.applyScopeValidators(null);
  }

  private resetFormState(): void {
    this.createEventForm.reset({
      title: '',
      description: '',
      start: '',
      end: '',
      status: null,
      type: null,
      scope: null,
      classId: '',
      subjectId: '',
    });
    this.applyScopeValidators(null);
    this.errorMessage.set(null);
  }
}
