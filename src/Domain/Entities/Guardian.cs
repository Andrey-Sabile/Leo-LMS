namespace LeoLMS.Domain.Entities;

public class Guardian : BaseAuditableEntity
{
    private Guardian() { }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public int PhoneNumber { get; private set; }
    public IList<Student> Students { get; private set; } = [];
    public Address Address { get; private set; } = null!;
}