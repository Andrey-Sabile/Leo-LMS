using LeoLMS.Domain.Enums;

namespace LeoLMS.Application.CalendarEvents.Queries.GetCalendarEventsWithPagination;

public class GetCalendarEventsWithPaginationQueryValidator : AbstractValidator<GetCalendarEventsWithPaginationQuery>
{
    public GetCalendarEventsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");

        RuleFor(x => x)
            .Must(x => !x.Start.HasValue || !x.End.HasValue || x.Start <= x.End)
            .WithMessage("Start must be earlier than or equal to End.");

        RuleFor(x => x)
            .Custom((query, context) =>
            {
                switch (query.Scope)
                {
                    case EventScope.School:
                        if (query.ClassId.HasValue)
                        {
                            context.AddFailure(nameof(query.ClassId), "ClassId must be null when scope is School.");
                        }

                        if (query.SubjectId.HasValue)
                        {
                            context.AddFailure(nameof(query.SubjectId), "SubjectId must be null when scope is School.");
                        }

                        break;

                    case EventScope.Class:
                        if (!query.ClassId.HasValue)
                        {
                            context.AddFailure(nameof(query.ClassId), "ClassId is required when scope is Class.");
                        }

                        if (query.SubjectId.HasValue)
                        {
                            context.AddFailure(nameof(query.SubjectId), "SubjectId must be null when scope is Class.");
                        }

                        break;

                    case EventScope.Subject:
                        if (!query.SubjectId.HasValue)
                        {
                            context.AddFailure(nameof(query.SubjectId), "SubjectId is required when scope is Subject.");
                        }

                        break;
                }
            });
    }
}
