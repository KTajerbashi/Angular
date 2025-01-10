using Angular.ApplicationLibrary.Models;
using Angular.ApplicationLibrary.Modules.Identity.Interfaces;
using Angular.DomainLibrary.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Angular.InfrastructureLibrary.Providers.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IUserClaimsPrincipalFactory<UserEntity> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<UserEntity> userManager,
        IUserClaimsPrincipalFactory<UserEntity> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<string?> GetUserNameAsync(long userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        return user?.UserName;
    }

    public async Task<(Result Result, long UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new UserEntity
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }


    public async Task<bool> IsInRoleAsync(long userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(long userId, string policyName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(long userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(UserEntity user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

}



public class UserManagerFactory<Tuser> : UserManager<Tuser> where Tuser : UserEntity
{
    public UserManagerFactory(
        IUserStore<Tuser> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<Tuser> passwordHasher,
        IEnumerable<IUserValidator<Tuser>> userValidators,
        IEnumerable<IPasswordValidator<Tuser>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errorDescriber,
        IServiceProvider services,
        ILogger<UserManager<Tuser>> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errorDescriber, services, logger)
    { }

    public override async Task<IList<string>> GetRolesAsync(Tuser user)
    {
        var roles = await base.GetRolesAsync(user);

        //نقش هاش رو بگیر و آرایه ای بفرست

        return roles.ToArray();
    }

}




