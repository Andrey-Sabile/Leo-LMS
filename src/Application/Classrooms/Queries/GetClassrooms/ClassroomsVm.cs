namespace LeoLMS.Application.Classrooms.Queries.GetClassrooms;

public class ClassroomsVm
{
    public IReadOnlyCollection<ClassroomDto> Classrooms { get; init; } = Array.Empty<ClassroomDto>();
}
