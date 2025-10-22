using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Security;

namespace LeoLMS.Application.Classrooms.Queries.GetClassrooms;

[Authorize]
public record GetClassroomsQuery : IRequest<ClassroomsVm>;

public class GetClassroomsQueryHandler : IRequestHandler<GetClassroomsQuery, ClassroomsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClassroomsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ClassroomsVm> Handle(GetClassroomsQuery request, CancellationToken cancellationToken)
    {
        var classrooms = await _context.Classrooms
            .AsNoTracking()
            .ProjectTo<ClassroomDto>(_mapper.ConfigurationProvider)
            .OrderBy(classroom => classroom.Name)
            .ToListAsync(cancellationToken);

        return new ClassroomsVm
        {
            Classrooms = classrooms
        };
    }
}
