using Angular_WebApi.Middlewares.ExceptionHandler.Middleware;
using Angular_WebApi.Providers.Application.DI;
using Angular_WebApi.Providers.HttpContexts.DI;
using Angular_WebApi.Providers.Identity.DI;
using Angular_WebApi.Providers.Mapper.DI;
using Angular_WebApi.Providers.MediatR.DI;
using System.Reflection;

namespace Angular_WebApi;


public static class DependencyInjections
{
    public static WebApplication AddApplicationServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddCommonProviders();

        builder.Services.AddRepositoriesAndServices(Assembly.GetExecutingAssembly());

        builder.Services.AddDatabaseServices(configuration);

        //  Provider
        builder.Services.AddMapperProvider();

        //  Provider
        builder.Services.AddMediatRService();

        //  Provider
        builder.Services.AddIdentityServices();


        // Add CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp", policy =>
            {
                policy.WithOrigins("http://localhost:4200") // Angular's development server
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        return builder.Build();
    }

    public static WebApplication UseApplicationPipline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseIdentity();

        app.UseCors("AllowAngularApp");

        app.UseHttpsRedirection();

        app.MapControllers();

        return app;
    }
}
