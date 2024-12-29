using Angular_WebApi.ApplicationBases.Repositories;
using System.Security.Claims;

namespace Angular_WebApi.Providers.Identity.Services;

public class CurrentUserInfo : IUser
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUserInfo(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    private ClaimsPrincipal CurrentUser => _contextAccessor.HttpContext?.User!;

    public long? Id => GetClaimValue<long?>("UserId") ?? 0;

    public long? UserId => GetClaimValue<long?>("UserId") ?? 0;

    public long? RoleId => GetClaimValue<long?>("RoleId") ?? 0;

    public long? UserRoleId => GetClaimValue<long?>("UserRoleId") ?? 0;

    public string Username => GetClaimValue<string>("Username") ?? "not login";

    public string FirstName => GetClaimValue<string>("FirstName") ?? "not login";

    public string GetUserAgent()
    {
        return _contextAccessor.HttpContext?.Request.Headers["User-Agent"]!;
    }

    public string GetUserIp()
    {
        return _contextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString()!;
    }

    private T GetClaimValue<T>(string claimType)
    {
        var claim = CurrentUser?.Claims.FirstOrDefault(c => c.Type == claimType);
        if (claim == null)
            return default;

        if (typeof(T) == typeof(long?))
        {
            if (long.TryParse(claim.Value, out long longValue))
                return (T)(object)longValue;
            return default;
        }

        if (typeof(T) == typeof(string))
        {
            return (T)(object)claim.Value;
        }

        return default;
    }
}
