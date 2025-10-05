namespace LeoLMS.Domain.Exceptions;

public class InvalidEventTimeRangeException : Exception
{
    public InvalidEventTimeRangeException(string reason)
        : base($"Event time range is invalid: {reason}.")
    {
    }

    public InvalidEventTimeRangeException(DateTimeOffset start, DateTimeOffset end, string? reason = null)
        : base(BuildMessage(start, end, reason))
    {
    }

    private static string BuildMessage(DateTimeOffset start, DateTimeOffset end, string? reason)
    {
        var baseMessage = $"Event time range is invalid. Start: {start:o}, End: {end:o}";
        return string.IsNullOrWhiteSpace(reason)
            ? baseMessage
            : $"{baseMessage}. Reason: {reason}";
    }
}
