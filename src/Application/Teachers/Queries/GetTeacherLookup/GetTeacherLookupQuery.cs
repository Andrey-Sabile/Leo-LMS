using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Models;
using LeoLMS.Application.Common.Mappings;
using LeoLMS.Application.Common.Security;

namespace LeoLMS.Application.Teachers.Queries.GetTeacherLookup;

[Authorize]
public record GetTeacherLookupQuery : IRequest<PaginatedList<TeacherLookupDto>>
{
    public string? Search { get; init; }

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 10;
}

public class GetTeacherLookupQueryHandler : IRequestHandler<GetTeacherLookupQuery, PaginatedList<TeacherLookupDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTeacherLookupQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TeacherLookupDto>> Handle(GetTeacherLookupQuery request, CancellationToken cancellationToken)
    {
        var teachers = _context.Teachers
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var normalizedSearch = request.Search.Trim().ToLower();

            teachers = teachers.Where(teacher =>
                teacher.FirstName.ToLower().Contains(normalizedSearch) ||
                teacher.LastName.ToLower().Contains(normalizedSearch) ||
                teacher.Email.ToLower().Contains(normalizedSearch));
        }

        return await teachers
            .OrderBy(teacher => teacher.LastName)
            .ThenBy(teacher => teacher.FirstName)
            .ProjectTo<TeacherLookupDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}
