namespace AngularApp.Infra.Data.Exceptionsp;

public static class ExceptionExtensions
{
    public static DataException ThrowDataException(this Exception exception) => new DataException(exception.Message);
    public static DataException ThrowDataException(this Exception exception, string message) => new DataException(message, exception);
}
