using AngularApp.Core.Application.Providers.ScrutorDI;
using AngularApp.Core.Domain.Entities.Security;
using AngularApp.EndPoint.WebApi.Models;

namespace AngularApp.EndPoint.WebApi.Providers.Identity;

public interface IIdentityService : IScopeLifeTime
{
    //  Login
    Task<IdentityResponse> LoginByUsernameAsync(string username, string password, CancellationToken cancellation);
    Task<IdentityResponse> LoginByEmailAsync(string email, string password, CancellationToken cancellation);
    Task<IdentityResponse> LoginAsync(UserEntity user, CancellationToken cancellation);
}

public class IdentityService : IIdentityService
{
    private readonly IIdentityFacade _identityFacade;

    public IdentityService(IIdentityFacade identityFacade)
    {
        _identityFacade = identityFacade;
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
}