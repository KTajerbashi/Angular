namespace Angular.ApplicationLibrary.BaseApplication.Interfaces;

public interface IUserInfoService
{
    string UserIp { get; }
    string UserAgent { get; }
    int UserId { get; }
}