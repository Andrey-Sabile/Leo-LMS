using LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryDetail;
using NUnit.Framework;
using Shouldly;

namespace LeoLMS.Application.UnitTests.StudentDirectory.Queries;

public class GetStudentDirectoryDetailQueryValidatorTests
{
    private readonly GetStudentDirectoryDetailQueryValidator _validator = new();

    [Test]
    public void ShouldFailWhenStudentIdIsZero()
    {
        var result = _validator.Validate(new GetStudentDirectoryDetailQuery
        {
            StudentId = 0
        });

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == nameof(GetStudentDirectoryDetailQuery.StudentId));
    }

    [Test]
    public void ShouldFailWhenStudentIdIsNegative()
    {
        var result = _validator.Validate(new GetStudentDirectoryDetailQuery
        {
            StudentId = -1
        });

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == nameof(GetStudentDirectoryDetailQuery.StudentId));
    }

    [Test]
    public void ShouldPassWhenStudentIdIsPositive()
    {
        var result = _validator.Validate(new GetStudentDirectoryDetailQuery
        {
            StudentId = 42
        });

        result.IsValid.ShouldBeTrue();
    }
}
