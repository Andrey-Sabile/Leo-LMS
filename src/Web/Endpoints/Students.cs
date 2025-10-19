using LeoLMS.Application.Students.Commands.CreateStudent;
using LeoLMS.Application.Students.Commands.UpdateStudent;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LeoLMS.Web.Endpoints;

public class Students : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(CreateStudent).RequireAuthorization();
        groupBuilder.MapPut(UpdateStudent, "{id}").RequireAuthorization();
    }

    public async Task<Created<int>> CreateStudent(ISender sender, CreateStudentCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(Students)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateStudent(ISender sender, int id, UpdateStudentCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }
}
