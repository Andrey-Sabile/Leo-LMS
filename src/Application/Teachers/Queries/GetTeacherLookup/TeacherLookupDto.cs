using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.Teachers.Queries.GetTeacherLookup;

public class TeacherLookupDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Teacher, TeacherLookupDto>();
        }
    }
}
