using System;
using LeoLMS.Domain.Enums;
using LeoLMS.Domain.ValueObjects;

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

    public CalendarEventStatus? Status { get; private set; }

    public EventType? Type { get; private set; }

    public EventScope? Scope { get; private set; }

    public EventTimeRange TimeRange { get; private set; } = null!;

    public int? ClassId { get; private set; }

    public int? SubjectId { get; private set; }

    public static CalendarEvent Create(
        string title,
        string description,
        EventTimeRange timeRange,
        CalendarEventStatus? status = null,
        EventType? type = null,
        EventScope? scope = null,
        int? classId = null,
        int? subjectId = null)
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

        var calendarEvent = new CalendarEvent(title.Trim(), description.Trim(), timeRange)
        {
            Status = status,
            Type = type,
            Scope = scope,
            ClassId = classId,
            SubjectId = subjectId
        };

        if (scope is null)
        {
            return calendarEvent;
        }

        switch (scope.Value)
        {
            case EventScope.School:
                calendarEvent.ClassId = null;
                calendarEvent.SubjectId = null;
                break;
            case EventScope.Class:
                if (!classId.HasValue)
                {
                    throw new ArgumentException("ClassId is required when scope is Class.", nameof(classId));
                }

                calendarEvent.ClassId = classId;
                calendarEvent.SubjectId = null;
                break;
            case EventScope.Subject:
                if (!subjectId.HasValue)
                {
                    throw new ArgumentException("SubjectId is required when scope is Subject.", nameof(subjectId));
                }

                calendarEvent.SubjectId = subjectId;
                calendarEvent.ClassId = classId;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(scope), scope, "Unsupported event scope.");
        }

        return calendarEvent;
    }
}
