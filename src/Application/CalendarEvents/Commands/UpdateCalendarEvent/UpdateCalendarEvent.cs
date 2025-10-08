using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Domain.Enums;
using LeoLMS.Domain.ValueObjects;

namespace LeoLMS.Application.CalendarEvents.Commands.UpdateCalendarEvent;

public record UpdateCalendarEventCommand : IRequest
{
    public int Id { get; init; }

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

public class UpdateCalendarEventCommandHandler : IRequestHandler<UpdateCalendarEventCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCalendarEventCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCalendarEventCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.CalendarEvents
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var range = EventTimeRange.Create(request.Start, request.End);

        entity.UpdateDetails(
            request.Title,
            request.Description,
            range,
            request.Status,
            request.Type,
            request.Scope,
            request.ClassId,
            request.SubjectId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
