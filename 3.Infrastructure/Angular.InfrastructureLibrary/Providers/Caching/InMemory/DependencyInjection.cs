using Angular.ApplicationLibrary.Providers.Caching;
using Microsoft.Extensions.DependencyInjection;

namespace Angular.InfrastructureLibrary.Providers.Caching.InMemory;

public static class DependencyInjection
{
    public static IServiceCollection AddInMemoryCaching(this IServiceCollection services)
        => services.AddMemoryCache().AddSingleton<ICacheAdapter, InMemoryCacheAdapter>();
}

