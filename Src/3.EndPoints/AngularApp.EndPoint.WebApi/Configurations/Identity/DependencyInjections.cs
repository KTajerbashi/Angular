using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.Infra.Data.DataContext;
using AngularApp.Infra.Data.References;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Text;

namespace AngularApp.EndPoint.WebApi.Configurations.Identity;

public static class DependencyInjections
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration, IdentityType type)
    {
        services
            .AddIdentity<UserEntity, RoleEntity>(options =>
            {
            })
            .AddRoles<RoleEntity>() // اگر Role داری
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        switch (type)
        {
            case IdentityType.CookieBase:
                {
                    services.AddCookieIdentity();
                    break;
                }
            case IdentityType.SessionBase:
                {
                    services.AddSessionIdentity();
                    break;
                }
            case IdentityType.TokenBase:
                {
                    services.AddTokenIdentity();
                    break;
                }
            default:
                break;
        }

        //services.AddCors(options =>
        //{
        //    options.AddPolicy("Angular",
        //        policy => policy
        //            .WithOrigins("http://localhost:4200")
        //            .AllowAnyHeader()
        //            .AllowAnyMethod()
        //            .AllowCredentials());
        //});


        return services;
    }

    private static IServiceCollection AddCookieIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<UserEntity, RoleEntity>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = ".Kamran.Auth";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            // IMPORTANT for Angular
            options.Cookie.SameSite = SameSiteMode.None;

            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/Account/AccessDenied";

            options.ExpireTimeSpan = TimeSpan.FromDays(7);
            options.SlidingExpiration = true;

            options.Events.OnRedirectToLogin = ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/api"))
                {
                    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                }

                ctx.Response.Redirect(ctx.RedirectUri);
                return Task.CompletedTask;
            };
        });

        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.FromMinutes(30);
        });

        services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(
                Path.Combine(AppContext.BaseDirectory, "keys")))
            .SetApplicationName("KamranApp");

        return services;
    }


    private static IServiceCollection AddSessionIdentity(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.Name = "app.session";
            options.Cookie.SameSite = SameSiteMode.Lax;
        });

        return services;
    }

    private static IServiceCollection AddTokenIdentity(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = true;
            options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = "AngularApp.Identity",
                ValidAudience = "AngularApp.Client",

                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("THIS_IS_A_SUPER_SECURE_KEY_123456")),

                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }

    public static WebApplication UseIdentityServices(this WebApplication app, IdentityType type)
    {
        switch (type)
        {
            case IdentityType.CookieBase:
            case IdentityType.TokenBase:
                {
                    app.UseAuthentication();
                    app.UseAuthorization();
                    break;
                }
            case IdentityType.SessionBase:
                {
                    app.UseSession();
                    break;
                }
        }
        //app.UseCors("Angular");
        return app;
    }

}
