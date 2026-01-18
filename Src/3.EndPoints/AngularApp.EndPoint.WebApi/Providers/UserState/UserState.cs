namespace AngularApp.EndPoint.WebApi.Providers.UserState;

public class UserState : IUserState
{
    private readonly IHttpContextAccessor _accessor;
    public UserState(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    public long? UserId => _accessor.HttpContext?.User.GetClaim("UserId").ToLong() ?? default;
    public string LocalIpAddress => _accessor.HttpContext?.Connection.LocalIpAddress?.ToString() ?? "";
    public string LocalPort => _accessor.HttpContext?.Connection.LocalPort.ToString() ?? "";
    public string RemoteIpAddress => _accessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "";
    public string RemotePort => _accessor.HttpContext?.Connection.RemotePort.ToString() ?? "";
    public string UserIp => _accessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "unknown-ip";
    public string UserAgent => _accessor.HttpContext?.Request?.Headers["User-Agent"] ?? "";

    public long? RoleId => _accessor.HttpContext?.User.GetClaim("RoleId").ToLong();

    public long? UserRoleId => _accessor.HttpContext?.User.GetClaim("UserRoleId").ToLong();

    public string DisplayName => _accessor.HttpContext?.User.GetClaim("DisplayName") ?? "";

    public string NationalCode => _accessor.HttpContext?.User.GetClaim("NationalCode") ?? "";

    public string Email => _accessor.HttpContext?.User.GetClaim("Email") ?? "";

    public string Phone => _accessor.HttpContext?.User.GetClaim("Phone") ?? "";

    public string ApplicationState => _accessor.HttpContext?.User.GetClaim("ApplicationState") ?? "AppState";

    public List<long> UserRoles => _accessor.HttpContext?.User.GetClaim("UserRoles")?.Replace("[", "").Replace("]", "").Split(",").Select(item => item.ToLong()).ToList() ?? [];
    public List<long> Groups => _accessor.HttpContext?.User.GetClaim("Groups")?.Replace("[", "").Replace("]", "").Split(",").Select(item => item.ToLong()).ToList() ?? [];

    public string State => _accessor.HttpContext?.User.GetClaim("State") ?? "App";
}
