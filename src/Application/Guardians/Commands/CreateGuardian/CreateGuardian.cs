using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Guardians.Commands.CreateGuardian;

public record CreateGuardianCommand : IRequest<int>
{
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public int PhoneNumber { get; init; }

    public string Street1 { get; init; } = string.Empty;

    public string Street2 { get; init; } = string.Empty;

    public string City { get; init; } = string.Empty;

    public string State { get; init; } = string.Empty;

    public int PostalCode { get; init; }

    public string Country { get; init; } = string.Empty;

}

public class CreateGuardianCommandValidator : AbstractValidator<CreateGuardianCommand>
{
    public CreateGuardianCommandValidator()
    {
    }
}

public class CreateGuardianCommandHandler : IRequestHandler<CreateGuardianCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateGuardianCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateGuardianCommand request, CancellationToken cancellationToken)
    {
        var address = Address.Create(
            request.Street1,
            request.Street2,
            request.City,
            request.State,
            request.PostalCode,
            request.Country
        );

        var entity = Guardian.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            [],
            address);

        _context.Guardians.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
