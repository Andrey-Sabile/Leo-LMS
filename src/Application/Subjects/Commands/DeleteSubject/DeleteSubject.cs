using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Subjects.Commands.DeleteSubject;

public record DeleteSubjectCommand(int Id) : IRequest;

public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSubjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Subjects
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Subjects.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
