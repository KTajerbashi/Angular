using AngularApp.Core.Application.Providers.UserState;

namespace AngularApp.Core.Application.Providers;

public class ProviderServices 
{
    public IUserState UserState;
    public ProviderServices(IUserState userState)
    {
        UserState = userState;
    }
}
