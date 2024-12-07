namespace Angular_WebApi.Middlewares.ExceptionHandler.Exceptions;

public class AppException : Exception
{
    public AppException(string message):base($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} : {message}")
    {
    }
}
