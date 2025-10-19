namespace LeoLMS.Application.Guardians.Queries.GetGuardians;

public class GuardiansVm
{
    public IReadOnlyCollection<GuardianDto> Guardians { get; init; } = Array.Empty<GuardianDto>();
}
