using Angular_WebApi.ApplicationBases.Repositories;
using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.ContextDB.Database;
using Angular_WebApi.Providers.Identity.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

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

        services.Configure<IdentityOptions>(options =>
        {
            // Configure password settings
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequiredUniqueChars = 1;

            // Configure lockout settings
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.AllowedForNewUsers = true;

            // Configure user settings
            options.User.RequireUniqueEmail = true;
        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });
        services.AddAuthorization();

        services.ConfigureApplicationCookie(options =>
        {
            // Specify the login page path
            options.LoginPath = "/Account/Login";
            // Specify the access denied page path
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.Cookie.Name = "Angular_WebApi.Cookie";  // You can specify a custom cookie name
            options.ExpireTimeSpan = TimeSpan.FromDays(1);  // Set cookie expiration time
            options.SlidingExpiration = true;  // Reset expiration on each request
        });

        services.AddScoped<IUser, CurrentUserInfo>();

        return services;
    }

    public static WebApplication UseIdentity(this WebApplication app)
    {

        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

}
