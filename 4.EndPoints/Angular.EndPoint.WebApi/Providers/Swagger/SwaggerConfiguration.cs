using Microsoft.OpenApi.Models;

namespace Angular.EndPoint.WebApi.Providers.Swagger;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfigs(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clean Architecture API",
                Version = "v1",
                Description = "API documentation for the Clean Architecture application."
            });

            // Add XML comments if available
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        });
        return services;
    }
}
