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



public class ApplicationStart
{
    public static void Start(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
        }
    }
}