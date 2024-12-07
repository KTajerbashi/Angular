using Angular_WebApi.ApplicationStarter;
using Angular_WebApi.ApplicationStarter.Extensions;


ApplicationStart.Start(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    builder
    .AddApplicationServices()
    .UseApplicationPipline()
    .Run();
    ;
});



