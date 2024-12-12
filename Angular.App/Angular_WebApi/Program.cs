using Angular_WebApi.ApplicationStarter;
using Angular_WebApi.ApplicationStarter.Extensions;


ApplicationStart.Start(() =>
{
    WebApplication
    .CreateBuilder(args)
    .AddApplicationServices()
    .UseApplicationPipline()
    .Run();
    ;
});



