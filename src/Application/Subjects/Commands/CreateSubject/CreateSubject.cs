using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.Subjects.Commands.CreateSubject;

public record CreateSubjectCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;

    public string Code { get; init; } = string.Empty;

    public string? Description { get; init; }
}

public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
{
    public CreateSubjectCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty();

        RuleFor(v => v.Code)
            .NotEmpty();
    }
}

public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSubjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var entity = Subject.Create(
            request.Name,
            request.Code,
            request.Description);

        _context.Subjects.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
