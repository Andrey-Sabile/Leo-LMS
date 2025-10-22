namespace LeoLMS.Application.Teachers.Queries.GetTeachers;

public class TeachersVm
{
    public IReadOnlyCollection<TeacherDto> Teachers { get; init; } = Array.Empty<TeacherDto>();
}
