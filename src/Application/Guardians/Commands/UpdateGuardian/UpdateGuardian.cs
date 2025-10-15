using LeoLMS.Application.Common.Interfaces;

namespace LeoLMS.Application.Guardians.Commands.UpdateGuardian;

public record UpdateGuardianCommand : IRequest<object>
{
}

public class UpdateGuardianCommandValidator : AbstractValidator<UpdateGuardianCommand>
{
    public UpdateGuardianCommandValidator()
    {
    }
}

public class UpdateGuardianCommandHandler : IRequestHandler<UpdateGuardianCommand, object>
{
    private readonly IApplicationDbContext _context;

    public UpdateGuardianCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<object> Handle(UpdateGuardianCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
