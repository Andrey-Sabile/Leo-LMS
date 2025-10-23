namespace LeoLMS.Domain.Entities;

public class Teacher : BaseAuditableEntity
{
    private Teacher() { }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public int PhoneNumber { get; private set; }
    public Address Address { get; private set; } = null!;
    public IList<Classroom> Classrooms { get; private set; } = new List<Classroom>();

    public static Teacher Create(
        string firstName,
        string lastName,
        string email,
        int phoneNumber,
        Address address,
        IList<Classroom> classrooms
    )
    {
        var teacher = new Teacher();
        teacher.SetDetails(firstName, lastName, email, phoneNumber, address, classrooms);
        return teacher;
    }

    public void UpdateDetails(
        string firstName,
        string lastName,
        string email,
        int phoneNumber,
        Address address,
        IList<Classroom> classrooms
    )
    {
        SetDetails(firstName, lastName, email, phoneNumber, address, classrooms);
    }

    private void SetDetails(
        string firstName,
        string lastName,
        string email,
        int phoneNumber,
        Address address,
        IList<Classroom> classrooms
    )
    {
        ValidateFields(firstName, lastName, email, address, classrooms);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    private static void ValidateFields(string firstName, string lastName, string email, Address address, IList<Classroom> classrooms)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName is required.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("LastName is required.", nameof(lastName));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("email is required.", nameof(email));

        ArgumentNullException.ThrowIfNull(address);
        ArgumentNullException.ThrowIfNull(classrooms);
    }

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
