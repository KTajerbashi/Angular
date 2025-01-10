using Angular.DomainLibrary.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Angular.InfrastructureLibrary.Providers.Identity;

public class SignInManagerFactory<TUser> : SignInManager<TUser> where TUser : UserEntity
{
    private readonly UserManager<TUser> _userManager;

    public SignInManagerFactory(
        UserManager<TUser> userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<TUser> claimsFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<SignInManager<TUser>> logger,
        IAuthenticationSchemeProvider schemes,
        IUserConfirmation<TUser> confirmation)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {
        _userManager = userManager;
    }


    public override async Task<SignInResult> PasswordSignInAsync(TUser user, string password,
    bool isPersistent, bool lockoutOnFailure)
    {


        var result = await base.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        var loginInfo = new UserLoginEntity
        {
            UserId = user.Id,
            LoginProvider = "UseIdentityManagerProvider",
            ProviderKey = user.Id.ToString(),
            ProviderDisplayName = user.DisplayName
        };
        var existingLogin = await _userManager.GetLoginsAsync(user);
        if (!existingLogin.Any(l => l.LoginProvider == loginInfo.LoginProvider && l.ProviderKey == loginInfo.ProviderKey))
        {
            await _userManager.AddLoginAsync(user, new UserLoginInfo(loginInfo.LoginProvider, loginInfo.ProviderKey, loginInfo.ProviderDisplayName));
        }
        return result;


    }


    public override async Task SignInAsync(TUser user, AuthenticationProperties? properties, string? authenticationMethod = null)
    {
        properties ??= new AuthenticationProperties
        {
            IsPersistent = false,
            AllowRefresh = true,
        };
        await base.SignInAsync(user, properties, authenticationMethod);

        var loginInfo = new UserLoginEntity
        {
            UserId = user.Id,
            LoginProvider = "UseIdentityManagerProvider",
            ProviderKey = user.Id.ToString(),
            ProviderDisplayName = user.DisplayName
        };
        var existingLogin = await _userManager.GetLoginsAsync(user);
        if (!existingLogin.Any(l => l.LoginProvider == loginInfo.LoginProvider && l.ProviderKey == loginInfo.ProviderKey))
        {
            await _userManager.AddLoginAsync(user, new UserLoginInfo(loginInfo.LoginProvider, loginInfo.ProviderKey, loginInfo.ProviderDisplayName));
        }
    }
}



