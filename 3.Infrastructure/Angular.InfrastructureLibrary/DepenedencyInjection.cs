using Angular.ApplicationLibrary.Providers.Serializers;
using Angular.InfrastructureLibrary.Database;
using Angular.InfrastructureLibrary.Database.Initialiser;
using Angular.InfrastructureLibrary.Providers.Caching.InMemory;
using Angular.InfrastructureLibrary.Providers.Identity;
using Angular.InfrastructureLibrary.Providers.ObjectMapper;
using Angular.InfrastructureLibrary.Providers.Serializers.EPPlus;
using Angular.InfrastructureLibrary.Providers.Serializers.Microsoft;
using Angular.InfrastructureLibrary.Providers.Serializers.NewtonSoft;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Angular.InfrastructureLibrary;

public static class DepenedencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        /// AddDbContext
        services.AddDbContext(configuration);

        /// AddIdentity
        services.AddIdentityService(configuration);

        /// AddAutoMapperProfiles
        services.AddAutoMapperProfiles(configuration, "AutoMapper");

        /// AddInMemoryCaching
        services.AddInMemoryCaching();

        /// AddMicrosoftSerializer
        services.AddMicrosoftSerializer();

        return services;
    }


    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            option.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        });
        services.AddScoped<DatabaseContextInitialiser>();
        return services;
    }

    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)
        => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
    public static IServiceCollection AddMicrosoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, MicrosoftSerializer>();
    public static IServiceCollection AddNewtonSoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, NewtonSoftSerializer>();





}
