namespace LeoLMS.Application.Students.Queries.GetStudents;

public class StudentsVm
{
    public IReadOnlyCollection<StudentDto> Students { get; init; } = Array.Empty<StudentDto>();
}
