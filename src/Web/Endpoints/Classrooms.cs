using System.Collections.Generic;
using LeoLMS.Application.Classrooms.Commands.AddStudentToClassroom;
using LeoLMS.Application.Classrooms.Commands.AddTeacherToClassroom;
using LeoLMS.Application.Classrooms.Commands.CreateClassroom;
using LeoLMS.Application.Classrooms.Commands.DeleteClassroom;
using LeoLMS.Application.Classrooms.Commands.RemoveStudentFromClassroom;
using LeoLMS.Application.Classrooms.Commands.RemoveTeacherFromClassroom;
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
        groupBuilder.MapPost(AddStudentsToClassroom, "AddStudents").RequireAuthorization();
        groupBuilder.MapDelete(RemoveStudentFromClassroom, "{id}/students/{studentId}").RequireAuthorization();
        groupBuilder.MapPost(AddTeachersToClassroom, "AddTeachers").RequireAuthorization();
        groupBuilder.MapDelete(RemoveTeacherFromClassroom, "{id}/teachers/{teacherId}").RequireAuthorization();
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

    public async Task<Results<NoContent, BadRequest>> AddStudentsToClassroom(ISender sender, int classroomId, AddStudentsToClassroomCommand request)
    {
        if (request.StudentIds is null || request.StudentIds.Count == 0) return TypedResults.BadRequest();

        await sender.Send(new AddStudentsToClassroomCommand(classroomId, request.StudentIds));

        return TypedResults.NoContent();
    }

    public async Task<NoContent> RemoveStudentFromClassroom(ISender sender, int id, int studentId)
    {
        await sender.Send(new RemoveStudentFromClassroomCommand(id, studentId));

        return TypedResults.NoContent();
    }

    public async Task<Results<NoContent, BadRequest>> AddTeachersToClassroom(ISender sender, int id, AddTeacherToClassroomCommand command)
    {
        if (id != command.ClassroomId) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> RemoveTeacherFromClassroom(ISender sender, int id, int teacherId)
    {
        await sender.Send(new RemoveTeacherFromClassroomCommand(id, teacherId));

        return TypedResults.NoContent();
    }
}

public class AddStudentsToClassroomRequest
{
    public IReadOnlyCollection<int>? StudentIds { get; init; }
}
