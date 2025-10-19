using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Students.Commands.UpdateStudent;

public record UpdateStudentCommand : IRequest
{
    public int Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public string Street1 { get; init; } = string.Empty;

    public string Street2 { get; init; } = string.Empty;

    public string City { get; init; } = string.Empty;

    public string State { get; init; } = string.Empty;

    public int PostalCode { get; init; }

    public string Country { get; init; } = string.Empty;
}

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
    }
}

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Students
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
            entity.Guardians,
            address);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
