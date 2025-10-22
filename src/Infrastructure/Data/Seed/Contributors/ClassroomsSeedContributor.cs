using System.Threading;
using System.Threading.Tasks;
using LeoLMS.Domain.Entities;
using LeoLMS.Infrastructure.Data.Seed.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeoLMS.Infrastructure.Data.Seed.Contributors;

public class ClassroomsSeedContributor : IEndpointSeedContributor
{
    private readonly ISeedDataReader _reader;
    private readonly ILogger<ClassroomsSeedContributor> _logger;

    public ClassroomsSeedContributor(
        ISeedDataReader reader,
        ILogger<ClassroomsSeedContributor> logger)
    {
        _reader = reader;
        _logger = logger;
    }

    public string EndpointName => "Classrooms";

    public async Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
    {
        var payload = await _reader.ReadAsync<ClassroomsSeedModel>(EndpointName, cancellationToken);

        if (payload?.Classrooms is null || payload.Classrooms.Count == 0)
        {
            _logger.LogDebug("No seed data supplied for endpoint '{EndpointName}'.", EndpointName);
            return;
        }

        var createdClassrooms = 0;

        foreach (var classroomModel in payload.Classrooms)
        {
            if (string.IsNullOrWhiteSpace(classroomModel.Name) ||
                string.IsNullOrWhiteSpace(classroomModel.SubjectCode) ||
                string.IsNullOrWhiteSpace(classroomModel.TeacherEmail))
            {
                _logger.LogWarning("Skipping classroom seed entry with missing name, subject code, or teacher email.");
                continue;
            }

            var subject = await context.Subjects
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Code == classroomModel.SubjectCode.Trim(), cancellationToken);

            if (subject is null)
            {
                _logger.LogWarning(
                    "Skipping classroom seed entry '{Name}' because subject with code '{Code}' was not found.",
                    classroomModel.Name,
                    classroomModel.SubjectCode);
                continue;
            }

            var teacher = await context.Teachers
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Email == classroomModel.TeacherEmail.Trim(), cancellationToken);

            if (teacher is null)
            {
                _logger.LogWarning(
                    "Skipping classroom seed entry '{Name}' because teacher with email '{Email}' was not found.",
                    classroomModel.Name,
                    classroomModel.TeacherEmail);
                continue;
            }

            var exists = await context.Classrooms
                .AnyAsync(c => c.Name == classroomModel.Name && c.SubjectId == subject.Id && c.TeacherId == teacher.Id, cancellationToken);

            if (exists)
            {
                continue;
            }

            var classroom = Classroom.Create(
                classroomModel.Name,
                subject.Id,
                teacher.Id,
                classroomModel.Description);

            context.Classrooms.Add(classroom);
            createdClassrooms++;
        }

        if (createdClassrooms == 0)
        {
            return;
        }

        await context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Seeded {Count} classroom(s) for endpoint '{EndpointName}'.", createdClassrooms, EndpointName);
    }
}
