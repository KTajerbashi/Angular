using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.Infra.Data.DataContext;
using AngularApp.Infra.Data.References;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AngularApp.Infra.Data.Extensions;

public static class ApplicationDbContextSeed
{
    public static async Task SeedAsync(DatabaseContext context, IServiceProvider services)
    {
        // Example: Seed Roles
        var roleManager = services.GetRequiredService<RoleManager<RoleEntity>>();

        string[] roles = [RolesReference.Admin, RolesReference.User];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new RoleEntity(role));
            }
        }

        // Example: Seed Admin User
        var userManager = services.GetRequiredService<UserManager<UserEntity>>();

        if (!await userManager.Users.AnyAsync())
        {
            //  Admin 
            var admin = new UserEntity(new()
            {
                FirstName = "Kamran",
                LastName = "Tajerbashi",
                DisplayName = "Kamran Tajerbashi",
                UserName = "Kamran_Tajerbashi",
                Email = "Tajerbashi@mail.com",
                PhoneNumber = "+1 123 456 789",
            });

            var adminResult = await userManager.CreateAsync(admin, "@Admin123");

            if (adminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, RolesReference.Admin);
            }

            //  User 


            var user = new UserEntity(new()
            {
                FirstName = "Donald",
                LastName = "Trump",
                DisplayName = "Donald Trump",
                UserName = "Donald_Trump",
                Email = "Donald_Trump@mail.com",
                PhoneNumber = "+1 123 456 788",
            });

            var userResult = await userManager.CreateAsync(user, "@User123");

            if (userResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, RolesReference.User);
            }

        }
    }
}