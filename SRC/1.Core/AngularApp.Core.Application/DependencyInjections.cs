

namespace AngularApp.Core.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services, params Assembly[] assemblies)
    {
        return services;
    }
}
