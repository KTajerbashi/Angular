using AngularApp.Core.Domain.Exceptions;

namespace AngularApp.EndPoint.WebApi.Exceptions;

public class WebAppException : BaseException
{
    public WebAppException(string message) : base(message)
    {
    }

    public WebAppException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
