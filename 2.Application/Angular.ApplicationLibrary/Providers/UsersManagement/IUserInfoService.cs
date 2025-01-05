namespace Angular.ApplicationLibrary.Providers.UsersManagement;

public interface IUserInfoService
{
    string GetUserAgent();
    string GetUserIp();
    string UserId();
    string GetUsername();
    string GetFirstName();
    string GetLastName();
    bool IsCurrentUser(string userId);
    string? GetClaim(string claimType);
    string UserIdOrDefault();
    string UserIdOrDefault(string defaultValue);
}
