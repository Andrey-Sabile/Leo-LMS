using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.Classrooms.Commands.CreateClassroom;

public record CreateClassroomCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public int SubjectId { get; init; }

    public int TeacherId { get; init; }
}

public class CreateClassroomCommandValidator : AbstractValidator<CreateClassroomCommand>
{
    public CreateClassroomCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty();

        RuleFor(command => command.SubjectId)
            .GreaterThan(0);

        RuleFor(command => command.TeacherId)
            .GreaterThan(0);
    }
}

public class CreateClassroomCommandHandler : IRequestHandler<CreateClassroomCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateClassroomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
    {
        var entity = Classroom.Create(
            request.Name,
            request.SubjectId,
            request.TeacherId,
            request.Description);

        _context.Classrooms.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
