using AngularApp.Core.Domain.Entities.Security;
using AngularApp.Infra.Data.DataContext;
using AngularApp.Infra.Data.DataContext.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AngularApp.Infra.Data;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //  Register Database Context
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)
            );
            options.AddInterceptors(new ShadowPropertySaveChangesInterceptor());
        });

        

        return services;
    }
}
