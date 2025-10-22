using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Security;

namespace LeoLMS.Application.Teachers.Queries.GetTeachers;

[Authorize]
public record GetTeachersQuery : IRequest<TeachersVm>;

public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, TeachersVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTeachersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TeachersVm> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
    {
        var teachers = await _context.Teachers
            .AsNoTracking()
            .ProjectTo<TeacherDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.LastName)
            .ThenBy(t => t.FirstName)
            .ToListAsync(cancellationToken);

        return new TeachersVm
        {
            Teachers = teachers
        };
    }
}
