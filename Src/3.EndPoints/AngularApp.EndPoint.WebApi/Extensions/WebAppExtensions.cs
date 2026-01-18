using AngularApp.Core.Application.Providers;

namespace AngularApp.EndPoint.WebApi.Extensions;

public static class WebAppExtensions
{
    public static ProviderServices GetProviderServices(this HttpContext context)
    {
        return (ProviderServices)context?.RequestServices.GetService(typeof(ProviderServices));
    }

}
