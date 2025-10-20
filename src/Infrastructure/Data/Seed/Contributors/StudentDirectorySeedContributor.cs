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

public class StudentDirectorySeedContributor : IEndpointSeedContributor
{
    private readonly ISeedDataReader _reader;
    private readonly ILogger<StudentDirectorySeedContributor> _logger;

    public StudentDirectorySeedContributor(
        ISeedDataReader reader,
        ILogger<StudentDirectorySeedContributor> logger)
    {
        _reader = reader;
        _logger = logger;
    }

    public string EndpointName => "StudentDirectory";

    public async Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
    {
        var payload = await _reader.ReadAsync<StudentDirectorySeedModel>(EndpointName, cancellationToken);

        if (payload?.Students is null || payload.Students.Count == 0)
        {
            _logger.LogDebug("No seed data supplied for endpoint '{EndpointName}'.", EndpointName);
            return;
        }

        var createdStudents = 0;

        foreach (var studentModel in payload.Students)
        {
            if (string.IsNullOrWhiteSpace(studentModel.Email))
            {
                _logger.LogWarning("Skipping student seed entry with missing email.");
                continue;
            }

            var exists = await context.Students.AnyAsync(s => s.Email == studentModel.Email, cancellationToken);

            if (exists)
            {
                continue;
            }

            var addressModel = studentModel.Address ?? throw new InvalidOperationException("Student seed entry must include an address.");
            var studentAddress = Address.Create(
                addressModel.Street1,
                addressModel.Street2,
                addressModel.City,
                addressModel.State,
                addressModel.PostalCode,
                addressModel.Country);

            var student = Student.Create(
                studentModel.FirstName,
                studentModel.LastName,
                studentModel.Email,
                studentAddress);

            foreach (var guardianModel in studentModel.Guardians ?? Array.Empty<GuardianSeedModel>())
            {
                if (string.IsNullOrWhiteSpace(guardianModel.Email))
                {
                    _logger.LogWarning("Skipping guardian seed entry with missing email for student '{Email}'.", studentModel.Email);
                    continue;
                }

                var guardianAddressModel = guardianModel.Address ?? addressModel;
                var guardianAddress = Address.Create(
                    guardianAddressModel.Street1,
                    guardianAddressModel.Street2,
                    guardianAddressModel.City,
                    guardianAddressModel.State,
                    guardianAddressModel.PostalCode,
                    guardianAddressModel.Country);

                var guardian = Guardian.Create(
                    guardianModel.FirstName,
                    guardianModel.LastName,
                    guardianModel.Email,
                    guardianModel.PhoneNumber,
                    new List<Student>(),
                    guardianAddress);

                guardian.Students.Add(student);
                student.Guardians.Add(guardian);
            }

            context.Students.Add(student);
            createdStudents++;
        }

        if (createdStudents == 0)
        {
            return;
        }

        await context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Seeded {Count} student(s) for endpoint '{EndpointName}'.", createdStudents, EndpointName);
    }
}
