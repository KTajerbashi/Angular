using AngularApp.EndPoint.WebApi.Configurations.Identity;

namespace AngularApp.EndPoint.WebApi.Providers.UserState;

public static class IdentityKeys
{
    public const string UserId = "UserId";
    public const string RoleId = "RoleId";
    public const string UserRoleId = "UserRoleId";
    public const string DisplayName = "DisplayName";
    public const string UserName = "UserName";
    public const string Email = "Email";
    public const string Phone = "Phone";
    public const string NationalCode = "NationalCode";
    public const string ApplicationState = "ApplicationState";
    public const string UserRoles = "UserRoles";
    public const string Groups = "Groups";
    public const string State = "State";
}

public sealed class UserState : IUserState
{
    private readonly IHttpContextAccessor _accessor;
    private const IdentityType Type = IdentityType.SessionBase;

    private HttpContext? Context => _accessor.HttpContext;

    public UserState(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public long? UserId => GetLong(IdentityKeys.UserId);
    public long? RoleId => GetLong(IdentityKeys.RoleId);
    public long? UserRoleId => GetLong(IdentityKeys.UserRoleId);

    public string DisplayName => GetString(IdentityKeys.DisplayName);
    public string UserName => GetString(IdentityKeys.UserName);
    public string Email => GetString(IdentityKeys.Email);
    public string Phone => GetString(IdentityKeys.Phone);
    public string NationalCode => GetString(IdentityKeys.NationalCode);
    public string ApplicationState => GetString(IdentityKeys.ApplicationState, "AppState");
    public string State => GetString(IdentityKeys.State, "App");

    public List<long> UserRoles => GetLongList(IdentityKeys.UserRoles);
    public List<long> Groups => GetLongList(IdentityKeys.Groups);

    public string UserAgent => Context?.Request.Headers["User-Agent"].ToString() ?? "";

    public string UserIp =>
        Context?.Connection.RemoteIpAddress?.ToString() ?? "unknown-ip";

    public string LocalIpAddress =>
        Context?.Connection.LocalIpAddress?.ToString() ?? "";

    public string LocalPort =>
        Context?.Connection.LocalPort.ToString() ?? "";

    public string RemoteIpAddress =>
        Context?.Connection.RemoteIpAddress?.ToString() ?? "";

    public string RemotePort =>
        Context?.Connection.RemotePort.ToString() ?? "";

    // ================= helpers =================

    private string GetString(string key, string defaultValue = "")
    {
        return Type switch
        {
            IdentityType.CookieBase or IdentityType.TokenBase
                => Context?.User.GetClaim(key) ?? defaultValue,

            IdentityType.SessionBase
                => Context?.Session.GetString(key) ?? defaultValue,

            _ => defaultValue
        };
    }

    private long? GetLong(string key)
    {
        var value = GetString(key);
        return long.TryParse(value, out var result) ? result : null;
    }

    private List<long> GetLongList(string key)
    {
        var value = GetString(key);
        if (string.IsNullOrWhiteSpace(value))
            return [];

        return value
            .Trim('[', ']')
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(v => long.TryParse(v.Trim(), out var r) ? r : (long?)null)
            .Where(v => v.HasValue)
            .Select(v => v!.Value)
            .ToList();
    }
}
