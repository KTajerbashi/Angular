using AngularApp.Core.Application.Common;
using AngularApp.Core.Application.Common.BaseApplication.Mediator.Behaviors;
using AngularApp.Core.Application.Common.Mapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

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

        services.RegisterMediatorWithValidationAndBehaviors(assemblies);
        services.RegisterMapperServices(assemblies);

        return services;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assemblies"></param>
    /// <returns></returns>
    private static IServiceCollection RegisterMediatorWithValidationAndBehaviors(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(cfg =>
        {
            //cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
            cfg.RegisterServicesFromAssemblies(assemblies);
        });

        services.AddValidatorsFromAssemblies(assemblies);

        services.AddTransient(
            typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)
            );
        return services;
    }

    private static IServiceCollection RegisterMapperServices(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(assemblies);
        });
        //services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }

}
