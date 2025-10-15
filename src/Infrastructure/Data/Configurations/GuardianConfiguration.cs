using LeoLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeoLMS.Infrastructure.Data.Configurations;

public class GuardianConfiguration : IEntityTypeConfiguration<Guardian>
{
    public void Configure(EntityTypeBuilder<Guardian> builder)
    {
        builder.Property(g => g.FirstName)
        .HasMaxLength(200)
        .IsRequired();

        builder.Property(g => g.LastName)
        .HasMaxLength(200)
        .IsRequired();

        builder.Property(g => g.Email)
        .HasMaxLength(200)
        .IsRequired();

        builder.Property(g => g.PhoneNumber)
        .HasConversion<int?>()
        .IsRequired();

        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(a => a.Street1)
                .HasColumnName("Street1")
                .IsRequired();

            address.Property(a => a.Street2)
                .HasColumnName("Street2")
                .IsRequired();

            address.Property(a => a.City)
                .HasColumnName("City")
                .IsRequired();

            address.Property(a => a.State)
                .HasColumnName("State")
                .IsRequired();

            address.Property(a => a.PostalCode)
                .HasColumnName("PostalCode")
                .IsRequired();

            address.Property(a => a.Country)
                .HasColumnName("Country")
                .IsRequired();
        });
    }
}