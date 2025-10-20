using System.Threading;
using System.Threading.Tasks;

namespace LeoLMS.Infrastructure.Data.Seed;

public interface ISeedDataReader
{
    Task<T?> ReadAsync<T>(string endpointName, CancellationToken cancellationToken = default)
        where T : class;
}
