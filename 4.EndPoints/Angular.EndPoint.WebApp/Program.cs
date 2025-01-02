using Angular.EndPoint.WebApi;

StartApp.Run(() =>
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"Start: Angular.EndPoint.WebApp Run ...\nTime: {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
    var builder = WebApplication
        .CreateBuilder(args)
        .AddWebAppService()
        .AddWebApiService();

    builder .Build()
            .UseWebAppPipeline()
            .UseWebApiPipeline()
            .Run();
});






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