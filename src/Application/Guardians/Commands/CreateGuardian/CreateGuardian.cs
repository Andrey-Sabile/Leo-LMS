using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Guardians.Commands.CreateGuardian;

public record CreateGuardianCommand : IRequest<int>
{
}

public class CreateGuardianCommandValidator : AbstractValidator<CreateGuardianCommand>
{
    public CreateGuardianCommandValidator()
    {
    }
}

public class CreateGuardianCommandHandler : IRequestHandler<CreateGuardianCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateGuardianCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateGuardianCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
