namespace Angular_WebApi;

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
