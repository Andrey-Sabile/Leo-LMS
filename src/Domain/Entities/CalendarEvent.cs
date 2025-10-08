using System;
using LeoLMS.Domain.Enums;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Domain.Entities;

public class CalendarEvent : BaseAuditableEntity
{
    private CalendarEvent() { }

    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public CalendarEventStatus Status { get; private set; }
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
        var calendarEvent = new CalendarEvent();
        calendarEvent.SetDetails(title, description, timeRange, status, type, scope, classId, subjectId);
        return calendarEvent;
    }

    public void UpdateDetails(
        string title,
        string description,
        EventTimeRange timeRange,
        CalendarEventStatus? status = null,
        EventType? type = null,
        EventScope? scope = null,
        int? classId = null,
        int? subjectId = null)
    {
        SetDetails(title, description, timeRange, status, type, scope, classId, subjectId);
    }

    private void SetDetails(
        string title,
        string description,
        EventTimeRange timeRange,
        CalendarEventStatus? status,
        EventType? type,
        EventScope? scope,
        int? classId,
        int? subjectId)
    {
        ValidateRequiredFields(title, description, timeRange);

        Title = title.Trim();
        Description = description.Trim();
        TimeRange = timeRange;
        Type = type;
        ApplyScope(scope, classId, subjectId);
    }

    private static void ValidateRequiredFields(string title, string description, EventTimeRange timeRange)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.", nameof(description));

        if (timeRange is null)
            throw new ArgumentNullException(nameof(timeRange));
    }

    private void ApplyScope(EventScope? scope, int? classId, int? subjectId)
    {
        Scope = scope;

        switch (scope)
        {
            case null:
                ClassId = classId;
                SubjectId = subjectId;
                break;

            case EventScope.School:
                ClassId = null;
                SubjectId = null;
                break;

            case EventScope.Class:
                if (!classId.HasValue)
                    throw new ArgumentException("ClassId is required when scope is Class.", nameof(classId));

                ClassId = classId;
                SubjectId = null;
                break;

            case EventScope.Subject:
                if (!subjectId.HasValue)
                    throw new ArgumentException("SubjectId is required when scope is Subject.", nameof(subjectId));

                SubjectId = subjectId;
                ClassId = classId;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(scope), scope, "Unsupported event scope.");
        }
    }
}