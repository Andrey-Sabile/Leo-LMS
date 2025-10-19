using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Guardians.Commands.UpdateGuardian;

public record UpdateGuardianCommand : IRequest
{
    public int Id { get; init; }

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

public class UpdateGuardianCommandValidator : AbstractValidator<UpdateGuardianCommand>
{
    public UpdateGuardianCommandValidator()
    {
    }
}

public class UpdateGuardianCommandHandler : IRequestHandler<UpdateGuardianCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateGuardianCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateGuardianCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Guardians
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var address = Address.Create(
            request.Street1,
            request.Street2,
            request.City,
            request.State,
            request.PostalCode,
            request.Country);

        entity.UpdateDetails(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            entity.Students,
            address);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
