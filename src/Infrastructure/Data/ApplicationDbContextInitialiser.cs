using LeoLMS.Domain.Constants;
using LeoLMS.Infrastructure.Data.Seed;
using LeoLMS.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LeoLMS.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IEnumerable<IEndpointSeedContributor> _seedContributors;

    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IEnumerable<IEndpointSeedContributor> seedContributors)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _seedContributors = seedContributors;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            // See https://jasontaylor.dev/ef-core-database-initialisation-strategies
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var rolesToSeed = new[]
        {
            new IdentityRole(Roles.Administrator),
            new IdentityRole(Roles.Teacher),
            new IdentityRole(Roles.Student),
        };

        foreach (var role in rolesToSeed)
        {
            if (_roleManager.Roles.All(r => r.Name != role.Name))
            {
                await _roleManager.CreateAsync(role);
            }
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(Roles.Administrator))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { Roles.Administrator });
            }
        }

        foreach (var contributor in _seedContributors)
        {
            try
            {
                await contributor.SeedAsync(_context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to execute seed contributor for endpoint '{EndpointName}'.", contributor.EndpointName);
                throw;
            }
        }
    }
}
