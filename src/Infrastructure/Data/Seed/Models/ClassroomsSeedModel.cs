using System.Collections.Generic;

namespace LeoLMS.Infrastructure.Data.Seed.Models;

public class ClassroomsSeedModel
{
    public IList<ClassroomSeedItem> Classrooms { get; init; } = new List<ClassroomSeedItem>();
}

public class ClassroomSeedItem
{
    public string Name { get; init; } = string.Empty;

    public string SubjectCode { get; init; } = string.Empty;

    public string TeacherEmail { get; init; } = string.Empty;

    public string? Description { get; init; }
}
