StartApp.Run(() =>
{
    Console.WriteLine($"Angular.EndPoint.WebApi Run ...{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
});
public class StartApp
{
    public static void Run(Action action)
    {
        try
        {
            action();
        }
        catch 
        {

            throw;
        }
    }
}

