using System.Collections.Generic;

namespace LeoLMS.Infrastructure.Data.Seed.Models;

public class SubjectsSeedModel
{
    public IList<SubjectSeedItem> Subjects { get; init; } = new List<SubjectSeedItem>();
}

public class SubjectSeedItem
{
    public string Name { get; init; } = string.Empty;

    public string Code { get; init; } = string.Empty;

    public string? Description { get; init; }
}
