namespace AngularApp.Core.Application.Providers.UserState;
public interface IUserState : IScopeLifeTime
{
    long? UserId { get; }
    long? RoleId { get; }
    long? UserRoleId { get; }
    string DisplayName { get; }
    string NationalCode { get; }
    string Email { get; }
    string Phone { get; }
    string State { get; }
    string ApplicationState { get; }
    
    List<long> UserRoles { get; }
    List<long> Groups { get; }

    string LocalIpAddress { get; }
    string LocalPort { get; }
    string RemoteIpAddress { get; }
    string RemotePort { get; }
    string UserIp { get; }
    string UserAgent { get; }
}
