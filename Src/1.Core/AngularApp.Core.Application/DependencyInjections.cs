using AngularApp.Core.Application.Providers.ScrutorDI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace AngularApp.Core.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddWithSingletonLifetime(assemblies, typeof(ISingletonLifeTime));
        services.AddWithScopedLifetime(assemblies, typeof(IScopeLifeTime));
        services.AddWithTransientLifetime(assemblies, typeof(ITransientLifeTime));
        return services;
    }

}
