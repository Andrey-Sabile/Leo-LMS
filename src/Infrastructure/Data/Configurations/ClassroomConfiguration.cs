using LeoLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeoLMS.Infrastructure.Data.Configurations;

public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        builder.Property(classroom => classroom.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(classroom => classroom.Description)
            .HasMaxLength(1000);

        builder.Property(classroom => classroom.SubjectId)
            .IsRequired();

        builder.Property(classroom => classroom.TeacherId)
            .IsRequired();

        builder.Ignore(classroom => classroom.MemberIds);
    }
}
