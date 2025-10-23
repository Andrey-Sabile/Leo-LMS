namespace LeoLMS.Domain.Entities;

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

        if (Students.Contains(student))
            return;

        Students.Add(student);
        student.AddClassroom(this);
    }

    public void RemoveStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);

        if (!Students.Remove(student))
            return;

        student.RemoveClassroom(this);
    }

    public void AddTeacher(Teacher teacher)
    {
        ArgumentNullException.ThrowIfNull(teacher);

        if (Teachers.Contains(teacher))
            return;

        Teachers.Add(teacher);
        teacher.AddClassroom(this);
    }

    public void RemoveTeacher(Teacher teacher)
    {
        ArgumentNullException.ThrowIfNull(teacher);

        if (!Teachers.Remove(teacher))
            return;

        teacher.RemoveClassroom(this);
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
