using LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryPage;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.FunctionalTests.StudentDirectory.Queries;

using static Testing;

public class GetStudentDirectoryPageTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnPaginatedStudents()
    {
        await RunAsDefaultUserAsync();

        var studentA = CreateStudentWithGuardian(
            "Alice",
            "Anderson",
            "alice@school.test",
            "Anderson City",
            "Grace",
            "Anderson",
            "grace@family.test",
            111111111);

        var studentB = CreateStudentWithGuardian(
            "Ben",
            "Baker",
            "ben@school.test",
            "Baker Town",
            "Henry",
            "Baker",
            "henry@family.test",
            222222222);

        await AddAsync(studentA);
        await AddAsync(studentB);

        var result = await SendAsync(new GetStudentDirectoryPageQuery
        {
            PageNumber = 1,
            PageSize = 1
        });

        result.TotalCount.ShouldBe(2);
        result.Items.Count.ShouldBe(1);
        result.Items.Single().LastName.ShouldBe("Anderson");
        result.Items.Single().Guardians.ShouldNotBeEmpty();
    }

    [Test]
    public async Task ShouldFilterByGuardianName()
    {
        await RunAsDefaultUserAsync();

        var studentMatching = CreateStudentWithGuardian(
            "Charlie",
            "Clark",
            "charlie@school.test",
            "Clarksville",
            "Ivy",
            "Samuels",
            "ivy@family.test",
            333333333);

        var studentOther = CreateStudentWithGuardian(
            "Dana",
            "Dover",
            "dana@school.test",
            "Dover Town",
            "Liam",
            "Hart",
            "liam@family.test",
            444444444);

        await AddAsync(studentMatching);
        await AddAsync(studentOther);

        var result = await SendAsync(new GetStudentDirectoryPageQuery
        {
            Search = "Samuels"
        });

        result.TotalCount.ShouldBe(1);
        result.Items.Single().LastName.ShouldBe("Clark");
        result.Items.Single().Guardians.ShouldContain(x => x.LastName == "Samuels");
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        await Should.ThrowAsync<UnauthorizedAccessException>(() => SendAsync(new GetStudentDirectoryPageQuery()));
    }

    private static Student CreateStudentWithGuardian(
        string studentFirstName,
        string studentLastName,
        string studentEmail,
        string studentCity,
        string guardianFirstName,
        string guardianLastName,
        string guardianEmail,
        int guardianPhoneNumber)
    {
        var studentAddress = Address.Create("123 Main St", "Unit 1", studentCity, "CA", 90001, "USA");
        var student = Student.Create(studentFirstName, studentLastName, studentEmail, studentAddress);

        var guardianAddress = Address.Create("456 Oak St", "Suite 2", "Guardian City", "CA", 90002, "USA");
        var guardian = Guardian.Create(
            guardianFirstName,
            guardianLastName,
            guardianEmail,
            guardianPhoneNumber,
            new List<Student> { student },
            guardianAddress);

        student.Guardians.Add(guardian);

        return student;
    }
}
