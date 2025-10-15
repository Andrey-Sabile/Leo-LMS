using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Students.Commands.CreateStudent;

public record CreateStudentCommand : IRequest<int>
{
}

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
    }
}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
