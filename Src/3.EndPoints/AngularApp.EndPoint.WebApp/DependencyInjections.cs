using AngularApp.EndPoint.WebApi;
using AngularApp.EndPoint.WebApi.Providers.Swagger;
using AngularApp.ServiceDefaults;

namespace RG.Coding.WebApp;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddWebApp(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.AddServiceDefaults();

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();  // <-- OpenAPI enabled
        builder.Services.AddRazorPages();
        builder.Services.AddSwaggerApi();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
        builder.Services.AddWebApi(configuration);

        return builder;
    }
    public static WebApplication UseWebApp(this WebApplication app)
    {

        app.MapDefaultEndpoints();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
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
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.MapRazorPages().WithStaticAssets();
        app.UseSwaggerApi();

        app.MapFallbackToFile("/index.html");
        
        return app;
    }
}
