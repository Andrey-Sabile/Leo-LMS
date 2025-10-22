using LeoLMS.Application.Subjects.Commands.CreateSubject;
using LeoLMS.Application.Subjects.Commands.DeleteSubject;
using LeoLMS.Application.Subjects.Commands.UpdateSubject;
using LeoLMS.Application.Subjects.Queries.GetSubjects;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LeoLMS.Web.Endpoints;

public class Subjects : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet(GetSubjects).RequireAuthorization();
        groupBuilder.MapPost(CreateSubject).RequireAuthorization();
        groupBuilder.MapPut(UpdateSubject, "{id}").RequireAuthorization();
        groupBuilder.MapDelete(DeleteSubject, "{id}").RequireAuthorization();
    }

    public async Task<Ok<SubjectsVm>> GetSubjects(ISender sender)
    {
        var vm = await sender.Send(new GetSubjectsQuery());

        return TypedResults.Ok(vm);
    }

    public async Task<Created<int>> CreateSubject(ISender sender, CreateSubjectCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(Subjects)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateSubject(ISender sender, int id, UpdateSubjectCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteSubject(ISender sender, int id)
    {
        await sender.Send(new DeleteSubjectCommand(id));

        return TypedResults.NoContent();
    }
}
