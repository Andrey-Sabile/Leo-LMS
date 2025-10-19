using LeoLMS.Application.Guardians.Commands.CreateGuardian;
using LeoLMS.Application.Guardians.Commands.UpdateGuardian;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LeoLMS.Web.Endpoints;

public class Guardians : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(CreateGuardian).RequireAuthorization();
        groupBuilder.MapPut(UpdateGuardian, "{id}").RequireAuthorization();
    }

    public async Task<Created<int>> CreateGuardian(ISender sender, CreateGuardianCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(Guardians)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateGuardian(ISender sender, int id, UpdateGuardianCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }
}
