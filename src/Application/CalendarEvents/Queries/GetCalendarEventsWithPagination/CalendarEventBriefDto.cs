using LeoLMS.Domain.Entities;
using LeoLMS.Domain.Enums;

namespace LeoLMS.Application.CalendarEvents.Queries.GetCalendarEventsWithPagination;

public class CalendarEventBriefDto
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public CalendarEventStatus? Status { get; init; }

    public EventType? Type { get; init; }

    public EventScope? Scope { get; init; }

    public DateTimeOffset Start { get; init; }

    public DateTimeOffset End { get; init; }

    public int? ClassId { get; init; }

    public int? SubjectId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CalendarEvent, CalendarEventBriefDto>()
                .ForMember(d => d.Start, opt => opt.MapFrom(s => s.TimeRange.Start))
                .ForMember(d => d.End, opt => opt.MapFrom(s => s.TimeRange.End));
        }
    }
}
