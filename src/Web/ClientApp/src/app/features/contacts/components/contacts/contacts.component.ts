import { ChangeDetectionStrategy, Component, effect, inject, signal } from '@angular/core';
import { StudentDirectoryClient, StudentDirectoryListItemDto } from '@app/data-access/api/api-client';

@Component({
  selector: 'app-contacts',
  standalone: true,
  imports: [],
  templateUrl: './contacts.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactsComponent {
  private readonly studentDirectoryClient = inject(StudentDirectoryClient);
  readonly students = signal<StudentDirectoryListItemDto[]>([]);

  private readonly refreshStudentsEffect = effect(
    () => {
      this.loadStudents();
    },
    { allowSignalWrites: true }
  );

  private loadStudents(): void {
    this.studentDirectoryClient
      .getStudentDirectoryPage(null, 1, 25)
      .subscribe({
        next: result => this.students.set(result.items ?? []),
        error: error => console.error(error),
      });
  }
}
