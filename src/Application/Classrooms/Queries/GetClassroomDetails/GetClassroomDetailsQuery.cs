using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Security;

namespace LeoLMS.Application.Classrooms.Queries.GetClassroomDetails;

[Authorize]
public record GetClassroomDetailsQuery(int Id) : IRequest<ClassroomDetailsDto>;

public class GetClassroomDetailsQueryHandler : IRequestHandler<GetClassroomDetailsQuery, ClassroomDetailsDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClassroomDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ClassroomDetailsDto> Handle(GetClassroomDetailsQuery request, CancellationToken cancellationToken)
    {
        var classroom = await _context.Classrooms
            .AsNoTracking()
            .Where(classroom => classroom.Id == request.Id)
            .AsSplitQuery()
            .ProjectTo<ClassroomDetailsDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, classroom);

        return classroom!;
    }
}
