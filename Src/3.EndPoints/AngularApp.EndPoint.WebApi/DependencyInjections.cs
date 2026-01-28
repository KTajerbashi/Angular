using AngularApp.Core.Application;
using AngularApp.Infra.Data;
using Microsoft.AspNetCore.Identity;

namespace AngularApp.EndPoint.WebApi;

public static class DependencyInjections
{
    public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        var assemblies = ("AngularApp").GetAssemblies().ToArray();
        services.AddInfrastructure(configuration);
        services.AddApplication(configuration, assemblies);
        return services;
    }
}
