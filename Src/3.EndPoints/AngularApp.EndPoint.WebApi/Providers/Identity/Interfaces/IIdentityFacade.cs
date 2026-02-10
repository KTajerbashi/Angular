using AngularApp.Core.Application.Providers.ScrutorDI;
using AngularApp.Core.Application.UseCases.Security.Roles.Repository;
using AngularApp.Core.Application.UseCases.Security.Users.Repository;
using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using Microsoft.AspNetCore.Identity;

namespace AngularApp.EndPoint.WebApi.Providers.Identity.Interfaces;

public interface IIdentityFacade : IScopeLifeTime
{
    UserManager<UserEntity> UserManager { get; }
    SignInManager<UserEntity> SignInManager { get; }
    RoleManager<RoleEntity> RoleManager { get; }
    ITokenService TokenService { get; }
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }

}
