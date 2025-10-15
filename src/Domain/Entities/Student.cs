namespace LeoLMS.Domain.Entities;

public class Student : BaseAuditableEntity
{
    private Student() { }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public IList<Guardian> Guardians { get; private set; } = [];
    public Address Address { get; private set; } = null!;

    public static Student Create(
        string firstName,
        string lastName,
        string email,
        IList<Guardian> guardians,
        Address address
    )
    {
        var student = new Student();
        student.SetDetails(firstName, lastName, email, guardians, address);
        return student;
    }

    public void UpdateDetails(
        string firstName,
        string lastName,
        string email,
        IList<Guardian> guardians,
        Address address
    )
    {
        SetDetails(firstName, lastName, email, guardians, address);
    }

    private void SetDetails(
        string firstName,
        string lastName,
        string email,
        IList<Guardian> guardians,
        Address address
    )
    {
        ValidateFields(firstName, lastName, email, address, guardians);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Guardians = guardians;
        Address = address;
    }

    private static void ValidateFields(string firstName, string lastName, string email, Address address, IList<Guardian> guardians)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName is required.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("LastName is required.", nameof(lastName));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("email is required.", nameof(email));

        ArgumentNullException.ThrowIfNull(address);

        ArgumentNullException.ThrowIfNull(guardians);
    }

    // Soft Delete

    // Guard against removal of final guardian? not sure if we should implement it here

}