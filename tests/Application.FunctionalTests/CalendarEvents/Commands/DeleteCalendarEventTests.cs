using LeoLMS.Application.CalendarEvents.Commands.CreateCalendarEvent;
using LeoLMS.Application.CalendarEvents.Commands.DeleteCalendarEvent;
using LeoLMS.Application.Common.Exceptions;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.Enums;

namespace LeoLMS.Application.FunctionalTests.CalendarEvents.Commands;

using static Testing;

public class DeleteCalendarEventTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidCalendarEventId()
    {
        var command = new DeleteCalendarEventCommand(9999);

        await Should.ThrowAsync<NotFoundException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldDeleteCalendarEvent()
    {
        await RunAsDefaultUserAsync();

        var createCommand = new CreateCalendarEventCommand
        {
            Title = "Art Exhibition",
            Description = "Showcase student artwork",
            Start = new DateTimeOffset(2024, 7, 15, 10, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
            Status = CalendarEventStatus.Scheduled,
            Type = EventType.Announcement,
            Scope = EventScope.School
        };

        var id = await SendAsync(createCommand);

        await SendAsync(new DeleteCalendarEventCommand(id));

        var entity = await FindAsync<CalendarEvent>(id);

        entity.ShouldBeNull();
    }
}
