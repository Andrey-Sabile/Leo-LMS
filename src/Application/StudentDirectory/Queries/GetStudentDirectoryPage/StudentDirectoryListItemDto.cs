using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryPage;

public class StudentDirectoryListItemDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public StudentDirectoryAddressDto Address { get; init; } = null!;

    public IReadOnlyCollection<StudentDirectoryGuardianSummaryDto> Guardians { get; init; } = Array.Empty<StudentDirectoryGuardianSummaryDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentDirectoryListItemDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(d => d.Guardians, opt => opt.MapFrom(s => s.Guardians));

            CreateMap<Guardian, StudentDirectoryGuardianSummaryDto>();
        }
    }
}

public class StudentDirectoryGuardianSummaryDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public int PhoneNumber { get; init; }
}
