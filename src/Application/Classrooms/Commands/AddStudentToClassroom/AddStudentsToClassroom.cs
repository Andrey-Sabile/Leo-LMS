using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Classrooms.Commands.AddStudentToClassroom;

public record AddStudentsToClassroomCommand(int ClassroomId, IReadOnlyCollection<int> StudentIds) : IRequest;

public class AddStudentToClassroomCommandValidator : AbstractValidator<AddStudentsToClassroomCommand>
{
    public AddStudentToClassroomCommandValidator()
    {
        RuleFor(command => command.ClassroomId)
            .GreaterThan(0);

        RuleFor(command => command.StudentIds)
            .NotNull()
            .Must(ids => ids.Any())
            .WithMessage("At least one student must be provided.");

        RuleForEach(command => command.StudentIds)
            .GreaterThan(0);
    }
}

public class AddStudentToClassroomCommandHandler : IRequestHandler<AddStudentsToClassroomCommand>
{
    private readonly IApplicationDbContext _context;

    public AddStudentToClassroomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddStudentsToClassroomCommand request, CancellationToken cancellationToken)
    {
        var classroom = await _context.Classrooms
            .Include(c => c.Students)
            .SingleOrDefaultAsync(c => c.Id == request.ClassroomId, cancellationToken);

        Guard.Against.NotFound(request.ClassroomId, classroom);

        var studentIds = request.StudentIds.Distinct().ToList();

        var students = await _context.Students
            .Include(s => s.Classrooms)
            .Where(s => studentIds.Contains(s.Id))
            .ToListAsync(cancellationToken);

        foreach (var studentId in studentIds)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            Guard.Against.NotFound(studentId, student);

            classroom!.AddStudent(student!);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
