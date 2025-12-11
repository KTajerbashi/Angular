using Microsoft.OpenApi;

namespace AngularApp.EndPoint.WebApi.Providers.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerApi(this IServiceCollection services)
    {

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My API",
                Version = "v1"
            });

        });


        return services;

    }
    public static WebApplication UseSwaggerApi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}
