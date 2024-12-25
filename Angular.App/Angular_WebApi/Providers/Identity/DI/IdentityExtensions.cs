using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.ContextDB.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Angular_WebApi.Providers.Identity.DI;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {

        // Configure Identity
        services.AddIdentity<UserEntity, RoleEntity>()
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddRoles<RoleEntity>()
            .AddDefaultTokenProviders()
            .AddApiEndpoints()
            ;


        // Configure SignInManager, RoleManager, and UserManager (auto-configured with AddIdentity)
        //services.AddScoped<SignInManager<UserEntity>>();
        //services.AddScoped<RoleManager<RoleEntity>>();
        //services.AddScoped<UserManager<UserEntity>>();

        // Add Authentication
        services.AddAuthentication()
            //.AddBearerToken(IdentityConstants.BearerScheme)
            ;

        // Add Authorization
        services.AddAuthorization();

        return services;
    }

    public static WebApplication UseIdentity(this WebApplication app)
    {

        app.UseAuthentication();

        app.UseAuthorization();

        return app;
    }

}
