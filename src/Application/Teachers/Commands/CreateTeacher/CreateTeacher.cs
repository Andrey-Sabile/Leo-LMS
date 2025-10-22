using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Teachers.Commands.CreateTeacher;

public record CreateTeacherCommand : IRequest<int>
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

public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
{
    public CreateTeacherCommandValidator()
    {
    }
}

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTeacherCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var address = Address.Create(
            request.Street1,
            request.Street2,
            request.City,
            request.State,
            request.PostalCode,
            request.Country);

        var entity = Teacher.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            address,
            []);

        _context.Teachers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
