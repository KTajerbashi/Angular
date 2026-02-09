namespace AngularApp.Core.Application.Common.Mapper;


/// <summary>
/// Centeral Registeration Mapper By Reflections
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    //private void ApplyMappingsFromAssembly(Assembly assembly)
    //{
    //    var types = assembly.GetExportedTypes()
    //        .Where(t => t.GetInterfaces().Any(i =>
    //            i.IsGenericType &&
    //            i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
    //        .ToList();

    //    foreach (var type in types)
    //    {
    //        var instance = Activator.CreateInstance(type);
    //        var methodInfo = type.GetMethod("Mapping");
    //        methodInfo?.Invoke(instance, new object[] { this });
    //    }
    //}

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t =>
                !t.IsAbstract &&
                !t.IsInterface &&
                !t.ContainsGenericParameters &&
                t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }

}

