using LeoLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeoLMS.Infrastructure.Data.Configurations;

public class CalendarEventConfiguration : IEntityTypeConfiguration<CalendarEvent>
{
    public void Configure(EntityTypeBuilder<CalendarEvent> builder)
    {
        builder.Property(e => e.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int?>();

        builder.Property(e => e.Type)
            .HasConversion<int?>();

        builder.Property(e => e.Scope)
            .HasConversion<int?>();

        builder.OwnsOne(e => e.TimeRange, timeRange =>
        {
            timeRange.Property(tr => tr.Start)
                .HasColumnName("Start")
                .IsRequired();

            timeRange.Property(tr => tr.End)
                .HasColumnName("End")
                .IsRequired();
        });

        builder.Navigation(e => e.TimeRange).IsRequired();
    }
}
