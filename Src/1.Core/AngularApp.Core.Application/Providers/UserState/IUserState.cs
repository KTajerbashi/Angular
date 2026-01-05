using AngularApp.Core.Application.Providers.ScrutorDI;

namespace AngularApp.Core.Application.Providers.UserState;

public interface IUserState: IScopeLifeTime
{
    long? UserId { get; }
}
