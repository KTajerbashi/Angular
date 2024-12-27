namespace Angular_WebApi.ApplicationBases.Repositories;

public interface IUser
{
    long? Id { get; }
    long? UserId { get; }
    long? RoleId { get; }
    long? UserRoleId { get; }
    string Username { get; }
    string FirstName { get; }
    string GetUserAgent();
    string GetUserIp();
}
