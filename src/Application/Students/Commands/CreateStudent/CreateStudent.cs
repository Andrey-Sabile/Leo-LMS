using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.Students.Commands.CreateStudent;

public record CreateStudentCommand : IRequest<int>
{
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

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {

    }
}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var address = Address.Create(
            request.Street1,
            request.Street2,
            request.City,
            request.State,
            request.PostalCode,
            request.Country
        );

        var entity = Student.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            address
        );

        _context.Students.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
