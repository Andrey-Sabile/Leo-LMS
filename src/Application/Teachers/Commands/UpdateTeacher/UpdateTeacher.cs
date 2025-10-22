using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Teachers.Commands.UpdateTeacher;

public record UpdateTeacherCommand : IRequest
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

public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
{
    public UpdateTeacherCommandValidator()
    {
    }
}

public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTeacherCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Teachers
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
            address,
            entity.Classrooms);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
