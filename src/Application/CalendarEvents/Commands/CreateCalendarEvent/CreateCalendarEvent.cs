using System;
using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.Enums;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.CalendarEvents.Commands.CreateCalendarEvent;

public record CreateCalendarEventCommand : IRequest<int>
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

public class CreateCalendarEventCommandHandler : IRequestHandler<CreateCalendarEventCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCalendarEventCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCalendarEventCommand request, CancellationToken cancellationToken)
    {
        var range = EventTimeRange.Create(request.Start, request.End);

        var entity = CalendarEvent.Create(
            request.Title,
            request.Description,
            range,
            request.Status,
            request.Type,
            request.Scope,
            request.ClassId,
            request.SubjectId);

        _context.CalendarEvents.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
