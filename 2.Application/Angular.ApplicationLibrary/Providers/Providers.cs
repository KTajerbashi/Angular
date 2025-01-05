using Microsoft.Extensions.Logging;

namespace Angular.ApplicationLibrary.Providers;

public class ProviderServices
{
    ILoggerFactory _loggerFactory;
    public ProviderServices(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }
}
