using System;
using System.Collections.Generic;
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

        var teacherLookup = await context.Teachers
            .ToDictionaryAsync(t => NormalizeEmail(t.Email), cancellationToken);

        var studentLookup = await context.Students
            .ToDictionaryAsync(s => NormalizeEmail(s.Email), cancellationToken);

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

            var normalizedTeacherEmail = NormalizeEmail(classroomModel.TeacherEmail);

            if (!teacherLookup.TryGetValue(normalizedTeacherEmail, out var primaryTeacher))
            {
                _logger.LogWarning(
                    "Skipping classroom seed entry '{Name}' because teacher with email '{Email}' was not found.",
                    classroomModel.Name,
                    classroomModel.TeacherEmail);
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

            var exists = await context.Classrooms
                .AnyAsync(c => c.Name == classroomModel.Name && c.SubjectId == subject.Id && c.TeacherId == primaryTeacher.Id, cancellationToken);

            if (exists)
            {
                continue;
            }

            var classroom = Classroom.Create(
                classroomModel.Name,
                subject.Id,
                primaryTeacher.Id,
                classroomModel.Description);

            classroom.AddTeacher(primaryTeacher);

            var teacherIds = new HashSet<int> { primaryTeacher.Id };

            foreach (var email in classroomModel.AdditionalTeacherEmails ?? Array.Empty<string>())
            {
                var normalizedEmail = NormalizeEmail(email);

                if (string.IsNullOrEmpty(normalizedEmail) || !teacherLookup.TryGetValue(normalizedEmail, out var additionalTeacher))
                {
                    _logger.LogWarning(
                        "Ignoring classroom additional teacher assignment for '{Name}' because teacher email '{Email}' was not found.",
                        classroomModel.Name,
                        email);
                    continue;
                }

                if (teacherIds.Add(additionalTeacher.Id))
                {
                    classroom.AddTeacher(additionalTeacher);
                }
            }

            var studentIds = new HashSet<int>();

            foreach (var email in classroomModel.StudentEmails ?? Array.Empty<string>())
            {
                var normalizedEmail = NormalizeEmail(email);

                if (string.IsNullOrEmpty(normalizedEmail) || !studentLookup.TryGetValue(normalizedEmail, out var student))
                {
                    _logger.LogWarning(
                        "Ignoring classroom student assignment for '{Name}' because student email '{Email}' was not found.",
                        classroomModel.Name,
                        email);
                    continue;
                }

                if (studentIds.Add(student.Id))
                {
                    classroom.AddStudent(student);
                }
            }

            if (studentIds.Count < 20)
            {
                _logger.LogWarning(
                    "Classroom seed entry '{Name}' resolved {Count} student(s); expected at least 20.",
                    classroomModel.Name,
                    studentIds.Count);
            }

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

    private static string NormalizeEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return string.Empty;
        }

        return email.Trim().ToLowerInvariant();
    }
}
