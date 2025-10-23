using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Classrooms.Commands.RemoveTeacherFromClassroom;

public record RemoveTeacherFromClassroomCommand(int ClassroomId, int TeacherId) : IRequest;

public class RemoveTeacherFromClassroomCommandValidator : AbstractValidator<RemoveTeacherFromClassroomCommand>
{
    public RemoveTeacherFromClassroomCommandValidator()
    {
        RuleFor(command => command.ClassroomId)
            .GreaterThan(0);

        RuleFor(command => command.TeacherId)
            .GreaterThan(0);
    }
}

public class RemoveTeacherFromClassroomCommandHandler : IRequestHandler<RemoveTeacherFromClassroomCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveTeacherFromClassroomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveTeacherFromClassroomCommand request, CancellationToken cancellationToken)
    {
        var classroom = await _context.Classrooms
            .Include(c => c.Teachers)
            .SingleOrDefaultAsync(c => c.Id == request.ClassroomId, cancellationToken);

        Guard.Against.NotFound(request.ClassroomId, classroom);

        var teacher = await _context.Teachers
            .Include(t => t.Classrooms)
            .SingleOrDefaultAsync(t => t.Id == request.TeacherId, cancellationToken);

        Guard.Against.NotFound(request.TeacherId, teacher);

        classroom!.RemoveTeacher(teacher!);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
