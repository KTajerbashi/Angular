using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.EndPoint.WebApi.Exceptions;
using AngularApp.EndPoint.WebApi.Models;
using AngularApp.EndPoint.WebApi.Providers.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AngularApp.EndPoint.WebApi.Providers.Identity.Services;

public sealed class IdentityService : IIdentityService
{
    private readonly IIdentityFacade _identityFacade;

    public IdentityService(IIdentityFacade identityFacade)
    {
        _identityFacade = identityFacade;
    }

    // --------------------------------------------------
    // LOGIN
    // --------------------------------------------------

    public async Task<IdentityResponse> LoginByUsernameAsync(
        string username,
        string password,
        CancellationToken cancellation)
    {
        try
        {
            var user = await _identityFacade.UserManager
                .FindByNameAsync(username);

            if (user is null)
                return Fail("User not found");

            return await LoginAsync(user, password, cancellation);
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }

    public async Task<IdentityResponse> LoginByEmailAsync(
        string email,
        string password,
        CancellationToken cancellation)
    {
        try
        {
            var user = await _identityFacade.UserManager
                .FindByEmailAsync(email);

            if (user is null)
                return Fail("User not found");

            return await LoginAsync(user, password, cancellation);
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }

    public async Task<IdentityResponse> LoginAsync(
        UserEntity user,
        CancellationToken cancellation)
        => Fail("Password is required");

    private async Task<IdentityResponse> LoginAsync(
        UserEntity user,
        string password,
        CancellationToken cancellation)
    {
        var result = await _identityFacade.SignInManager
            .CheckPasswordSignInAsync(user, password, false);

        if (!result.Succeeded)
            return Fail("Invalid credentials");

        await _identityFacade.SignInManager.SignInAsync(user, false);

        return Success("Login successful");
    }

    public async Task<IdentityResponse> LogoutAsync(CancellationToken cancellation)
    {
        try
        {
            await _identityFacade.SignInManager.SignOutAsync();
            return Success("Logout successful");
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }

    // --------------------------------------------------
    // USER CLAIMS
    // --------------------------------------------------

    public async Task<IdentityResponse> AddUserClaimsAsync(
        UserEntity user,
        CancellationToken cancellation)
    {
        try
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.EntityId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!)
            };

            var result = await _identityFacade.UserManager
                .AddClaimsAsync(user, claims);

            return result.Succeeded
                ? Success("User claims added")
                : Fail(result.Errors);
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }

    public async Task<IdentityResponse> RemoveUserClaimsAsync(
        UserEntity user,
        CancellationToken cancellation)
    {
        try
        {
            var claims = await _identityFacade.UserManager.GetClaimsAsync(user);
            var result = await _identityFacade.UserManager
                .RemoveClaimsAsync(user, claims);

            return result.Succeeded
                ? Success("User claims removed")
                : Fail(result.Errors);
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }

    // --------------------------------------------------
    // USER LOGINS (External Providers)
    // --------------------------------------------------

    public async Task<IdentityResponse> AddUserLoginAsync(
        UserEntity user,
        CancellationToken cancellation)
    {
        return Fail("External logins must be added via provider callback");
    }

    public async Task<IdentityResponse> RemoveUserLoginAsync(
        UserEntity user,
        CancellationToken cancellation)
    {
        try
        {
            var logins = await _identityFacade.UserManager.GetLoginsAsync(user);
            foreach (var login in logins)
            {
                await _identityFacade.UserManager
                    .RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
            }

            return Success("User logins removed");
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }

    // --------------------------------------------------
    // USER TOKENS
    // --------------------------------------------------

    public async Task<IdentityResponse> AddUserTokenAsync(
        UserEntity user,
        CancellationToken cancellation)
    {
        await _identityFacade.UserManager.SetAuthenticationTokenAsync(
            user, "App", "RefreshToken", Guid.NewGuid().ToString());

        return Success("User token added");
    }

    public async Task<IdentityResponse> RemoveUserTokenAsync(
        UserEntity user,
        CancellationToken cancellation)
    {
        await _identityFacade.UserManager.RemoveAuthenticationTokenAsync(
            user, "App", "RefreshToken");

        return Success("User token removed");
    }

    // --------------------------------------------------
    // ROLES
    // --------------------------------------------------

    public async Task<IdentityResponse> AddRoleToUserAsync(
        UserEntity user,
        string roleName,
        CancellationToken cancellation)
    {
        try
        {
            if (!await _identityFacade.RoleManager.RoleExistsAsync(roleName))
                return Fail("Role does not exist");

            var result = await _identityFacade.UserManager
                .AddToRoleAsync(user, roleName);

            return result.Succeeded
                ? Success("Role assigned to user")
                : Fail(result.Errors);
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }

    public async Task<IdentityResponse> AddRoleClaimAsync(
        RoleEntity role,
        CancellationToken cancellation)
    {
        try
        {
            var result = await _identityFacade.RoleManager
                .AddClaimAsync(role, new Claim("role", role.Name!));

            return result.Succeeded
                ? Success("Role claim added")
                : Fail(result.Errors);
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }

    public async Task<IdentityResponse> RemoveRoleClaimAsync(
        UserEntity user,
        CancellationToken cancellation)
    {
        return Fail("Remove role claims via RoleManager");
    }

    // --------------------------------------------------
    // HELPERS
    // --------------------------------------------------

    private static IdentityResponse Success(string message)
        => new()
        {
            IsSuccess = true,
            Message = message
        };

    private static IdentityResponse Fail(string message)
        => new()
        {
            IsSuccess = false,
            Message = message,
            ErrorMessages = new() { message }
        };

    private static IdentityResponse Fail(IEnumerable<IdentityError> errors)
        => new()
        {
            IsSuccess = false,
            ErrorMessages = errors.Select(e => e.Description).ToList()
        };
}
