using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using FluentValidation;
using LeoLMS.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeoLMS.Application.Classrooms.Commands.AddTeacherToClassroom;

public record AddTeacherToClassroomCommand(int ClassroomId, IReadOnlyCollection<int> TeacherIds) : IRequest;

public class AddTeacherToClassroomCommandValidator : AbstractValidator<AddTeacherToClassroomCommand>
{
    public AddTeacherToClassroomCommandValidator()
    {
        RuleFor(command => command.ClassroomId)
            .GreaterThan(0);

        RuleFor(command => command.TeacherIds)
            .NotNull()
            .Must(ids => ids.Any())
            .WithMessage("At least one teacher must be provided.");

        RuleForEach(command => command.TeacherIds)
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

        var teacherIds = request.TeacherIds.Distinct().ToList();

        var teachers = await _context.Teachers
            .Include(t => t.Classrooms)
            .Where(t => teacherIds.Contains(t.Id))
            .ToListAsync(cancellationToken);

        foreach (var teacherId in teacherIds)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);
            Guard.Against.NotFound(teacherId, teacher);

            classroom!.AddTeacher(teacher!);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
