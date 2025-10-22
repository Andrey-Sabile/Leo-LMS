using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Classrooms.Commands.UpdateClassroom;

public record UpdateClassroomCommand : IRequest
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public int SubjectId { get; init; }

    public int TeacherId { get; init; }
}

public class UpdateClassroomCommandValidator : AbstractValidator<UpdateClassroomCommand>
{
    public UpdateClassroomCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);

        RuleFor(command => command.Name)
            .NotEmpty();

        RuleFor(command => command.SubjectId)
            .GreaterThan(0);

        RuleFor(command => command.TeacherId)
            .GreaterThan(0);
    }
}

public class UpdateClassroomCommandHandler : IRequestHandler<UpdateClassroomCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateClassroomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Classrooms
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.UpdateDetails(
            request.Name,
            request.SubjectId,
            request.TeacherId,
            request.Description);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
