using LeoLMS.Application.Teachers.Commands.CreateTeacher;
using LeoLMS.Application.Teachers.Commands.UpdateTeacher;
using LeoLMS.Application.Teachers.Queries.GetTeachers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LeoLMS.Web.Endpoints;

public class Teachers : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet(GetTeachers).RequireAuthorization();
        groupBuilder.MapPost(CreateTeacher).RequireAuthorization();
        groupBuilder.MapPut(UpdateTeacher, "{id}").RequireAuthorization();
    }

    public async Task<Ok<TeachersVm>> GetTeachers(ISender sender)
    {
        var vm = await sender.Send(new GetTeachersQuery());

        return TypedResults.Ok(vm);
    }

    public async Task<Created<int>> CreateTeacher(ISender sender, CreateTeacherCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(Teachers)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateTeacher(ISender sender, int id, UpdateTeacherCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }
}
