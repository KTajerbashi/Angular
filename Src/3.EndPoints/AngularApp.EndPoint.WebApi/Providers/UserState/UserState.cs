using AngularApp.Core.Application.Providers.UserState;

namespace AngularApp.EndPoint.WebApi.Providers.UserState;

public class UserState : IUserState
{
    public long? UserId => 1;
}
