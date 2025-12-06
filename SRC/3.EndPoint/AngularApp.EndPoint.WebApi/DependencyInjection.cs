
using AngularApp.EndPoint.WebApi.Providers.Swagger;

namespace AngularApp.EndPoint.WebApi;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddWebApi(this WebApplicationBuilder builder)
    {
        //builder.AddServiceDefaults();

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddSwaggerConfiguration();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        return builder;
    }

    public static WebApplication UseWebApi(this WebApplication app)
    {
        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerConfiguration();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();
        return app;
    }

}
