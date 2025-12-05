
namespace AngularApp.Infrastructure.Data;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration,
        params Assembly[] assemblies
        )
    {
        return services;
    }
}
