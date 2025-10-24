namespace LeoLMS.Domain.Entities;

using System.Collections.Generic;
using System.Linq;
using LeoLMS.Domain.Events;

public class Classroom : BaseAuditableEntity
{
    private Classroom()
    {
    }

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public int SubjectId { get; private set; }

    public int TeacherId { get; private set; }

    public IList<Student> Students { get; private set; } = new List<Student>();

    public IList<Teacher> Teachers { get; private set; } = new List<Teacher>();

    public void AddStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);

        if (IsStudentAlreadyAssigned(student))
            return;

        Students.Add(student);
        student.AddClassroom(this);
    }

    public void AddStudents(IEnumerable<Student> students)
    {
        ArgumentNullException.ThrowIfNull(students);

        foreach (var student in students)
        {
            AddStudent(student);
        }
    }

    public void RemoveStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);

        var studentInClassroom = FindStudent(student);

        if (studentInClassroom is null)
            return;

        Students.Remove(studentInClassroom);
        studentInClassroom.RemoveClassroom(this);
    }

    public void AddTeacher(Teacher teacher)
    {
        ArgumentNullException.ThrowIfNull(teacher);

        if (IsTeacherAlreadyAssigned(teacher))
            return;

        Teachers.Add(teacher);
        teacher.AddClassroom(this);
    }

    public void AddTeachers(IEnumerable<Teacher> teachers)
    {
        ArgumentNullException.ThrowIfNull(teachers);

        foreach (var teacher in teachers)
        {
            AddTeacher(teacher);
        }
    }

    public void RemoveTeacher(Teacher teacher)
    {
        ArgumentNullException.ThrowIfNull(teacher);

        var teacherInClassroom = FindTeacher(teacher);

        if (teacherInClassroom is null)
            return;

        Teachers.Remove(teacherInClassroom);
        teacherInClassroom.RemoveClassroom(this);
    }

    private bool IsStudentAlreadyAssigned(Student student)
    {
        if (student.Id == 0)
        {
            return Students.Contains(student);
        }

        return Students.Any(existing => existing.Id == student.Id);
    }

    private Student? FindStudent(Student student)
    {
        if (student.Id == 0)
        {
            return Students.Contains(student) ? student : null;
        }

        return Students.FirstOrDefault(existing => existing.Id == student.Id);
    }

    private bool IsTeacherAlreadyAssigned(Teacher teacher)
    {
        if (teacher.Id == 0)
        {
            return Teachers.Contains(teacher);
        }

        return Teachers.Any(existing => existing.Id == teacher.Id);
    }

    private Teacher? FindTeacher(Teacher teacher)
    {
        if (teacher.Id == 0)
        {
            return Teachers.Contains(teacher) ? teacher : null;
        }

        return Teachers.FirstOrDefault(existing => existing.Id == teacher.Id);
    }

    public static Classroom Create(
        string name,
        int subjectId,
        int teacherId,
        string? description = null)
    {
        var classroom = new Classroom();

        classroom.SetDetails(name, subjectId, teacherId, description);
        classroom.AddDomainEvent(new ClassroomCreatedEvent(classroom));

        return classroom;
    }

    public void UpdateDetails(
        string name,
        int subjectId,
        int teacherId,
        string? description = null)
    {
        SetDetails(name, subjectId, teacherId, description);
    }

    private void SetDetails(
        string name,
        int subjectId,
        int teacherId,
        string? description)
    {
        ValidateFields(name, subjectId, teacherId);

        Name = name.Trim();
        Description = NormalizeDescription(description);
        SubjectId = subjectId;
        TeacherId = teacherId;
    }

    private static void ValidateFields(string name, int subjectId, int teacherId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        if (subjectId <= 0)
            throw new ArgumentException("SubjectId must be greater than zero.", nameof(subjectId));

        if (teacherId <= 0)
            throw new ArgumentException("TeacherId must be greater than zero.", nameof(teacherId));
    }

    private static string? NormalizeDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return null;

        return description.Trim();
    }
}
