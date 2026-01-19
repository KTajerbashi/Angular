namespace AngularApp.Core.Application.Exceptions;

public static class ExceptionExtensions
{
    public static AppException ThrowAppException(this Exception exception) => new AppException(exception.Message);
    public static AppException ThrowAppException(this Exception exception, string message) => new AppException(message, exception);
}
