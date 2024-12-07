namespace Angular_WebApi.Providers.MediatR.DI;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatRService(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        return services;
    }
}
