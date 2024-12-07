using Angular_WebApi.Utilities;

namespace Angular_WebApi.Providers.HttpContexts.DI;

public static class HttpContextExtensions
{
    public static UtilitiesServices ApplicationContext(this HttpContext httpContext) =>
        (UtilitiesServices)httpContext.RequestServices.GetService(typeof(UtilitiesServices));

    public static IServiceCollection AddCommonProviders(this IServiceCollection services)
    {
        services.AddTransient<UtilitiesServices>();
        return services;
    }
}