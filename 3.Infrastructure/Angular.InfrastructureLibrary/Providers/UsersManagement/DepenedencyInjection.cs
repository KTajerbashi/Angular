using Angular.ApplicationLibrary.Providers.UsersManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Angular.InfrastructureLibrary.Providers.UsersManagement;
public static class DepenedencyInjection
{
    public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, IConfiguration configuration, bool useFake = false)
    {
        if (useFake)
        {
            services.AddSingleton<IUserInfoService, FakeUserInfoService>();

        }
        else
        {
            services.Configure<UserManagementOptions>(configuration);
            services.AddSingleton<IUserInfoService, WebUserInfoService>();

        }
        return services;
    }


    public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, IConfiguration configuration, string sectionName, bool useFake = false)
    {
        services.AddZaminWebUserInfoService(configuration.GetSection(sectionName), useFake);
        return services;
    }

    public static IServiceCollection AddZaminWebUserInfoService(this IServiceCollection services, Action<UserManagementOptions> setupAction, bool useFake = false)
    {
        if (useFake)
        {
            services.AddSingleton<IUserInfoService, FakeUserInfoService>();

        }
        else
        {
            services.Configure(setupAction);
            services.AddSingleton<IUserInfoService, WebUserInfoService>();

        }
        return services;
    }
}