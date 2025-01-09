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
        ILogger<DatabaseContextInitialiser> logger,
        DatabaseContext context,
        UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager)
    {
        _logger = logger;
        _context = context;
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
        var administratorRole = new RoleEntity(Roles.Administrator, "Admin");

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
        var administrator = new UserEntity($"FullName : {username}", $"Desc : {username}");
        administrator.UserName = username;
        administrator.Email = $"{username}@manmail.ir";
        administrator.FirstName = $"{username}";
        administrator.LastName= $"{username}";
        administrator.DisplayName= $"{username} {username}";

        // Check if the username or email already exists
        if (!await _userManager.Users.AnyAsync(u => u.UserName == administrator.UserName && u.Email == administrator.Email))
        {
            var createResult = await _userManager.CreateAsync(administrator, password);
            if (createResult.Succeeded)
            {
                // Manually create a UserRoleEntity
                var userRoleEntity = new UserRoleEntity();
                var role = _context.Set<RoleEntity>().Single(item => item.Name == Roles.Administrator);
                userRoleEntity.Create(administrator.Id, role.Id, true);
                // Add the user role entity to your context
                _context.UserRoles.Add(userRoleEntity);
                await _context.SaveChangesAsync();  // Save changes to commit the role assignment

                _logger.LogInformation($"User {administrator.UserName} assigned to Administrator role.");
            }
            else
            {
                _logger.LogError($"Failed to create {username} user. Errors: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            _logger.LogWarning($"User with username '{username}' or email '{administrator.Email}' already exists.");
        }
    }


    private async Task SeedDefaultDataAsync()
    {
        if (!await _context.Users.AnyAsync())
        {


            await _context.SaveChangesAsync();
        }
    }
}
