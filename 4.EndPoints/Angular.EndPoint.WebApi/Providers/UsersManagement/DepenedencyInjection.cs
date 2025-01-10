using Angular.ApplicationLibrary.Providers.UsersManagement;

namespace Angular.EndPoint.WebApi.Providers.UsersManagement;
public static class DepenedencyInjection
{
    public static IServiceCollection AddWebUserInfoService(this IServiceCollection services, IConfiguration configuration, bool useFake = false)
    {
        if (useFake)
        {
            services.AddScoped<IUserInfoService, FakeUserInfoService>();

        }
        else
        {
            services.Configure<UserManagementOptions>(configuration);
            services.AddScoped<IUserInfoService, WebUserInfoService>();

        }
        return services;
    }


    //public static IServiceCollection AddWebUserInfoService(this IServiceCollection services, IConfiguration configuration, string sectionName, bool useFake = false)
    //{
    //    services.AddWebUserInfoService(configuration.GetSection(sectionName), useFake);
    //    return services;
    //}

    //public static IServiceCollection AddWebUserInfoService(this IServiceCollection services, Action<UserManagementOptions> setupAction, bool useFake = false)
    //{
    //    if (useFake)
    //    {
    //        services.AddScoped<IUserInfoService, FakeUserInfoService>();

    //    }
    //    else
    //    {
    //        services.Configure(setupAction);
    //        services.AddScoped<IUserInfoService, WebUserInfoService>();

    //    }
    //    return services;
    //}
}