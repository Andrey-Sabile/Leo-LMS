using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Classrooms.Commands.AddStudentToClassroom;

public record AddStudentToClassroomCommand(int ClassroomId, int StudentId) : IRequest;

public class AddStudentToClassroomCommandValidator : AbstractValidator<AddStudentToClassroomCommand>
{
    public AddStudentToClassroomCommandValidator()
    {
        RuleFor(command => command.ClassroomId)
            .GreaterThan(0);

        RuleFor(command => command.StudentId)
            .GreaterThan(0);
    }
}

public class AddStudentToClassroomCommandHandler : IRequestHandler<AddStudentToClassroomCommand>
{
    private readonly IApplicationDbContext _context;

    public AddStudentToClassroomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddStudentToClassroomCommand request, CancellationToken cancellationToken)
    {
        var classroom = await _context.Classrooms
            .Include(c => c.Students)
            .SingleOrDefaultAsync(c => c.Id == request.ClassroomId, cancellationToken);

        Guard.Against.NotFound(request.ClassroomId, classroom);

        var student = await _context.Students
            .Include(s => s.Classrooms)
            .SingleOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

        Guard.Against.NotFound(request.StudentId, student);

        classroom!.AddStudent(student!);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
