using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Subjects.Commands.UpdateSubject;

public record UpdateSubjectCommand : IRequest
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Code { get; init; } = string.Empty;

    public string? Description { get; init; }
}

public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
{
    public UpdateSubjectCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0);

        RuleFor(v => v.Name)
            .NotEmpty();

        RuleFor(v => v.Code)
            .NotEmpty();
    }
}

public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSubjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Subjects
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.UpdateDetails(
            request.Name,
            request.Code,
            request.Description);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
