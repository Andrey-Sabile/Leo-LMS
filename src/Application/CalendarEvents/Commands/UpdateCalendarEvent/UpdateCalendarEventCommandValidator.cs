using LeoLMS.Domain.Enums;

namespace LeoLMS.Application.CalendarEvents.Commands.UpdateCalendarEvent;

public class UpdateCalendarEventCommandValidator : AbstractValidator<UpdateCalendarEventCommand>
{
    public UpdateCalendarEventCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0);

        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(v => v.Description)
            .NotEmpty()
            .MaximumLength(2000);

        RuleFor(v => v.Start)
            .NotEqual(default(DateTimeOffset));

        RuleFor(v => v.End)
            .NotEqual(default(DateTimeOffset))
            .GreaterThan(v => v.Start);

        RuleFor(v => v)
            .Custom((command, context) =>
            {
                switch (command.Scope)
                {
                    case EventScope.School:
                        if (command.ClassId.HasValue)
                        {
                            context.AddFailure(nameof(command.ClassId), "ClassId must be null when scope is School.");
                        }

                        if (command.SubjectId.HasValue)
                        {
                            context.AddFailure(nameof(command.SubjectId), "SubjectId must be null when scope is School.");
                        }

                        break;

                    case EventScope.Class:
                        if (!command.ClassId.HasValue)
                        {
                            context.AddFailure(nameof(command.ClassId), "ClassId is required when scope is Class.");
                        }

                        if (command.SubjectId.HasValue)
                        {
                            context.AddFailure(nameof(command.SubjectId), "SubjectId must be null when scope is Class.");
                        }

                        break;

                    case EventScope.Subject:
                        if (!command.SubjectId.HasValue)
                        {
                            context.AddFailure(nameof(command.SubjectId), "SubjectId is required when scope is Subject.");
                        }

                        break;
                }
            });
    }
}
