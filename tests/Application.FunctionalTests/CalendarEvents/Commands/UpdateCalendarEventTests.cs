using LeoLMS.Application.CalendarEvents.Commands.CreateCalendarEvent;
using LeoLMS.Application.CalendarEvents.Commands.UpdateCalendarEvent;
using LeoLMS.Application.Common.Exceptions;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.Enums;

namespace LeoLMS.Application.FunctionalTests.CalendarEvents.Commands;

using static Testing;

public class UpdateCalendarEventTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidId()
    {
        var command = new UpdateCalendarEventCommand
        {
            Id = 0,
            Title = "Updated",
            Description = "Updated description",
            Start = DateTimeOffset.UtcNow,
            End = DateTimeOffset.UtcNow.AddHours(1)
        };

        await Should.ThrowAsync<ValidationException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldRequireSubjectIdWhenScopeIsSubject()
    {
        var command = new UpdateCalendarEventCommand
        {
            Id = 1,
            Title = "Chemistry Lab",
            Description = "Lab session",
            Start = new DateTimeOffset(2024, 6, 1, 9, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 6, 1, 10, 0, 0, TimeSpan.Zero),
            Scope = EventScope.Subject
        };

        await Should.ThrowAsync<ValidationException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldUpdateCalendarEvent()
    {
        var userId = await RunAsDefaultUserAsync();

        var createCommand = new CreateCalendarEventCommand
        {
            Title = "Parent Teacher Meeting",
            Description = "Discuss student progress",
            Start = new DateTimeOffset(2024, 6, 5, 15, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 6, 5, 16, 0, 0, TimeSpan.Zero),
            Scope = EventScope.School
        };

        var id = await SendAsync(createCommand);

        var updateCommand = new UpdateCalendarEventCommand
        {
            Id = id,
            Title = "Parent Teacher Conference",
            Description = "Updated agenda with additional sessions",
            Start = new DateTimeOffset(2024, 6, 6, 14, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 6, 6, 17, 0, 0, TimeSpan.Zero),
            Status = CalendarEventStatus.Cancelled,
            Type = EventType.Announcement,
            Scope = EventScope.School
        };

        await SendAsync(updateCommand);

        var entity = await FindAsync<CalendarEvent>(id);

        entity.ShouldNotBeNull();
        entity!.Title.ShouldBe("Parent Teacher Conference");
        entity.Description.ShouldBe("Updated agenda with additional sessions");
        entity.TimeRange.Start.ShouldBe(updateCommand.Start);
        entity.TimeRange.End.ShouldBe(updateCommand.End);
        entity.Status.ShouldBe(CalendarEventStatus.Cancelled);
        entity.Type.ShouldBe(EventType.Announcement);
        entity.Scope.ShouldBe(EventScope.School);
        entity.LastModifiedBy.ShouldBe(userId);
        entity.LastModified.ShouldBeGreaterThan(DateTimeOffset.MinValue);
    }
}
