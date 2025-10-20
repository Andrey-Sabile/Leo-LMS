using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Security;

namespace LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryDetail;

[Authorize]
public record GetStudentDirectoryDetailQuery : IRequest<StudentDirectoryDetailDto>
{
    public int StudentId { get; init; }
}

public class GetStudentDirectoryDetailQueryHandler : IRequestHandler<GetStudentDirectoryDetailQuery, StudentDirectoryDetailDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStudentDirectoryDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<StudentDirectoryDetailDto> Handle(GetStudentDirectoryDetailQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students
            .AsNoTracking()
            .Include(s => s.Guardians)
            .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

        Guard.Against.NotFound(request.StudentId, student);

        return _mapper.Map<StudentDirectoryDetailDto>(student!);
    }
}
