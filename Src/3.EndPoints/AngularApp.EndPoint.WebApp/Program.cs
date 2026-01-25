using AngularApp.EndPoint.WebApp;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebApp();

var app = builder.Build();

await app.UseWebApp();

app.Run();

