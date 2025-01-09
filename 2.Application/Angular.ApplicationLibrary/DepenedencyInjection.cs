using Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Behaviors;
using Angular.ApplicationLibrary.Providers.Scrutor;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Angular.ApplicationLibrary;
public static class DepenedencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration, List<Assembly> assemblies)
    {
        services.AddScoped<ProviderServices>();

        services.AddMediatR((option) =>
        {
            option.RegisterServicesFromAssemblies(assemblies.ToArray());
            option.AddOpenBehavior(typeof(ValidationBehavior<,>));
            option.AddOpenBehavior(typeof(LoggingBehavior<,>));
            option.AddOpenBehavior(typeof(PerformanceBehavior<,>));
            option.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
        });


        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

        services.AddRepositories(assemblies);

        services.AddServices(assemblies);

        return services;
    }
}
