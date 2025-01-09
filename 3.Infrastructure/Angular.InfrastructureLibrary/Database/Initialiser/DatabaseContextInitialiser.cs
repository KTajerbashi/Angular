using Angular.DomainLibrary.Identity;
using Angular.InfrastructureLibrary.Database.Contants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Angular.InfrastructureLibrary.Database.Initialiser;

public class DatabaseContextInitialiser
{
    private readonly ILogger<DatabaseContextInitialiser> _logger;
    private readonly DatabaseContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<RoleEntity> _roleManager;

    public DatabaseContextInitialiser(
        DatabaseContext context,
        ILogger<DatabaseContextInitialiser> logger,
        UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager)
    {
        _context = context;
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
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
            await SeedRolesAsync();
            await SeedUsersAsync();
            await SeedDefaultDataAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task SeedRolesAsync()
    {
        await createRolesAsync("Admin");
        await createRolesAsync("User");
    }

    private async Task createRolesAsync(string name)
    {
        var administratorRole = new RoleEntity(Roles.Administrator, name);

        if (await _roleManager.Roles.AllAsync(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }
    }

    private async Task SeedUsersAsync()
    {
        await createUser("tajerbashi", "@Tajerbashi123");
        await createUser("mcbehruz", "@McBehruz123");
        await createUser("mirzaie", "@Mirzaie123");
        await createUser("saied_sayed", "@Saied123");
    }

    private async Task createUser(string username, string password)
    {
        var administrator = new UserEntity
        {
            UserName = username,
            Email = $"{username}@mail.com",
            FirstName = username,
            LastName = username,
            PhoneNumber = username,
            DisplayName = username,
        };

        if (await _userManager.Users.AllAsync(u => u.UserName != administrator.UserName))
        {
            var createResult = await _userManager.CreateAsync(administrator, password);
            if (createResult.Succeeded)
            {
                await _userManager.AddToRolesAsync(administrator, new[] { Roles.Administrator });
            }
            else
            {
                _logger.LogError($"Failed to create {username} user: {{Errors}}", string.Join(", ", createResult.Errors.Select(e => e.Description)));
            }
        }
    }

    private async Task SeedDefaultDataAsync()
    {
        if (!await _context.Users.AnyAsync())
        {
            _context.Users.Add(new UserEntity
            {
                UserName = "Todo List",
            });

            await _context.SaveChangesAsync();
        }
    }

}