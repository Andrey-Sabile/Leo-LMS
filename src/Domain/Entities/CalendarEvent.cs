namespace LeoLMS.Domain.Entities;

public class CalendarEvent : BaseAuditableEntity
{
    private CalendarEvent(string title, string description, EventTimeRange timeRange)
    {
        Title = title;
        Description = description;
        TimeRange = timeRange;
    }

    private CalendarEvent() { }

    public string Title { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public CalendarEventStatus Status { get; private set; }

    public EventType Type { get; private set; }

    public EventScope Scope { get; private set; }

    public EventTimeRange TimeRange { get; private set; } = null!;

    public int? ClassId { get; set; }

    public int? SubjectId { get; set; }

    public static CalendarEvent Create(string title, string description, EventTimeRange timeRange)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description is required.", nameof(description));
        }

        if (timeRange is null)
        {
            throw new ArgumentNullException(nameof(timeRange));
        }

        return new CalendarEvent(title.Trim(), description.Trim(), timeRange);
    }
}
