using AutoMapper;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.StudentDirectory.Queries;

public class StudentDirectoryAddressDto
{
    public string Street1 { get; init; } = string.Empty;

    public string Street2 { get; init; } = string.Empty;

    public string City { get; init; } = string.Empty;

    public string State { get; init; } = string.Empty;

    public int PostalCode { get; init; }

    public string Country { get; init; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Address, StudentDirectoryAddressDto>();
        }
    }
}
