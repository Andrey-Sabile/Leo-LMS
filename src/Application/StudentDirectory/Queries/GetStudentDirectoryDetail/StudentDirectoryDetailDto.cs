using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryDetail;

public class StudentDirectoryDetailDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public StudentDirectoryAddressDto Address { get; init; } = null!;

    public IReadOnlyCollection<StudentDirectoryGuardianDto> Guardians { get; init; } = Array.Empty<StudentDirectoryGuardianDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentDirectoryDetailDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(d => d.Guardians, opt => opt.MapFrom(s => s.Guardians));

            CreateMap<Guardian, StudentDirectoryGuardianDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address));
        }
    }
}

public class StudentDirectoryGuardianDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public int PhoneNumber { get; init; }

    public StudentDirectoryAddressDto Address { get; init; } = null!;
}
