using Angular.ApplicationLibrary.Modules.Identity.Interfaces;
using Angular.DomainLibrary.Identity;
using Angular.InfrastructureLibrary.Database;
using Angular.InfrastructureLibrary.Database.Contants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Angular.InfrastructureLibrary.Providers.Identity;

public static class DependencyInjections
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityConfigs();
        services.AddFactories();
        services.AddSessionConfigs();
        return services;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddIdentityConfigs(this IServiceCollection services)
    {
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddIdentity<UserEntity, RoleEntity>(options =>
        {
            options.Password.RequiredLength = 6;  // Set the minimum password length
            options.Password.RequireDigit = true;  // Require at least one digit in password
            options.Password.RequireLowercase = true; // Require at least one lowercase letter
            options.Password.RequireUppercase = true; // Require at least one uppercase letter
            options.Password.RequireNonAlphanumeric = false; // Optional: Allow non-alphanumeric characters
        })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddRoles<RoleEntity>()                            // Configure roles
            .AddDefaultTokenProviders();
        ;
        return services;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddFactories(this IServiceCollection services)
    {
        services.AddScoped(typeof(SignInManager<UserEntity>), typeof(SignInManagerFactory<UserEntity>));
        services.AddScoped(typeof(UserManager<UserEntity>), typeof(UserManagerFactory<UserEntity>));
        services.AddScoped<IUserClaimsPrincipalFactory<UserEntity>, IdentityClaimFactory>();

        return services;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    private static IServiceCollection AddSessionConfigs(this IServiceCollection services)
    {

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.Name = "angular";
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        });

        services.AddAuthentication("Angular")
          .AddCookie(options =>
          {
              options.Cookie.Name = "angular";
              options.Events.OnRedirectToLogin = context =>
              {
                  if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == StatusCodes.Status200OK)
                  {
                      context.Response.Clear();
                      context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                      return Task.CompletedTask;
                  }
                  context.Response.Redirect(context.RedirectUri);
                  return Task.CompletedTask;
              };
          });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator));
        });
        return services;
    }

}




