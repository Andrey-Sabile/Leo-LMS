import { ChangeDetectionStrategy, Component, computed, effect, inject, signal } from '@angular/core';
import { StudentDirectoryClient, StudentDirectoryListItemDto } from '@app/data-access/api/api-client';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-student-directory',

  imports: [],
  templateUrl: './student-directory.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class StudentDirectoryComponent {
  private readonly studentDirectoryClient = inject(StudentDirectoryClient);
  readonly students = signal<StudentDirectoryListItemDto[]>([]);
  readonly selectedStudent = signal<StudentDirectoryListItemDto | null>(null);
  readonly isLoading = signal(false);
  readonly searchQuery = signal('');
  readonly selectedStudentFullName = computed(() => {
    const student = this.selectedStudent();
    if (!student) {
      return '';
    }

    const first = student.firstName ?? '';
    const last = student.lastName ?? '';
    return `${first} ${last}`.trim();
  });

  private readonly refreshStudentsEffect = effect(
    () => {
      const search = this.searchQuery();
      this.loadStudents(search);
    },
    { allowSignalWrites: true }
  );

  selectStudent(student: StudentDirectoryListItemDto): void {
    this.selectedStudent.set(student);
  }

  isStudentSelected(student: StudentDirectoryListItemDto): boolean {
    const current = this.selectedStudent();
    if (!current) {
      return false;
    }

    if (current.id != null && student.id != null) {
      return current.id === student.id;
    }

    return !!current.email && !!student.email && current.email === student.email;
  }

  getStudentInitials(student: StudentDirectoryListItemDto | null): string {
    if (!student) {
      return '';
    }

    const firstInitial = student.firstName?.charAt(0) ?? '';
    const lastInitial = student.lastName?.charAt(0) ?? '';
    const initials = `${firstInitial}${lastInitial}`.trim();

    return initials || (firstInitial || lastInitial || '?');
  }

  onSearchChange(value: string): void {
    this.searchQuery.set(value);
  }

  private loadStudents(search: string): void {
    this.isLoading.set(true);
    this.studentDirectoryClient
      .getStudentDirectoryPage(search || null, 1, 25)
      .pipe(finalize(() => this.isLoading.set(false)))
      .subscribe({
        next: result => {
          const items = result.items ?? [];
          this.students.set(items);
          this.syncSelection(items);
        },
        error: error => {
          console.error(error);
          this.students.set([]);
          this.selectedStudent.set(null);
        },
      });
  }

  private syncSelection(items: StudentDirectoryListItemDto[]): void {
    const current = this.selectedStudent();

    if (!items.length) {
      this.selectedStudent.set(null);
      return;
    }

    if (!current) {
      this.selectedStudent.set(items[0]);
      return;
    }

    const match = items.find(item => {
      if (item.id != null && current.id != null) {
        return item.id === current.id;
      }

      return item.email && current.email ? item.email === current.email : false;
    });

    this.selectedStudent.set(match ?? items[0]);
  }

  getAddressLines(address?: StudentDirectoryListItemDto['address']): string[] {
    if (!address) {
      return [];
    }

    const lines: string[] = [];

    if (address.street1) {
      lines.push(address.street1);
    }

    if (address.street2) {
      lines.push(address.street2);
    }

    const citySegments: string[] = [];

    if (address.city) {
      citySegments.push(address.city);
    }

    const stateAndPostal: string[] = [];

    if (address.state) {
      stateAndPostal.push(address.state);
    }

    if (address.postalCode !== undefined && address.postalCode !== null) {
      stateAndPostal.push(address.postalCode.toString());
    }

    if (stateAndPostal.length) {
      citySegments.push(stateAndPostal.join(' '));
    }

    if (citySegments.length) {
      lines.push(citySegments.join(', '));
    }

    if (address.country) {
      lines.push(address.country);
    }

    return lines;
  }
}
