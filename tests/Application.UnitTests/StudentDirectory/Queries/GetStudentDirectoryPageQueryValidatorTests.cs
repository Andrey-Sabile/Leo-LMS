using LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryPage;
using NUnit.Framework;
using Shouldly;

namespace LeoLMS.Application.UnitTests.StudentDirectory.Queries;

public class GetStudentDirectoryPageQueryValidatorTests
{
    private readonly GetStudentDirectoryPageQueryValidator _validator = new();

    [Test]
    public void ShouldFailWhenPageNumberLessThanOne()
    {
        var result = _validator.Validate(new GetStudentDirectoryPageQuery
        {
            PageNumber = 0,
            PageSize = 10
        });

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == nameof(GetStudentDirectoryPageQuery.PageNumber));
    }

    [Test]
    public void ShouldFailWhenPageSizeLessThanOne()
    {
        var result = _validator.Validate(new GetStudentDirectoryPageQuery
        {
            PageNumber = 1,
            PageSize = 0
        });

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == nameof(GetStudentDirectoryPageQuery.PageSize));
    }

    [Test]
    public void ShouldFailWhenSearchTooShort()
    {
        var result = _validator.Validate(new GetStudentDirectoryPageQuery
        {
            PageNumber = 1,
            PageSize = 10,
            Search = "A"
        });

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldContain(e => e.PropertyName == nameof(GetStudentDirectoryPageQuery.Search));
    }

    [Test]
    public void ShouldPassWithValidRequest()
    {
        var result = _validator.Validate(new GetStudentDirectoryPageQuery
        {
            PageNumber = 1,
            PageSize = 10,
            Search = "Ann"
        });

        result.IsValid.ShouldBeTrue();
    }
}
