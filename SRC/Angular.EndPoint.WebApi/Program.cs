using AngularApp.ServiceDefaults;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services
builder.Services.AddControllers();

// Add OpenAPI (for .NET 9 native OpenAPI)
builder.Services.AddOpenApi();

// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Basic Info
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "🚀 Angular Web Api EndPoint",
        Version = "v1",
        Description = "🚀 Angular Web Api EndPoint with ✔ using .NET 9",
        Contact = new OpenApiContact
        {
            Name = "Tajerbashi",
            Email = "kamrantajerbashi@example.com",
            Url = new Uri("https://github.com/KTajerbashi")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // XML comments (for controller/method summaries)
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

    // (Optional) Add JWT Authorization header to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Serve static files (for custom CSS/JS/logo)
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "🚀 Angular Web Api EndPoint");
        c.RoutePrefix = string.Empty;
        c.DocumentTitle = "🚀 Angular Web Api EndPoint";
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
        c.HeadContent = "<link rel='icon' href='/swagger-ui/logo.png' />";
    });
}




app.MapDefaultEndpoints();

// Map OpenAPI for minimal APIs
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
