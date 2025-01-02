using Angular.InfrastructureLibrary.Database;
using Angular.InfrastructureLibrary.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Angular.InfrastructureLibrary;

public static class DepenedencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration
        )
    {
        services.AddDbContext(configuration);
        services.AddIdentity(configuration);
        services.AddIdentitySession(configuration);
        services.AddIdentityJwt(configuration);
        return services;
    }
    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<DatabaseContext>(option =>
        //     option.UseSqlServer(configuration.GetConnectionString("ConnectionString"))

        //     );
        //var provider = services.BuildServiceProvider();
        //Task.FromResult(provider.InitialiseDatabaseAsync());
        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }

    private static IServiceCollection AddIdentitySession(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }

    private static IServiceCollection AddIdentityJwt(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }

}
