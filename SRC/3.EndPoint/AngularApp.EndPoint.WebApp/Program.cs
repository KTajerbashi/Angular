using AngularApp.EndPoint.WebApi;

namespace AngularApp.EndPoint.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        IConfiguration configuration = builder.Configuration;
        //builder.Services.AddApplication();
        //builder.Services.AddInfrastructure(configuration);
        builder.AddWebApi();
        builder.AddWebApp();

        var app = builder.Build();
        app.UseWebApi();
        app.UseWebApp();

        app.Run();
    }
}
