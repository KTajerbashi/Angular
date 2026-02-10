using AngularApp.Core.Application.UseCases.Security.Roles.Repository;
using AngularApp.Core.Application.UseCases.Security.Users.Repository;
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
    public IUserRepository UserRepository => _userRepository;
    public IRoleRepository RoleRepository => _roleRepository;

    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly RoleManager<RoleEntity> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public IdentityFacade(
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager,
        RoleManager<RoleEntity> roleManager,
        ITokenService tokenService,
        IUserRepository userRepository,
        IRoleRepository roleRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

}