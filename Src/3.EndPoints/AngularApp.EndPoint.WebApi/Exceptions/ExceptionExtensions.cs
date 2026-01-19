namespace AngularApp.EndPoint.WebApi.Exceptions;

public static class ExceptionExtensions
{
    public static ApiException ThrowApiException(this Exception exception) => new ApiException(exception.Message);
    public static ApiException ThrowApiException(this Exception exception, string message) => new ApiException(message, exception);
}
