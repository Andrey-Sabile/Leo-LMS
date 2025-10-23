using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Classrooms.Commands.RemoveStudentFromClassroom;

public record RemoveStudentFromClassroomCommand(int ClassroomId, int StudentId) : IRequest;

public class RemoveStudentFromClassroomCommandValidator : AbstractValidator<RemoveStudentFromClassroomCommand>
{
    public RemoveStudentFromClassroomCommandValidator()
    {
        RuleFor(command => command.ClassroomId)
            .GreaterThan(0);

        RuleFor(command => command.StudentId)
            .GreaterThan(0);
    }
}

public class RemoveStudentFromClassroomCommandHandler : IRequestHandler<RemoveStudentFromClassroomCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveStudentFromClassroomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveStudentFromClassroomCommand request, CancellationToken cancellationToken)
    {
        var classroom = await _context.Classrooms
            .Include(c => c.Students)
            .SingleOrDefaultAsync(c => c.Id == request.ClassroomId, cancellationToken);

        Guard.Against.NotFound(request.ClassroomId, classroom);

        var student = await _context.Students
            .Include(s => s.Classrooms)
            .SingleOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

        Guard.Against.NotFound(request.StudentId, student);

        classroom!.RemoveStudent(student!);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
