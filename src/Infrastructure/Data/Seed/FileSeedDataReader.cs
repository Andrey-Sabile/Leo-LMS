using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LeoLMS.Infrastructure.Data.Seed;

public class FileSeedDataReader : ISeedDataReader
{
    private readonly IHostEnvironment _hostEnvironment;
    private readonly ILogger<FileSeedDataReader> _logger;
    private readonly SeedDataOptions _options;
    private readonly JsonSerializerOptions _serializerOptions;

    public FileSeedDataReader(
        IHostEnvironment hostEnvironment,
        IOptions<SeedDataOptions> options,
        ILogger<FileSeedDataReader> logger)
    {
        _hostEnvironment = hostEnvironment;
        _logger = logger;
        _options = options.Value;
        _serializerOptions = CreateSerializerOptions();
    }

    public async Task<T?> ReadAsync<T>(string endpointName, CancellationToken cancellationToken = default)
        where T : class
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(endpointName);

        var directory = Path.Combine(_hostEnvironment.ContentRootPath, _options.DirectoryName);
        var filePath = Path.Combine(directory, $"{endpointName}.json");

        if (!File.Exists(filePath))
        {
            if (_options.ThrowOnMissingFile)
            {
                throw new FileNotFoundException($"Seed data file not found for endpoint '{endpointName}'.", filePath);
            }

            _logger.LogDebug("Seed data file not found for endpoint '{Endpoint}'. Expected at path '{Path}'.", endpointName, filePath);
            return null;
        }

        await using var stream = File.OpenRead(filePath);

        try
        {
            return await JsonSerializer.DeserializeAsync<T>(stream, _serializerOptions, cancellationToken);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to deserialize seed data for endpoint '{Endpoint}'.", endpointName);
            throw;
        }
    }

    private static JsonSerializerOptions CreateSerializerOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
        };

        options.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false));

        return options;
    }
}
