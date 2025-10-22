namespace LeoLMS.Application.Subjects.Queries.GetSubjects;

public class SubjectsVm
{
    public IReadOnlyCollection<SubjectDto> Subjects { get; init; } = Array.Empty<SubjectDto>();
}
