namespace LeoLMS.Infrastructure.Data.Seed.Models;

public class StudentDirectorySeedModel
{
    public IList<StudentSeedModel> Students { get; init; } = new List<StudentSeedModel>();
}

public class StudentSeedModel
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public AddressSeedModel Address { get; init; } = new();

    public IList<GuardianSeedModel> Guardians { get; init; } = new List<GuardianSeedModel>();
}

public class GuardianSeedModel
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public int PhoneNumber { get; init; }

    public AddressSeedModel Address { get; init; } = new();
}

public class AddressSeedModel
{
    public string Street1 { get; init; } = string.Empty;

    public string Street2 { get; init; } = string.Empty;

    public string City { get; init; } = string.Empty;

    public string State { get; init; } = string.Empty;

    public int PostalCode { get; init; }

    public string Country { get; init; } = string.Empty;
}
