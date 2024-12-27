using Angular_WebApi;
using Angular_WebApi.ContextDB.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


ApplicationStart.Start(() =>
{
    WebApplication
    .CreateBuilder(args)
    .AddApplicationServices()
    .UseApplicationPipline()
    .Run();
    ;
});



