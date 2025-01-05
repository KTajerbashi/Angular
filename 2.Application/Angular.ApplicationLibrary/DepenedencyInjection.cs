using Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Behaviors;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Angular.ApplicationLibrary;
public static class DepenedencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration,List<Assembly> assemblies)
    {
        services.AddScoped<ProviderServices>();

        services.AddMediatR((option) =>
        {
            option.RegisterServicesFromAssemblies(assemblies.ToArray());
            option.NotificationPublisher = new TaskWhenAllPublisher();
            option.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
