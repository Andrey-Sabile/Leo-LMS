using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.CalendarEvents.Commands.DeleteCalendarEvent;

public record DeleteCalendarEventCommand(int Id) : IRequest;

public class DeleteCalendarEventCommandHandler : IRequestHandler<DeleteCalendarEventCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCalendarEventCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCalendarEventCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.CalendarEvents
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.CalendarEvents.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
