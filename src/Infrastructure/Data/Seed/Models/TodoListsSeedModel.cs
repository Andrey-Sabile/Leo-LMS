using System;
using System.Collections.Generic;
using LeoLMS.Domain.Enums;

namespace LeoLMS.Infrastructure.Data.Seed.Models;

public class TodoListsSeedModel
{
    public IList<TodoListSeedItem> Lists { get; init; } = new List<TodoListSeedItem>();
}

public class TodoListSeedItem
{
    public string Title { get; init; } = string.Empty;

    public string Colour { get; init; } = string.Empty;

    public IList<TodoItemSeedItem> Items { get; init; } = new List<TodoItemSeedItem>();
}

public class TodoItemSeedItem
{
    public string Title { get; init; } = string.Empty;

    public string Note { get; init; } = string.Empty;

    public PriorityLevel? Priority { get; init; }

    public DateTime? Reminder { get; init; }

    public bool? Done { get; init; }
}
