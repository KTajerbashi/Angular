using Angular.EndPoint.WebApi;
using Microsoft.OpenApi.Models;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddWebAppService(this WebApplicationBuilder builder)
    {
        // Add Razor Pages services
        builder.Services.AddRazorPages();

        return builder;
    }
    public static WebApplication UseWebAppPipeline(this WebApplication app)
    {

        app.UseDefaultFiles();
        app.MapStaticAssets();

        app.UseWebApiPipeline();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();
        
        app.MapFallbackToFile("/index.html");

        return app;
    }
}






#region Web App Default Configuration
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();
//app.MapRazorPages()
//   .WithStaticAssets();

//app.Run();
#endregion
