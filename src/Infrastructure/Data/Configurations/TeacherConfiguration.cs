using LeoLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeoLMS.Infrastructure.Data.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(t => t.FirstName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.LastName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.PhoneNumber)
            .IsRequired();

        builder.OwnsOne(t => t.Address, address =>
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
