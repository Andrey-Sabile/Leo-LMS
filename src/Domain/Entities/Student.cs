namespace LeoLMS.Domain.Entities;

public class Student : BaseAuditableEntity
{
    private Student() { }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public IList<Guardian> Guardians { get; private set; } = [];
    public Address Address { get; private set; } = null!;

    // Factory Create

    // Update

    // Soft Delete

    // Guard against removal of final guardian? not sure if we should implement it here

}