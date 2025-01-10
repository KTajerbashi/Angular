using Angular.ApplicationLibrary.Modules.Identity.Users.Repository;
using Angular.ApplicationLibrary.Providers.UsersManagement;
using Angular.ApplicationLibrary.Utilities.Extensions;
using Angular.DomainLibrary.Identity;
using Angular.InfrastructureLibrary.Database.Contants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Angular.InfrastructureLibrary.Providers.Identity;

public class IdentityClaimFactory : UserClaimsPrincipalFactory<UserEntity, RoleEntity>
{
    private readonly IUserInfoService _userInfoService;
    private readonly IUserRepository _userRepository;
    public IdentityClaimFactory(
        UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager,
        IOptions<IdentityOptions> options,
        IUserInfoService userInfoService,
        IUserRepository userRepository)
        : base(userManager, roleManager, options)
    {
        _userInfoService = userInfoService;
        _userRepository = userRepository;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
    {

        List<RoleEntity> _roles = new List<RoleEntity>();
        var userInfo = await _userRepository.GetAsync(user.Id, default);
        var userRoles = await _userRepository.GetUserRolesAsync(user.Id);
        foreach (var item in userRoles)
        {
            var role = await _userRepository.GetRoleInfoAsync(item.RoleId);
            _roles.Add(role);
        }
        var defaultRole = _roles.Where(r => userRoles.Any(ur => ur.RoleId == r.Id && ur.IsActive)).SingleOrDefault();

        var isAdmin = _roles.Where(item => item.Name.IsAdminByName(Roles.Administrator)).SingleOrDefault().IsNullObject();
        //user = await _userRepository.GetAsync(user.Id, default);
        var identity = await base.GenerateClaimsAsync(user);

        identity.AddClaim(new Claim("UserId", user.Id.ToString()));
        identity.AddClaim(new Claim("FirstName", user.FirstName ?? ""));
        identity.AddClaim(new Claim("LastName", user.LastName ?? ""));
        identity.AddClaim(new Claim("FullName", $"{user.FirstName} {user.LastName}"));
        identity.AddClaim(new Claim("DisplayName", user.DisplayName ?? ""));
        identity.AddClaim(new Claim("Email", user.Email ?? ""));
        identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""));
        identity.AddClaim(new Claim("UserRoleId", defaultRole == null ? "0" : defaultRole.Id.ToString()));
        identity.AddClaim(new Claim("RoleId", defaultRole!.Id.ToString()));
        identity.AddClaim(new Claim("IsAdmin", $"{isAdmin}"));

        var roles = await UserManager.GetRolesAsync(user);
        identity.AddClaim(new Claim("Roles", string.Join(',', roles)));
        return identity;



    }

}