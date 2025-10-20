using System;
using System.Threading;
using System.Threading.Tasks;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;
using LeoLMS.Infrastructure.Data.Seed.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeoLMS.Infrastructure.Data.Seed.Contributors;

public class CalendarEventsSeedContributor : IEndpointSeedContributor
{
    private readonly ISeedDataReader _reader;
    private readonly ILogger<CalendarEventsSeedContributor> _logger;

    public CalendarEventsSeedContributor(
        ISeedDataReader reader,
        ILogger<CalendarEventsSeedContributor> logger)
    {
        _reader = reader;
        _logger = logger;
    }

    public string EndpointName => "CalendarEvents";

    public async Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
    {
        var payload = await _reader.ReadAsync<CalendarEventsSeedModel>(EndpointName, cancellationToken);

        if (payload?.Events is null || payload.Events.Count == 0)
        {
            _logger.LogDebug("No seed data supplied for endpoint '{EndpointName}'.", EndpointName);
            return;
        }

        var createdEvents = 0;

        foreach (var eventModel in payload.Events)
        {
            if (string.IsNullOrWhiteSpace(eventModel.Title))
            {
                _logger.LogWarning("Skipping calendar event seed entry with missing title.");
                continue;
            }

            var exists = await context.CalendarEvents.AnyAsync(
                e => e.Title == eventModel.Title &&
                     e.TimeRange.Start == eventModel.Start &&
                     e.TimeRange.End == eventModel.End,
                cancellationToken);

            if (exists)
            {
                continue;
            }

            var timeRange = EventTimeRange.Create(eventModel.Start, eventModel.End);

            var entity = CalendarEvent.Create(
                eventModel.Title,
                eventModel.Description,
                timeRange,
                eventModel.Status,
                eventModel.Type,
                eventModel.Scope,
                eventModel.ClassId,
                eventModel.SubjectId);

            context.CalendarEvents.Add(entity);
            createdEvents++;
        }

        if (createdEvents == 0)
        {
            return;
        }

        await context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Seeded {Count} calendar event(s) for endpoint '{EndpointName}'.", createdEvents, EndpointName);
    }
}
