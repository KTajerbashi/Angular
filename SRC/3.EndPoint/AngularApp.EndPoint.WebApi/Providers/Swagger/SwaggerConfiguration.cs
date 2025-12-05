using Microsoft.OpenApi;

namespace AngularApp.EndPoint.WebApi.Providers.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // تعریف سند اصلی Swagger
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AngularApp API",
                    Version = "v1",
                    Description = "Professional Swagger configuration for AngularApp",
                    Contact = new OpenApiContact
                    {
                        Name = "Kamran Tajerbashi",
                        Email = "kamran@example.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                // افزودن JWT Bearer Authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI...\""
                });


                // افزودن توضیحات XML (اگر فعال باشد)
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

            return services;
        }

        public static WebApplication UseSwaggerConfiguration(this WebApplication app)
        {
            // فعال‌سازی Swagger Middleware
            app.UseSwagger();

            // فعال‌سازی Swagger UI با گزینه‌های پیشرفته
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AngularApp API V1");

                // اگر چند سرویس داریم
                // c.SwaggerEndpoint("/swagger/serviceA.json", "Service A API");
                // c.SwaggerEndpoint("/swagger/serviceB.json", "Service B API");

                c.EnableDeepLinking();
                c.DisplayOperationId();
                c.DefaultModelsExpandDepth(-1); // مخفی کردن مدل‌ها در پایین صفحه
                c.ShowExtensions();
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            return app;
        }
    }
}
