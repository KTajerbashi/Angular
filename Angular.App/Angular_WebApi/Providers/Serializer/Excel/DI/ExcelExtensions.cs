using Angular_WebApi.Providers.Serializer.Excel.Repository;
using Angular_WebApi.Providers.Serializer.Excel.Service;

namespace Angular_WebApi.Providers.Serializer.Excel.DI;

public static class ExcelExtensions
{
    public static IServiceCollection AddExcelServices(this IServiceCollection services)
    {
        services.AddScoped<IExcelSerializer, ExcelSerializer>();
        return services;
    }
}
