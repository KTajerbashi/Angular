using AngularApp.Core.Application.Providers.ScrutorDI;
using AngularApp.Core.Domain.Entities.Security;
using AngularApp.EndPoint.WebApi.Exceptions;
using AngularApp.EndPoint.WebApi.Models;

namespace AngularApp.EndPoint.WebApi.Providers.Identity;

public interface IIdentityService : IScopeLifeTime
{
    Task<IdentityResponse> LoginByUsernameAsync(string username, string password, CancellationToken cancellation);
    Task<IdentityResponse> LoginByEmailAsync(string email, string password, CancellationToken cancellation);
    Task<IdentityResponse> LoginAsync(UserEntity user, CancellationToken cancellation);

    Task<IdentityResponse> LogoutAsync(CancellationToken cancellation);


    Task<IdentityResponse> AddUserClaimsAsync(UserEntity user, CancellationToken cancellation);
    Task<IdentityResponse> RemoveUserClaimsAsync(UserEntity user, CancellationToken cancellation);

    Task<IdentityResponse> AddUserTokenAsync(UserEntity user, CancellationToken cancellation);
    Task<IdentityResponse> RemoveUserTokenAsync(UserEntity user, CancellationToken cancellation);

    Task<IdentityResponse> AddUserLoginAsync(UserEntity user, CancellationToken cancellation);
    Task<IdentityResponse> RemoveUserLoginAsync(UserEntity user, CancellationToken cancellation);

    Task<IdentityResponse> AddRoleClaimAsync(RoleEntity role, CancellationToken cancellation);
    Task<IdentityResponse> RemoveRoleClaimAsync(UserEntity user, CancellationToken cancellation);

    Task<IdentityResponse> AddRoleToUserAsync(UserEntity user, string roleName, CancellationToken cancellation);

}

public class IdentityService : IIdentityService
{
    private readonly IIdentityFacade _identityFacade;

    public IdentityService(IIdentityFacade identityFacade)
    {
        _identityFacade = identityFacade;
    }

    public async Task<IdentityResponse> AddRoleClaimAsync(RoleEntity role, CancellationToken cancellation)
    {
        try
        {
            var result = await _identityFacade.RoleManager.AddClaimAsync(role, new("", ""));
            return new()
            {
                IsSuccess = result.Succeeded,
                Message = result.
            };
        }
        catch (Exception ex)
        {

            throw ex.ThrowApiException();
        }
    }

    public Task<IdentityResponse> AddRoleToUserAsync(UserEntity user, string roleName, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> AddUserClaimsAsync(UserEntity user, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> AddUserLoginAsync(UserEntity user, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> AddUserTokenAsync(UserEntity user, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> LoginAsync(UserEntity user, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> LoginByEmailAsync(string email, string password, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> LoginByUsernameAsync(string username, string password, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> LogoutAsync(CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> RemoveRoleClaimAsync(UserEntity user, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> RemoveUserClaimsAsync(UserEntity user, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> RemoveUserLoginAsync(UserEntity user, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResponse> RemoveUserTokenAsync(UserEntity user, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}