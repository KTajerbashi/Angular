using Angular_WebApi.ApplicationBases.Patterns;
using Angular_WebApi.ApplicationBases.Repositories;
using Angular_WebApi.ApplicationBases.Services;
using Angular_WebApi.ContextDB.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Angular_WebApi.Providers.Application.DI;

public static class ApplicationExtensions
{
    public static IServiceCollection AddRepositoriesAndServices(this IServiceCollection services, Assembly assembly)
    {
        // Register repositories by scanning for types that implement IBaseRepository<,>
        services.Scan(scan => scan
            .FromAssemblyDependencies(assembly) // Scan the provided assembly
            .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<,>))) // Scan for interfaces that implement IBaseRepository<,>
            .AddClasses(classes => classes.AssignableTo(typeof(IUnitOfWork))) // Scan for interfaces that implement IBaseRepository<,>
            .AsImplementedInterfaces() // Register the class as its implemented interfaces
            .WithTransientLifetime()); // Set the desired lifetime (Transient in this case)
        return services;
    }

    public static IServiceCollection AddDatabaseServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<DatabaseContextInitialiser>();

        services.AddDbContext<DatabaseContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
        });

        return services;
    }


}

#region Comment Version 1 DI

//public static class ApplicationExtensions
//{
//    public static IServiceCollection AddRepositoriesAndServices(this IServiceCollection services, Assembly assembly)
//    {
//        // Register repositories by scanning for types that implement IRepository
//        services.Scan(scan => scan
//            .FromAssemblyOf<IBaseRepository<,>,BaseRepository<,>>()
//            .AddClasses(classes => classes.AssignableTo<IRepository>())
//            .AsImplementedInterfaces()
//            .WithTransientLifetime());

//        // Register services by scanning for types that implement IService
//        //services.Scan(scan => scan
//        //    .FromAssemblyOf<IService>()
//        //    .AddClasses(classes => classes.AssignableTo<IService>())
//        //    .AsImplementedInterfaces()
//        //    .WithTransientLifetime());

//        return services;
//    }
//}

#endregion


#region Comment Version 1 DI
//public static IServiceCollection AddRepositoriesAndServices(this IServiceCollection services, Assembly assembly)
//   {
//       // Register Repositories
//       var repositoryType = typeof(IBaseRepository<,>);
//       var repositories = assembly.GetTypes()
//           .Where(type => repositoryType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);

//       foreach (var repository in repositories)
//       {
//           var implementedInterfaces = repository.GetInterfaces()
//               .Where(i => i != repositoryType); // Exclude the marker interface

//           foreach (var @interface in implementedInterfaces)
//           {
//               services.AddScoped(@interface, repository);
//           }
//       }

//       // Register Services
//       //var serviceType = typeof(IService);
//       //var servicesToRegister = assembly.GetTypes()
//       //    .Where(type => serviceType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);

//       //foreach (var service in servicesToRegister)
//       //{
//       //    var implementedInterfaces = service.GetInterfaces()
//       //        .Where(i => i != serviceType); // Exclude the marker interface

//       //    foreach (var @interface in implementedInterfaces)
//       //    {
//       //        services.AddTransient(@interface, service);
//       //    }
//       //}

//       return services;
//   }

#endregion