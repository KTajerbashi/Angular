using Angular.ApplicationLibrary;
using Angular.ApplicationLibrary.Extensions;
using Angular.EndPoint.WebApi.Providers.Swagger;
using Angular.EndPoint.WebApi.Providers.UsersManagement;
using Angular.InfrastructureLibrary;

namespace Angular.EndPoint.WebApi;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddWebApiService(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        var assemblies = ("Angular").GetAssemblies();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddControllers();
        
        builder.Services.AddOpenApi();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerConfigs();

        builder.Services.AddInfrastructureServices(builder.Configuration);

        builder.Services.AddApplicationServices(builder.Configuration, assemblies);

        builder.Services.AddWebUserInfoService(configuration, false);

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

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
