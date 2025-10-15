using LeoLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeoLMS.Infrastructure.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.FirstName)
        .HasMaxLength(200)
        .IsRequired();

        builder.Property(s => s.LastName)
        .HasMaxLength(200)
        .IsRequired();

        builder.Property(s => s.Email)
        .HasMaxLength(200)
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