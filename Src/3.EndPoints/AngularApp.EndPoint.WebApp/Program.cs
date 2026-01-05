using RG.Coding.WebApp;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebApp();

var app = builder.Build();

app.UseWebApp();

app.Run();

