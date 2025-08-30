namespace Angular.Core.Application;
public static class DepenedencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration, List<Assembly> assemblies)
    {
        return services;
    }
}
