namespace LeoLMS.Domain.ValueObjects;

public sealed class EventTimeRange : ValueObject
{
    private EventTimeRange(DateTimeOffset start, DateTimeOffset end)
    {
        Start = start;
        End = end;
    }

    public DateTimeOffset Start { get; }
    public DateTimeOffset End { get; }
    public TimeSpan Duration => End - Start;

    public static EventTimeRange Create(DateTimeOffset start, DateTimeOffset end)
    {
        if (start == default)
        {
            throw new InvalidEventTimeRangeException("Start cannot be the default value.");
        }

        if (end == default)
        {
            throw new InvalidEventTimeRangeException("End cannot be the default value.");
        }

        if (start >= end)
        {
            throw new InvalidEventTimeRangeException("Start must be earlier than end.");
        }

        return new EventTimeRange(start, end);
    }

    public EventTimeRange Shift(TimeSpan offset) =>
        Create(Start + offset, End + offset);

    public bool Overlaps(EventTimeRange other) =>
        Start < other.End && other.Start < End;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }

}
