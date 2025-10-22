using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.Classrooms.Queries.GetClassrooms;

public class ClassroomDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public int SubjectId { get; init; }

    public int TeacherId { get; init; }

    public DateTimeOffset CreatedOn { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Classroom, ClassroomDto>();
        }
    }
}
