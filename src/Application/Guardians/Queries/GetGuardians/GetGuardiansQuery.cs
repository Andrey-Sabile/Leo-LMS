using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Security;

namespace LeoLMS.Application.Guardians.Queries.GetGuardians;

[Authorize]
public record GetGuardiansQuery : IRequest<GuardiansVm>;

public class GetGuardiansQueryHandler : IRequestHandler<GetGuardiansQuery, GuardiansVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGuardiansQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GuardiansVm> Handle(GetGuardiansQuery request, CancellationToken cancellationToken)
    {
        var guardians = await _context.Guardians
            .AsNoTracking()
            .ProjectTo<GuardianDto>(_mapper.ConfigurationProvider)
            .OrderBy(g => g.LastName)
            .ThenBy(g => g.FirstName)
            .ToListAsync(cancellationToken);

        return new GuardiansVm
        {
            Guardians = guardians
        };
    }
}
