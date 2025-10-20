namespace LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryDetail;

public class GetStudentDirectoryDetailQueryValidator : AbstractValidator<GetStudentDirectoryDetailQuery>
{
    public GetStudentDirectoryDetailQueryValidator()
    {
        RuleFor(x => x.StudentId)
            .GreaterThan(0)
            .WithMessage("StudentId must be greater than 0.");
    }
}
