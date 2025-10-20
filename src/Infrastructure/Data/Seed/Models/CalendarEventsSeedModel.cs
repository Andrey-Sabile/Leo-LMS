using LeoLMS.Domain.Enums;

namespace LeoLMS.Infrastructure.Data.Seed.Models;

public class CalendarEventsSeedModel
{
    public IList<CalendarEventSeedItem> Events { get; init; } = new List<CalendarEventSeedItem>();
}

public class CalendarEventSeedItem
{
    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public DateTimeOffset Start { get; init; }

    public DateTimeOffset End { get; init; }

    public CalendarEventStatus? Status { get; init; }

    public EventType? Type { get; init; }

    public EventScope? Scope { get; init; }

    public int? ClassId { get; init; }

    public int? SubjectId { get; init; }
}
