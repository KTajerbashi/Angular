
await StartApp.Run(async () =>
{
    await Task.CompletedTask;
    Console.WriteLine($"Angular.EndPoint.WebApi Run ...{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
});


public class StartApp
{
    public static async Task Run(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch
        {
            throw;
        }
    }
}

