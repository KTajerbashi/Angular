using AngularApp.EndPoint.WebApi;
using AngularApp.EndPoint.WebApi.Configurations.Identity;
using AngularApp.EndPoint.WebApi.Configurations.Swagger;
using AngularApp.EndPoint.WebApi.Extensions;
using AngularApp.EndPoint.WebApi.Middlewares.ExceptionsHandling;
using AngularApp.ServiceDefaults;

namespace AngularApp.EndPoint.WebApp;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddWebApp(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.AddServiceDefaults();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 64; // optional
            });
        builder.Services.AddOpenApi();  // <-- OpenAPI enabled
        builder.Services.AddRazorPages();
        builder.Services.AddSwaggerApi();

        builder.Services.AddIdentityServices(configuration, IdentityType.SessionBase);

        builder.Services.AddWebApi(configuration);

        return builder;
    }
    public static async Task<WebApplication> UseWebApp(this WebApplication app)
    {

        app.MapDefaultEndpoints();
        app.UseExceptionsHandling();

        if (!app.Environment.IsDevelopment())
        {
            //app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();           // <-- Swagger/OpenAPI UI
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthorization();

        app.MapControllers();

        app.UseIdentityServices(IdentityType.SessionBase);

        app.MapStaticAssets();
        app.MapRazorPages().WithStaticAssets();
        app.UseSwaggerApi();

        app.MapFallbackToFile("/index.html");

        if (app.Environment.IsDevelopment())
        {
            await app.InitialDatabaseWithSeedDataAsync();
        }

        return app;
    }
}
