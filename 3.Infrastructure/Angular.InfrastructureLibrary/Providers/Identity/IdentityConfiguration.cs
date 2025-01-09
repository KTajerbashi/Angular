using Angular.DomainLibrary.Identity;
using Angular.InfrastructureLibrary.Database;
using Microsoft.AspNetCore.Identity;

namespace Angular.InfrastructureLibrary.Providers.Identity;

public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<UserEntity, RoleEntity>()
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();
        ;
        return services;
    }

}
