using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.EndPoint.WebApi.Providers.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AngularApp.EndPoint.WebApi.Providers.Identity.Services;

public class IdentityFacade : IIdentityFacade
{
    public UserManager<UserEntity> UserManager => _userManager;
    public SignInManager<UserEntity> SignInManager => _signInManager;
    public RoleManager<RoleEntity> RoleManager => _roleManager;
    public ITokenService TokenService => _tokenService;

    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly RoleManager<RoleEntity> _roleManager;
    private readonly ITokenService _tokenService;

    public IdentityFacade(
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager,
        RoleManager<RoleEntity> roleManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
    }

}