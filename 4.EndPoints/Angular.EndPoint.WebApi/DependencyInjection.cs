using Microsoft.OpenApi.Models;
using Angular.InfrastructureLibrary;
using Angular.ApplicationLibrary;
using Angular.ApplicationLibrary.Extensions;

namespace Angular.EndPoint.WebApi;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddWebApiService(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        var assemblies = ("Angular").GetAssemblies();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddInfrastructureServices(builder.Configuration);

        builder.Services.AddApplicationServices(builder.Configuration, assemblies);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
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


        return builder;
    }
    public static WebApplication UseWebApiPipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API v1");
                options.RoutePrefix = "swagger"; // Swagger at the root
            });
        }
        else
        {
            // Secure Swagger in production
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "docs/{documentName}/swagger.json";
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
