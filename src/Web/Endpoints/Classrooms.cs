using LeoLMS.Application.Classrooms.Commands.CreateClassroom;
using LeoLMS.Application.Classrooms.Commands.DeleteClassroom;
using LeoLMS.Application.Classrooms.Commands.UpdateClassroom;
using LeoLMS.Application.Classrooms.Queries.GetClassrooms;
using LeoLMS.Application.Classrooms.Queries.GetClassroomDetails;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LeoLMS.Web.Endpoints;

public class Classrooms : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet(GetClassrooms).RequireAuthorization();
        groupBuilder.MapGet(GetClassroomDetails, "{id}").RequireAuthorization();
        groupBuilder.MapPost(CreateClassroom).RequireAuthorization();
        groupBuilder.MapPut(UpdateClassroom, "{id}").RequireAuthorization();
        groupBuilder.MapDelete(DeleteClassroom, "{id}").RequireAuthorization();
    }

    public async Task<Ok<ClassroomsVm>> GetClassrooms(ISender sender)
    {
        var vm = await sender.Send(new GetClassroomsQuery());

        return TypedResults.Ok(vm);
    }

    public async Task<Created<int>> CreateClassroom(ISender sender, CreateClassroomCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(Classrooms)}/{id}", id);
    }

    public async Task<Ok<ClassroomDetailsDto>> GetClassroomDetails(ISender sender, int id)
    {
        var classroom = await sender.Send(new GetClassroomDetailsQuery(id));

        return TypedResults.Ok(classroom);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateClassroom(ISender sender, int id, UpdateClassroomCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteClassroom(ISender sender, int id)
    {
        await sender.Send(new DeleteClassroomCommand(id));

        return TypedResults.NoContent();
    }
}
