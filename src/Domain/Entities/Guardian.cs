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

    public static Guardian Create(
    string firstName,
    string lastName,
    string email,
    int phoneNumber,
    IList<Student> students,
    Address address
    )
    {
        var guardian = new Guardian();
        guardian.SetDetails(firstName, lastName, email, phoneNumber, students, address);
        return guardian;
    }

    private void SetDetails(
        string firstName,
        string lastName,
        string email,
        int phoneNumber,
        IList<Student> students,
        Address address
    )
    {
        ValidateFields(firstName, lastName, email, phoneNumber, students, address);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Students = students;
        Address = address;
    }

    private static void ValidateFields(string firstName, string lastName, string email, int phoneNumber, IList<Student> students, Address address)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName is required.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("LastName is required.", nameof(lastName));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("email is required.", nameof(email));

        ArgumentNullException.ThrowIfNull(address);

        ArgumentNullException.ThrowIfNull(students);
    }

    // Soft Delete

    // Guard against removal of final student? not sure if we should implement it here


}