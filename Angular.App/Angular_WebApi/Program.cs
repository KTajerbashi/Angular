using Angular_WebApi;


ApplicationStart.Start(() =>
{
    WebApplication
    .CreateBuilder(args)
    .AddApplicationServices()
    .UseApplicationPipline()
    .Run();
    ;
});



