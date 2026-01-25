using AngularApp.Core.Domain.Exceptions;

namespace AngularApp.Infra.Data.Exceptions;

public class DataException : BaseException
{
    public DataException(string message) : base(message)
    {
    }

    public DataException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
