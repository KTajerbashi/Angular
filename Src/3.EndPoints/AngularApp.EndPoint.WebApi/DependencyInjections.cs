using AngularApp.Core.Application;
using AngularApp.Core.Application.Extensions;
using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.Infra.Data;
using AngularApp.Infra.Data.DataContext;
using Microsoft.AspNetCore.Identity;

namespace AngularApp.EndPoint.WebApi;

public static class DependencyInjections
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        var assemblies = ("AngularApp").GetAssemblies().ToArray();
        services.AddInfrastructure(configuration);
        services.AddApplication(configuration, assemblies);

        //  Register Identity
        services
            .AddIdentity<UserEntity, RoleEntity>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
