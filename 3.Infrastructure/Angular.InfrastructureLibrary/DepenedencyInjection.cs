using Angular.ApplicationLibrary.Providers.Serializers;
using Angular.InfrastructureLibrary.Providers.Caching.InMemory;
using Angular.InfrastructureLibrary.Providers.ObjectMapper;
using Angular.InfrastructureLibrary.Providers.Serializers.EPPlus;
using Angular.InfrastructureLibrary.Providers.Serializers.Microsoft;
using Angular.InfrastructureLibrary.Providers.Serializers.NewtonSoft;
using Angular.InfrastructureLibrary.Providers.UsersManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Angular.InfrastructureLibrary;

public static class DepenedencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        /// AddDbContext
        services.AddDbContext(configuration);

        /// AddIdentity
        services.AddIdentity(configuration);

        /// AddIdentitySession
        services.AddIdentitySession(configuration);

        /// AddIdentityJwt
        services.AddIdentityJwt(configuration);

        /// AddAutoMapperProfiles
        services.AddAutoMapperProfiles(configuration, "AutoMapper");

        /// AddInMemoryCaching
        services.AddInMemoryCaching();

        /// AddMicrosoftSerializer
        services.AddMicrosoftSerializer();

        /// AddWebUserInfoService
        services.AddWebUserInfoService(configuration, false);

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
    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)
        => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
    public static IServiceCollection AddMicrosoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, MicrosoftSerializer>();
    public static IServiceCollection AddNewtonSoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, NewtonSoftSerializer>();





}
