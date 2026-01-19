using AngularApp.Core.Domain.Exceptions;

namespace AngularApp.Core.Application.Exceptions;

public class AppException : BaseException
{
    public AppException(string message) : base(message)
    {
    }

    public AppException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
