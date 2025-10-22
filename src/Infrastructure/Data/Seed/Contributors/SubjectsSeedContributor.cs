using System.Threading;
using System.Threading.Tasks;
using LeoLMS.Domain.Entities;
using LeoLMS.Infrastructure.Data.Seed.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeoLMS.Infrastructure.Data.Seed.Contributors;

public class SubjectsSeedContributor : IEndpointSeedContributor
{
    private readonly ISeedDataReader _reader;
    private readonly ILogger<SubjectsSeedContributor> _logger;

    public SubjectsSeedContributor(
        ISeedDataReader reader,
        ILogger<SubjectsSeedContributor> logger)
    {
        _reader = reader;
        _logger = logger;
    }

    public string EndpointName => "Subjects";

    public async Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
    {
        var payload = await _reader.ReadAsync<SubjectsSeedModel>(EndpointName, cancellationToken);

        if (payload?.Subjects is null || payload.Subjects.Count == 0)
        {
            _logger.LogDebug("No seed data supplied for endpoint '{EndpointName}'.", EndpointName);
            return;
        }

        var createdSubjects = 0;

        foreach (var subjectModel in payload.Subjects)
        {
            if (string.IsNullOrWhiteSpace(subjectModel.Name) || string.IsNullOrWhiteSpace(subjectModel.Code))
            {
                _logger.LogWarning("Skipping subject seed entry with missing name or code.");
                continue;
            }

            var exists = await context.Subjects.AnyAsync(s => s.Code == subjectModel.Code, cancellationToken);
            if (exists)
            {
                continue;
            }

            var subject = Subject.Create(
                subjectModel.Name,
                subjectModel.Code,
                subjectModel.Description);

            context.Subjects.Add(subject);
            createdSubjects++;
        }

        if (createdSubjects == 0)
        {
            return;
        }

        await context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Seeded {Count} subject(s) for endpoint '{EndpointName}'.", createdSubjects, EndpointName);
    }
}
