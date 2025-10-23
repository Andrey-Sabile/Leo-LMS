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

    // Placeholder collection for future member assignments
    public IList<int> MemberIds { get; private set; } = [];

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
