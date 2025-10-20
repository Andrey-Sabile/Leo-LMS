namespace LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryPage;

public class GetStudentDirectoryPageQueryValidator : AbstractValidator<GetStudentDirectoryPageQuery>
{
    public GetStudentDirectoryPageQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize at least greater than or equal to 1.");

        RuleFor(x => x.Search)
            .Must(search => search == null || search.Trim().Length >= 2)
            .WithMessage("Search must be at least 2 characters long.")
            .When(x => !string.IsNullOrWhiteSpace(x.Search));
    }
}
