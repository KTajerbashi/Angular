namespace AngularApp.Core.Domain.Exceptions;

public static class ExceptionExtensions
{
    public static DomainException ThrowDomainException(this Exception exception) => new DomainException(exception.Message);
    public static DomainException ThrowDomainException(this Exception exception, string message) => new DomainException(message, exception);
}