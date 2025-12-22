using AngularApp.EndPoint.WebApi.Providers.Swagger;
using AngularApp.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddOpenApi();  // <-- OpenAPI enabled
builder.Services.AddRazorPages();
builder.Services.AddSwaggerApi();

var app = builder.Build();

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
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();
app.UseSwaggerApi();

app.MapFallbackToFile("/index.html");

app.Run();
