namespace AngularApp.Core.Domain.Exceptions;

public abstract class BaseException : Exception
{
    protected BaseException(string msg) : base(msg) { }
    protected BaseException(string msg, Exception exception) : base(msg, exception) { }
    protected BaseException(Exception exception) : base($"{exception.Message} - {exception.InnerException?.Message}") { }
}
