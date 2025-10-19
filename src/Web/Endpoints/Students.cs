using LeoLMS.Application.Students.Commands.CreateStudent;
using LeoLMS.Application.Students.Commands.UpdateStudent;
using LeoLMS.Application.Students.Queries.GetStudents;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LeoLMS.Web.Endpoints;

public class Students : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet(GetStudents).RequireAuthorization();
        groupBuilder.MapPost(CreateStudent).RequireAuthorization();
        groupBuilder.MapPut(UpdateStudent, "{id}").RequireAuthorization();
    }

    public async Task<Ok<StudentsVm>> GetStudents(ISender sender)
    {
        var vm = await sender.Send(new GetStudentsQuery());

        return TypedResults.Ok(vm);
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
