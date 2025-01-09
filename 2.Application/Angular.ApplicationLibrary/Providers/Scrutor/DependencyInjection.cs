using System.Reflection;
using Angular.ApplicationLibrary.BaseApplication.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Angular.ApplicationLibrary.Providers.Scrutor;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, List<Assembly> assemblies)
    {
        services
                .Scan(s => s.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableToAny(typeof(IBaseRepository<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services, List<Assembly> assemblies)
    {
        services
              .Scan(s => s.FromAssemblies(assemblies)
              .AddClasses(c => c.AssignableToAny(typeof(IBaseService<,>)))
              .AsImplementedInterfaces()
              .WithScopedLifetime());
        return services;
    }
}

