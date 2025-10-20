using System.Threading;
using System.Threading.Tasks;
using LeoLMS.Infrastructure.Data;

namespace LeoLMS.Infrastructure.Data.Seed;

public interface IEndpointSeedContributor
{
    string EndpointName { get; }

    Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default);
}
