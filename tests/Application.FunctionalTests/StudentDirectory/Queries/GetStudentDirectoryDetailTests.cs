using LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryDetail;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.FunctionalTests.StudentDirectory.Queries;

using static Testing;

public class GetStudentDirectoryDetailTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnStudentDetail()
    {
        await RunAsDefaultUserAsync();

        var student = CreateStudentWithGuardians();

        await AddAsync(student);

        var result = await SendAsync(new GetStudentDirectoryDetailQuery
        {
            StudentId = student.Id
        });

        result.Id.ShouldBe(student.Id);
        result.Email.ShouldBe(student.Email);
        result.Guardians.Count.ShouldBe(2);
        result.Guardians.ShouldContain(g => g.FirstName == "Maria");
    }

    [Test]
    public async Task ShouldThrowWhenStudentDoesNotExist()
    {
        await RunAsDefaultUserAsync();

        await Should.ThrowAsync<NotFoundException>(() => SendAsync(new GetStudentDirectoryDetailQuery
        {
            StudentId = 999
        }));
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        await Should.ThrowAsync<UnauthorizedAccessException>(() => SendAsync(new GetStudentDirectoryDetailQuery
        {
            StudentId = 1
        }));
    }

    private static Student CreateStudentWithGuardians()
    {
        var studentAddress = Address.Create("789 Elm St", "Floor 3", "Metro City", "CA", 90003, "USA");
        var student = Student.Create("Evan", "Edwards", "evan@school.test", studentAddress);

        var guardianOne = Guardian.Create(
            "Maria",
            "Edwards",
            "maria@family.test",
            555000111,
            new List<Student> { student },
            Address.Create("101 Pine St", "Apt 5", "Metro City", "CA", 90004, "USA"));

        var guardianTwo = Guardian.Create(
            "Noah",
            "Edwards",
            "noah@family.test",
            555000222,
            new List<Student> { student },
            Address.Create("202 Maple St", "Suite 8", "Metro City", "CA", 90005, "USA"));

        student.Guardians.Add(guardianOne);
        student.Guardians.Add(guardianTwo);

        return student;
    }
}
