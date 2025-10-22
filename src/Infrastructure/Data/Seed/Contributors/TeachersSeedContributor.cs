using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;
using LeoLMS.Infrastructure.Data.Seed.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeoLMS.Infrastructure.Data.Seed.Contributors;

public class TeachersSeedContributor : IEndpointSeedContributor
{
    private readonly ISeedDataReader _reader;
    private readonly ILogger<TeachersSeedContributor> _logger;

    public TeachersSeedContributor(
        ISeedDataReader reader,
        ILogger<TeachersSeedContributor> logger)
    {
        _reader = reader;
        _logger = logger;
    }

    public string EndpointName => "Teachers";

    public async Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
    {
        var payload = await _reader.ReadAsync<TeachersSeedModel>(EndpointName, cancellationToken);

        if (payload?.Teachers is null || payload.Teachers.Count == 0)
        {
            _logger.LogDebug("No seed data supplied for endpoint '{EndpointName}'.", EndpointName);
            return;
        }

        var createdTeachers = 0;

        foreach (var teacherModel in payload.Teachers)
        {
            if (string.IsNullOrWhiteSpace(teacherModel.Email))
            {
                _logger.LogWarning("Skipping teacher seed entry with missing email.");
                continue;
            }

            var exists = await context.Teachers.AnyAsync(t => t.Email == teacherModel.Email, cancellationToken);
            if (exists)
            {
                continue;
            }

            if (teacherModel.Address is null)
            {
                _logger.LogWarning("Skipping teacher seed entry for '{Email}' because the address is missing.", teacherModel.Email);
                continue;
            }

            var addressModel = teacherModel.Address;
            var address = Address.Create(
                addressModel.Street1,
                addressModel.Street2,
                addressModel.City,
                addressModel.State,
                addressModel.PostalCode,
                addressModel.Country);

            var teacher = Teacher.Create(
                teacherModel.FirstName,
                teacherModel.LastName,
                teacherModel.Email,
                teacherModel.PhoneNumber,
                address,
                new List<Classroom>());

            context.Teachers.Add(teacher);
            createdTeachers++;
        }

        if (createdTeachers == 0)
        {
            return;
        }

        await context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Seeded {Count} teacher(s) for endpoint '{EndpointName}'.", createdTeachers, EndpointName);
    }
}
