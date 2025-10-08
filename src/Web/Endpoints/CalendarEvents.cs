using LeoLMS.Application.CalendarEvents.Commands.CreateCalendarEvent;
using LeoLMS.Application.CalendarEvents.Commands.DeleteCalendarEvent;
using LeoLMS.Application.CalendarEvents.Commands.UpdateCalendarEvent;
using LeoLMS.Application.CalendarEvents.Queries.GetCalendarEventsWithPagination;
using LeoLMS.Application.Common.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LeoLMS.Web.Endpoints;

public class CalendarEvents : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet(GetCalendarEventsWithPagination).RequireAuthorization();
        groupBuilder.MapPost(CreateCalendarEvent).RequireAuthorization();
        groupBuilder.MapPut(UpdateCalendarEvent, "{id}").RequireAuthorization();
        groupBuilder.MapDelete(DeleteCalendarEvent, "{id}").RequireAuthorization();
    }

    public async Task<Ok<PaginatedList<CalendarEventBriefDto>>> GetCalendarEventsWithPagination(ISender sender, [AsParameters] GetCalendarEventsWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateCalendarEvent(ISender sender, CreateCalendarEventCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(CalendarEvents)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateCalendarEvent(ISender sender, int id, UpdateCalendarEventCommand command)
    {
        if (id != command.Id)
        {
            return TypedResults.BadRequest();
        }

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteCalendarEvent(ISender sender, int id)
    {
        await sender.Send(new DeleteCalendarEventCommand(id));

        return TypedResults.NoContent();
    }
}
