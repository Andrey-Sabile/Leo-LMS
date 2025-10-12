using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Mappings;
using LeoLMS.Application.Common.Models;
using LeoLMS.Domain.Enums;

namespace LeoLMS.Application.CalendarEvents.Queries.GetCalendarEventsWithPagination;

public record GetCalendarEventsWithPaginationQuery : IRequest<PaginatedList<CalendarEventBriefDto>>
{
    public DateTimeOffset? Start { get; init; }

    public DateTimeOffset? End { get; init; }

    public CalendarEventStatus? Status { get; init; }

    public EventType? Type { get; init; }

    public EventScope? Scope { get; init; }

    public int? ClassId { get; init; }

    public int? SubjectId { get; init; }

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 10;
}

public class GetCalendarEventsWithPaginationQueryHandler : IRequestHandler<GetCalendarEventsWithPaginationQuery, PaginatedList<CalendarEventBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCalendarEventsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CalendarEventBriefDto>> Handle(GetCalendarEventsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = _context.CalendarEvents.AsQueryable();

        if (request.Start.HasValue && request.End.HasValue)
        {
            var start = request.Start.Value;
            var end = request.End.Value;
            query = query.Where(e => e.TimeRange.Start <= end && e.TimeRange.End >= start);
        }
        else if (request.Start.HasValue)
        {
            var start = request.Start.Value;
            query = query.Where(e => e.TimeRange.End >= start);
        }
        else if (request.End.HasValue)
        {
            var end = request.End.Value;
            query = query.Where(e => e.TimeRange.Start <= end);
        }

        if (request.Status.HasValue)
        {
            var status = request.Status.Value;
            query = query.Where(e => e.Status == status);
        }

        if (request.Type.HasValue)
        {
            var type = request.Type.Value;
            query = query.Where(e => e.Type == type);
        }

        if (request.Scope.HasValue)
        {
            var scope = request.Scope.Value;
            query = query.Where(e => e.Scope == scope);
        }

        if (request.ClassId.HasValue)
        {
            var classId = request.ClassId.Value;
            query = query.Where(e => e.ClassId == classId);
        }

        if (request.SubjectId.HasValue)
        {
            var subjectId = request.SubjectId.Value;
            query = query.Where(e => e.SubjectId == subjectId);
        }

        return await query
            .OrderBy(e => e.TimeRange.Start)
            .ProjectTo<CalendarEventBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}
