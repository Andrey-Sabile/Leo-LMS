namespace LeoLMS.Domain.Entities;

public class Classroom : BaseAuditableEntity
{
    private Classroom() { }

    public string Name { get; private set; } = null!;
    public IList<Student> Students { get; private set; } = [];
    public Teacher Teacher { get; private set; } = null!;
}