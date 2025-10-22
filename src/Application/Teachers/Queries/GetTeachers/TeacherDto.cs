using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Teachers.Queries.GetTeachers;

public class TeacherDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public int PhoneNumber { get; init; }

    public TeacherAddressDto Address { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Teacher, TeacherDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(t => t.Address));

            CreateMap<Address, TeacherAddressDto>();
        }
    }
}

public class TeacherAddressDto
{
    public string Street1 { get; init; } = string.Empty;
    public string Street2 { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public int PostalCode { get; init; }
    public string Country { get; init; } = string.Empty;
}
