using System;
using LeoLMS.Application.CalendarEvents.Commands.CreateCalendarEvent;
using LeoLMS.Application.Common.Exceptions;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.Enums;

namespace LeoLMS.Application.FunctionalTests.CalendarEvents.Commands;

using static Testing;

public class CreateCalendarEventTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMandatoryFields()
    {
        var command = new CreateCalendarEventCommand();

        await Should.ThrowAsync<ValidationException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldRequireClassIdWhenScopeIsClass()
    {
        var command = new CreateCalendarEventCommand
        {
            Title = "Class Assembly",
            Description = "Monthly announcements",
            Start = new DateTimeOffset(2024, 5, 1, 9, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 5, 1, 10, 0, 0, TimeSpan.Zero),
            Scope = EventScope.Class
        };

        await Should.ThrowAsync<ValidationException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldRequireValidTimeRange()
    {
        var command = new CreateCalendarEventCommand
        {
            Title = "Orientation",
            Description = "Welcome new students",
            Start = new DateTimeOffset(2024, 5, 1, 10, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 5, 1, 9, 0, 0, TimeSpan.Zero)
        };

        await Should.ThrowAsync<ValidationException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldCreateCalendarEvent()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateCalendarEventCommand
        {
            Title = "School Orientation",
            Description = "Welcome new students",
            Start = new DateTimeOffset(2024, 5, 1, 9, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 5, 1, 11, 0, 0, TimeSpan.Zero),
            Status = CalendarEventStatus.Scheduled,
            Type = EventType.Announcement,
            Scope = EventScope.School
        };

        var id = await SendAsync(command);

        var entity = await FindAsync<CalendarEvent>(id);

        entity.ShouldNotBeNull();
        entity!.Title.ShouldBe("School Orientation");
        entity.Description.ShouldBe("Welcome new students");
        entity.TimeRange.Start.ShouldBe(command.Start);
        entity.TimeRange.End.ShouldBe(command.End);
        entity.Status.ShouldBe(CalendarEventStatus.Scheduled);
        entity.Scope.ShouldBe(EventScope.School);
        entity.Type.ShouldBe(EventType.Announcement);
        entity.ClassId.ShouldBeNull();
        entity.SubjectId.ShouldBeNull();
        entity.CreatedBy.ShouldBe(userId);
        entity.Created.ShouldBe(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
