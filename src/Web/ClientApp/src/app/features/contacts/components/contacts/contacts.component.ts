import { ChangeDetectionStrategy, Component, effect, inject, signal } from '@angular/core';
import { GuardiansClient, StudentsClient, StudentDto } from '@app/data-access/api/api-client';

@Component({
  selector: 'app-contacts',
  standalone: true,
  imports: [],
  templateUrl: './contacts.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactsComponent {
  private studentsClient = inject(StudentsClient);
  readonly students = signal<StudentDto[]>([]);

  private readonly refreshStudentsEffect = effect(
    () => {
      this.loadStudents();
    },
    { allowSignalWrites: true }
  );

  private loadStudents(): void {
    this.studentsClient.getStudents()
      .subscribe({
        next: result => this.students.set(result.students),
        error: error => console.error(error),
      });
  }
}
