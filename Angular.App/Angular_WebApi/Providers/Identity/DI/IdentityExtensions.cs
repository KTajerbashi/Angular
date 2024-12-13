using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.ContextDB;
using Microsoft.AspNetCore.Identity;
using System;

namespace Angular_WebApi.Providers.Identity.DI;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {

        // Add Authentication
        services.AddAuthentication()
            //.AddBearerToken(IdentityConstants.BearerScheme)
            ;

        // Add Authorization
        services.AddAuthorization();

        // Add IdentityCore
        services
            .AddIdentityCore<UserEntity>()
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddApiEndpoints();

        return services;
    }

    public static WebApplication UseIdentity(this WebApplication app)
    {

        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}
