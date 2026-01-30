using AngularApp.Core.Application.Providers;
using AngularApp.EndPoint.WebApi.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Security.Claims;

namespace AngularApp.EndPoint.WebApi.Extensions;
public static class WebAppExtensions
{
    public static ProviderServices GetProviderServices(this HttpContext context)
    {
        return (ProviderServices)context?.RequestServices.GetService(typeof(ProviderServices));
    }
    public static string GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)
    {
        return userClaimsPrincipal.Claims?.FirstOrDefault((Claim x) => x.Type == claimType)?.Value;
    }
    public static string GetSession(this HttpContext context,string sessionKey)
    {
        return context.Session.GetString(sessionKey);
    }
    public static string GetClaim(this HttpContext context, string claimType)
    {
        return context.User.GetClaim(claimType);
    }
    public static IServiceCollection AddNonValidatingValidator(this IServiceCollection services)
    {
        var validator = services.FirstOrDefault(s => s.ServiceType == typeof(IObjectModelValidator));
        if (validator != null)
        {
            services.Remove(validator);
            services.Add(new ServiceDescriptor(typeof(IObjectModelValidator), _ => new NonValidatingValidator(), ServiceLifetime.Singleton));
        }
        return services;
    }
}
