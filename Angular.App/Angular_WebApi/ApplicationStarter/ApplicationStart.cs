namespace Angular_WebApi.ApplicationStarter;

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
