namespace LeoLMS.Domain.Entities;

public class Student : BaseAuditableEntity
{
    private Student() { }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public IList<Guardian> Guardians { get; private set; } = new List<Guardian>();
    public IList<Classroom> Classrooms { get; private set; } = new List<Classroom>();
    public Address Address { get; private set; } = null!;

    public static Student Create(
        string firstName,
        string lastName,
        string email,
        Address address
    )
    {
        var student = new Student();
        student.SetDetails(firstName, lastName, email, address);
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
        SetDetails(firstName, lastName, email, address);
    }

    private void SetDetails(
        string firstName,
        string lastName,
        string email,
        Address address
    )
    {
        ValidateFields(firstName, lastName, email, address);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
    }

    private static void ValidateFields(string firstName, string lastName, string email, Address address)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName is required.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("LastName is required.", nameof(lastName));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("email is required.", nameof(email));

        ArgumentNullException.ThrowIfNull(address);
    }

    // Soft Delete

    // Guard against removal of final guardian? not sure if we should implement it here

    internal void AddClassroom(Classroom classroom)
    {
        ArgumentNullException.ThrowIfNull(classroom);

        if (Classrooms.Contains(classroom))
            return;

        Classrooms.Add(classroom);
    }

    internal void RemoveClassroom(Classroom classroom)
    {
        ArgumentNullException.ThrowIfNull(classroom);

        Classrooms.Remove(classroom);
    }

}
