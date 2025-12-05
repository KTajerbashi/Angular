namespace AngularApp.EndPoint.WebApi.Providers.Swagger;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        return services;
    }

    public static WebApplication UseSwaggerConfiguration(this WebApplication app)
    {

        // Enable Swagger UI
        app.UseSwagger();

        // Configure Swagger UI with custom options
        app.UseSwaggerUI(c =>
        {
            // Add multiple services with dropdowns for JSON files
            //c.SwaggerEndpoint("serviceA.json", "Service A API");
            //c.SwaggerEndpoint("serviceB.json", "Service B API");

            // Customize the UI (optional)
            c.EnableDeepLinking();
            c.DisplayOperationId();

       
        });

        return app;
    }
}
