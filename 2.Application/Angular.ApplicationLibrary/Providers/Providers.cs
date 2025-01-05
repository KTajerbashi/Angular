using Angular.ApplicationLibrary.Providers.Caching;
using Angular.ApplicationLibrary.Providers.Serializers;
using Angular.ApplicationLibrary.Providers.UsersManagement;
using Microsoft.Extensions.Logging;

namespace Angular.ApplicationLibrary.Providers;

public class ProviderServices
{
    public readonly ILoggerFactory LoggerFactory;
    public readonly ICacheAdapter CacheAdapter;
    public readonly IJsonSerializer JsonSerializer;
    public readonly IUserInfoService UserInfoService;

    public ProviderServices(ILoggerFactory loggerFactory, ICacheAdapter cacheAdapter, IJsonSerializer jsonSerializer, IUserInfoService userInfoService)
    {
        LoggerFactory = loggerFactory;
        CacheAdapter = cacheAdapter;
        JsonSerializer = jsonSerializer;
        UserInfoService = userInfoService;
    }
}
