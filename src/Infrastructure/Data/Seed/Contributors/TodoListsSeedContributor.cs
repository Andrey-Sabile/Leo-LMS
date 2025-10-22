using System;
using System.Threading;
using System.Threading.Tasks;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.Enums;
using LeoLMS.Domain.Exceptions;
using LeoLMS.Domain.ValueObjects;
using LeoLMS.Infrastructure.Data.Seed.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeoLMS.Infrastructure.Data.Seed.Contributors;

public class TodoListsSeedContributor : IEndpointSeedContributor
{
    private readonly ISeedDataReader _reader;
    private readonly ILogger<TodoListsSeedContributor> _logger;

    public TodoListsSeedContributor(
        ISeedDataReader reader,
        ILogger<TodoListsSeedContributor> logger)
    {
        _reader = reader;
        _logger = logger;
    }

    public string EndpointName => "TodoLists";

    public async Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
    {
        var payload = await _reader.ReadAsync<TodoListsSeedModel>(EndpointName, cancellationToken);

        if (payload?.Lists is null || payload.Lists.Count == 0)
        {
            _logger.LogDebug("No seed data supplied for endpoint '{EndpointName}'.", EndpointName);
            return;
        }

        var createdLists = 0;

        foreach (var listModel in payload.Lists)
        {
            if (string.IsNullOrWhiteSpace(listModel.Title))
            {
                _logger.LogWarning("Skipping todo list seed entry with missing title.");
                continue;
            }

            var exists = await context.TodoLists.AnyAsync(list => list.Title == listModel.Title, cancellationToken);
            if (exists)
            {
                continue;
            }

            var list = new TodoList
            {
                Title = listModel.Title,
                Colour = ResolveColour(listModel.Colour),
            };

            foreach (var itemModel in listModel.Items ?? Array.Empty<TodoItemSeedItem>())
            {
                if (string.IsNullOrWhiteSpace(itemModel.Title))
                {
                    _logger.LogWarning("Skipping todo item seed entry with missing title for list '{ListTitle}'.", listModel.Title);
                    continue;
                }

                list.Items.Add(new TodoItem
                {
                    Title = itemModel.Title,
                    Note = itemModel.Note,
                    Priority = itemModel.Priority ?? PriorityLevel.None,
                    Reminder = itemModel.Reminder,
                    Done = itemModel.Done ?? false,
                });
            }

            context.TodoLists.Add(list);
            createdLists++;
        }

        if (createdLists == 0)
        {
            return;
        }

        await context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Seeded {Count} todo list(s) for endpoint '{EndpointName}'.", createdLists, EndpointName);
    }

    private Colour ResolveColour(string? colourCode)
    {
        if (string.IsNullOrWhiteSpace(colourCode))
        {
            return Colour.White;
        }

        try
        {
            return (Colour)colourCode;
        }
        catch (UnsupportedColourException ex)
        {
            _logger.LogWarning(ex, "Unsupported colour '{Colour}' for endpoint '{EndpointName}'. Falling back to default.", colourCode, EndpointName);
            return Colour.White;
        }
    }
}
