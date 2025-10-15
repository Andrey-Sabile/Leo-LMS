using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Students.Commands.UpdateStudent;

public record UpdateStudentCommand : IRequest<object>
{
}

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
    }
}

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, object>
{
    private readonly IApplicationDbContext _context;

    public UpdateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
