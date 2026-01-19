namespace AngularApp.Core.Domain.Exceptions;

public class DomainException : BaseException
{
    public DomainException(string message) : base(message)
    {
    }

    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
