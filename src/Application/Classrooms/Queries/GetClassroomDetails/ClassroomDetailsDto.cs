using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.Classrooms.Queries.GetClassroomDetails;

public class ClassroomDetailsDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public int SubjectId { get; init; }

    public int TeacherId { get; init; }

    public DateTimeOffset CreatedOn { get; init; }

    public IReadOnlyCollection<ClassroomTeacherDto> Teachers { get; init; } = Array.Empty<ClassroomTeacherDto>();

    public IReadOnlyCollection<ClassroomStudentDto> Students { get; init; } = Array.Empty<ClassroomStudentDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Classroom, ClassroomDetailsDto>()
                .ForMember(d => d.Teachers, opt => opt.MapFrom(source => source.Teachers))
                .ForMember(d => d.Students, opt => opt.MapFrom(source => source.Students));

            CreateMap<Teacher, ClassroomTeacherDto>();
            CreateMap<Student, ClassroomStudentDto>();
        }
    }
}

public class ClassroomTeacherDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;
}

public class ClassroomStudentDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;
}
