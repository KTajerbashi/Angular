using AngularApp.Core.Application.Providers.ScrutorDI;
using AngularApp.Core.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;

namespace AngularApp.EndPoint.WebApi.Providers.Identity;

public interface IIdentityFacade : IScopeLifeTime
{
    UserManager<UserEntity> UserManager { get; }
    SignInManager<UserEntity> SignInManager { get; }
    RoleManager<RoleEntity> RoleManager { get; }
    ITokenService TokenService { get; }

}
