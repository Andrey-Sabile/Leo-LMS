using LeoLMS.Application.CalendarEvents.Commands.CreateCalendarEvent;
using LeoLMS.Application.CalendarEvents.Queries.GetCalendarEventsWithPagination;
using LeoLMS.Domain.Enums;

namespace LeoLMS.Application.FunctionalTests.CalendarEvents.Queries;

using static Testing;

public class GetCalendarEventsWithPaginationTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnPaginatedEvents()
    {
        await RunAsDefaultUserAsync();

        await SendAsync(new CreateCalendarEventCommand
        {
            Title = "Event 1",
            Description = "Description 1",
            Start = new DateTimeOffset(2024, 8, 1, 9, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 8, 1, 10, 0, 0, TimeSpan.Zero)
        });

        await SendAsync(new CreateCalendarEventCommand
        {
            Title = "Event 2",
            Description = "Description 2",
            Start = new DateTimeOffset(2024, 8, 2, 9, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 8, 2, 10, 0, 0, TimeSpan.Zero)
        });

        await SendAsync(new CreateCalendarEventCommand
        {
            Title = "Event 3",
            Description = "Description 3",
            Start = new DateTimeOffset(2024, 8, 3, 9, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 8, 3, 10, 0, 0, TimeSpan.Zero)
        });

        var query = new GetCalendarEventsWithPaginationQuery
        {
            PageNumber = 1,
            PageSize = 2
        };

        var result = await SendAsync(query);

        result.Items.Count.ShouldBe(2);
        result.TotalCount.ShouldBe(3);
        result.Items.First().Start.ShouldBe(new DateTimeOffset(2024, 8, 1, 9, 0, 0, TimeSpan.Zero));
    }

    [Test]
    public async Task ShouldFilterByScopeAndClass()
    {
        await RunAsDefaultUserAsync();

        await SendAsync(new CreateCalendarEventCommand
        {
            Title = "Class Event",
            Description = "Class specific",
            Start = new DateTimeOffset(2024, 9, 1, 8, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 9, 1, 9, 30, 0, TimeSpan.Zero),
            Scope = EventScope.Class,
            ClassId = 10
        });

        await SendAsync(new CreateCalendarEventCommand
        {
            Title = "Other Class Event",
            Description = "Other class",
            Start = new DateTimeOffset(2024, 9, 2, 8, 0, 0, TimeSpan.Zero),
            End = new DateTimeOffset(2024, 9, 2, 9, 30, 0, TimeSpan.Zero),
            Scope = EventScope.Class,
            ClassId = 11
        });

        var query = new GetCalendarEventsWithPaginationQuery
        {
            Scope = EventScope.Class,
            ClassId = 10,
            PageNumber = 1,
            PageSize = 10
        };

        var result = await SendAsync(query);

        result.TotalCount.ShouldBe(1);
        result.Items.Single().Title.ShouldBe("Class Event");
        result.Items.Single().ClassId.ShouldBe(10);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetCalendarEventsWithPaginationQuery();

        await Should.ThrowAsync<UnauthorizedAccessException>(() => SendAsync(query));
    }
}
