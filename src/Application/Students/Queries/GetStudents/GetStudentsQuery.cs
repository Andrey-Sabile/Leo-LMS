using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Security;

namespace LeoLMS.Application.Students.Queries.GetStudents;

[Authorize]
public record GetStudentsQuery : IRequest<StudentsVm>;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, StudentsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<StudentsVm> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _context.Students
            .AsNoTracking()
            .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .ToListAsync(cancellationToken);

        return new StudentsVm
        {
            Students = students
        };
    }
}
