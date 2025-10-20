using LeoLMS.Application.Common.Models;
using LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryDetail;
using LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryPage;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LeoLMS.Web.Endpoints;

public class StudentDirectory : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet(GetStudentDirectoryPage).RequireAuthorization();
        groupBuilder.MapGet(GetStudentDirectoryDetail, "{studentId:int}").RequireAuthorization();
    }

    public async Task<Ok<PaginatedList<StudentDirectoryListItemDto>>> GetStudentDirectoryPage(
        ISender sender,
        [AsParameters] GetStudentDirectoryPageQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Ok<StudentDirectoryDetailDto>> GetStudentDirectoryDetail(ISender sender, int studentId)
    {
        var result = await sender.Send(new GetStudentDirectoryDetailQuery
        {
            StudentId = studentId
        });

        return TypedResults.Ok(result);
    }
}
