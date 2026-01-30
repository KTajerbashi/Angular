using AngularApp.Core.Application.Common;

namespace AngularApp.Core.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddWithSingletonLifetime(assemblies, typeof(ISingletonLifeTime));
        services.AddWithScopedLifetime(assemblies, 
            typeof(IScopeLifeTime), 
            typeof(IBaseRepository<,>)
            );
        services.AddWithTransientLifetime(assemblies, typeof(ITransientLifeTime));

        services.AddScoped<ProviderServices>();

        return services;
    }

}
