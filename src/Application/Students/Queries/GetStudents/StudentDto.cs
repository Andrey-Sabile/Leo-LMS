using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Students.Queries.GetStudents;

public class StudentDto
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public StudentAddressDto Address { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address));

            CreateMap<Address, StudentAddressDto>();
        }
    }
}

public class StudentAddressDto
{
    public string Street1 { get; init; } = string.Empty;
    public string Street2 { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public int PostalCode { get; init; }
    public string Country { get; init; } = string.Empty;
}
