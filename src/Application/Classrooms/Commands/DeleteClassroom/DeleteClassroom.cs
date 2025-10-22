using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Classrooms.Commands.DeleteClassroom;

public record DeleteClassroomCommand(int Id) : IRequest;

public class DeleteClassroomCommandValidator : AbstractValidator<DeleteClassroomCommand>
{
    public DeleteClassroomCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0);
    }
}

public class DeleteClassroomCommandHandler : IRequestHandler<DeleteClassroomCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteClassroomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Classrooms
            .Where(c => c.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Classrooms.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
