using Microsoft.AspNetCore.Identity;

namespace Angular_WebApi.Exceptions;

public class IdentityLogicException : Exception
{
    public IdentityLogicException(string message) : base(message)
    {
    }
}
