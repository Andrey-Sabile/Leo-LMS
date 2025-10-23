using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Classrooms.Commands.AddTeacherToClassroom;

public record AddTeacherToClassroomCommand(int ClassroomId, int TeacherId) : IRequest;

public class AddTeacherToClassroomCommandValidator : AbstractValidator<AddTeacherToClassroomCommand>
{
    public AddTeacherToClassroomCommandValidator()
    {
        RuleFor(command => command.ClassroomId)
            .GreaterThan(0);

        RuleFor(command => command.TeacherId)
            .GreaterThan(0);
    }
}

public class AddTeacherToClassroomCommandHandler : IRequestHandler<AddTeacherToClassroomCommand>
{
    private readonly IApplicationDbContext _context;

    public AddTeacherToClassroomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddTeacherToClassroomCommand request, CancellationToken cancellationToken)
    {
        var classroom = await _context.Classrooms
            .Include(c => c.Teachers)
            .SingleOrDefaultAsync(c => c.Id == request.ClassroomId, cancellationToken);

        Guard.Against.NotFound(request.ClassroomId, classroom);

        var teacher = await _context.Teachers
            .Include(t => t.Classrooms)
            .SingleOrDefaultAsync(t => t.Id == request.TeacherId, cancellationToken);

        Guard.Against.NotFound(request.TeacherId, teacher);

        classroom!.AddTeacher(teacher!);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
