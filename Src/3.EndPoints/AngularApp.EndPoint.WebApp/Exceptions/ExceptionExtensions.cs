namespace AngularApp.EndPoint.WebApp.Exceptions;

public static class ExceptionExtensions
{
    public static WebAppException ThrowWebAppException(this Exception exception) => new WebAppException(exception.Message);
    public static WebAppException ThrowWebAppException(this Exception exception, string message) => new WebAppException(message, exception);
}
