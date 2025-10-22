using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.Subjects.Queries.GetSubjects;

public class SubjectDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Code { get; init; } = string.Empty;

    public string? Description { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Subject, SubjectDto>();
        }
    }
}
