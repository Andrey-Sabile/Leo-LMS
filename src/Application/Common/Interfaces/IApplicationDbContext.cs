using LeoLMS.Domain.Entities;

namespace LeoLMS.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<CalendarEvent> CalendarEvents { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
