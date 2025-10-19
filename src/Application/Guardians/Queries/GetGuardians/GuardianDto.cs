using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Guardians.Queries.GetGuardians;

public class GuardianDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public int PhoneNumber { get; init; }

    public GuardianAddressDto Address { get; init; } = null!;

    public IReadOnlyCollection<GuardianStudentDto> Students { get; init; } = Array.Empty<GuardianStudentDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Guardian, GuardianDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(d => d.Students, opt => opt.MapFrom(s => s.Students));

            CreateMap<Address, GuardianAddressDto>();
            CreateMap<Student, GuardianStudentDto>();
        }
    }
}

public class GuardianAddressDto
{
    public string Street1 { get; init; } = string.Empty;
    public string Street2 { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public int PostalCode { get; init; }
    public string Country { get; init; } = string.Empty;
}

public class GuardianStudentDto
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}
