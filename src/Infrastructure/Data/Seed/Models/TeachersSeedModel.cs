using System.Collections.Generic;

namespace LeoLMS.Infrastructure.Data.Seed.Models;

public class TeachersSeedModel
{
    public IList<TeacherSeedItem> Teachers { get; init; } = new List<TeacherSeedItem>();
}

public class TeacherSeedItem
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public int PhoneNumber { get; init; }

    public AddressSeedModel Address { get; init; } = new();
}
