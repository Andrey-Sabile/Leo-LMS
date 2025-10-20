using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeoLMS.Application.Common.Interfaces;
using LeoLMS.Application.Common.Mappings;
using LeoLMS.Application.Common.Models;
using LeoLMS.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeoLMS.Application.StudentDirectory.Queries.GetStudentDirectoryPage;

[Authorize]
public record GetStudentDirectoryPageQuery : IRequest<PaginatedList<StudentDirectoryListItemDto>>
{
    public string? Search { get; init; }

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 10;
}

public class GetStudentDirectoryPageQueryHandler : IRequestHandler<GetStudentDirectoryPageQuery, PaginatedList<StudentDirectoryListItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStudentDirectoryPageQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<StudentDirectoryListItemDto>> Handle(GetStudentDirectoryPageQuery request, CancellationToken cancellationToken)
    {
        var students = _context.Students
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var normalizedSearch = request.Search.Trim().ToLower();

            students = students.Where(student =>
                student.FirstName.ToLower().Contains(normalizedSearch) ||
                student.LastName.ToLower().Contains(normalizedSearch) ||
                student.Guardians.Any(guardian =>
                    guardian.FirstName.ToLower().Contains(normalizedSearch) ||
                    guardian.LastName.ToLower().Contains(normalizedSearch)));
        }

        return await students
            .OrderBy(student => student.LastName)
            .ThenBy(student => student.FirstName)
            .ProjectTo<StudentDirectoryListItemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}
