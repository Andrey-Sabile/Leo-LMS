using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Security;

namespace LeoLMS.Application.Subjects.Queries.GetSubjects;

[Authorize]
public record GetSubjectsQuery : IRequest<SubjectsVm>;

public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, SubjectsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSubjectsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SubjectsVm> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
    {
        var subjects = await _context.Subjects
            .AsNoTracking()
            .ProjectTo<SubjectDto>(_mapper.ConfigurationProvider)
            .OrderBy(s => s.Name)
            .ThenBy(s => s.Code)
            .ToListAsync(cancellationToken);

        return new SubjectsVm
        {
            Subjects = subjects
        };
    }
}
