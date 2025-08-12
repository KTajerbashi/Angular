namespace Angular.EndPoint.WebApi.Providers;

public static class SwaggerProvider
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        const string email = "kamrantajerbashi@gmail.com";
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Angular API",
                Version = "v1",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                {
                    Email = email,
                    Name = "Tajerbashi",
                    Url = new Uri("https://github.com/KTajerbashi/Angular.git")
                },
                Description = "",
                License = new Microsoft.OpenApi.Models.OpenApiLicense()
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://example.com/license")
                },
                TermsOfService = new Uri("https://example.com/terms"),
            });
            c.CustomSchemaIds(x => x.FullName);
        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerProvider(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Angular API V1");
            c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
        });
        return app;
    }
}
