using AngularApp.EndPoint.WebApi.Configurations.Identity;
using AngularApp.EndPoint.WebApi.Controllers.Common;
using AngularApp.EndPoint.WebApi.Exceptions;
using AngularApp.EndPoint.WebApi.Models;
using AngularApp.EndPoint.WebApi.Providers.Identity.Interfaces;
using AngularApp.EndPoint.WebApi.Providers.UserState;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.EndPoint.WebApi.Controllers.Identity;

public sealed class AuthenticationController : BaseController
{
    private readonly IIdentityService _identityService;
    public AuthenticationController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest parameter)
    {
        try
        {
            var response = await _identityService.LoginAsSessionAsync(parameter.Username, parameter.Password, CancellationToken.None);
            if (response.IsSuccess)
            {
                // 3️⃣ Store data in Session
                HttpContext.Session.SetString(IdentityKeys.UserId, response.User.Id.ToString());
                HttpContext.Session.SetString(IdentityKeys.RoleId, response.Role.Id.ToString());
                HttpContext.Session.SetString(IdentityKeys.UserRoleId, response.UserRole.Id.ToString());
                HttpContext.Session.SetString(IdentityKeys.DisplayName, response.User.DisplayName);
                HttpContext.Session.SetString(IdentityKeys.UserName, response.User.UserName);
                HttpContext.Session.SetString(IdentityKeys.Email, response.User.Email);
                HttpContext.Session.SetString(IdentityKeys.Phone, response.User.PhoneNumber);
                //HttpContext.Session.SetString(IdentityKeys.NationalCode, response.User.);
                //HttpContext.Session.SetString(IdentityKeys.ApplicationState, response.Id.ToString());
                HttpContext.Session.SetString(IdentityKeys.UserRoles, $"{response.UserRoles.Select(x => x.Id).ToArray()}");
                //HttpContext.Session.SetString(IdentityKeys.Groups, response.Id.ToString());
                //HttpContext.Session.SetString(IdentityKeys.State, response.Id.ToString());

                var roles = response.Roles.Select(r => r.Name).ToArray();
                HttpContext.Session.SetString(IdentityKeys.UserRoles, string.Join(",", roles));
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
        catch (Exception ex)
        {
            throw ex.ThrowApiException();
        }
    }
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Ok("Logged out (Session cleared)");
    }

    [HttpGet("me")]
    public IActionResult Me()
    {
        var userId = HttpContext.Session.GetString(IdentityKeys.UserId);

        if (string.IsNullOrEmpty(userId))
            return Unauthorized("Not logged in");

        return Ok(new
        {
            UserId = userId,
            UserName = HttpContext.Session.GetString(IdentityKeys.UserName),
            Roles = HttpContext.Session.GetString(IdentityKeys.UserRoles)?.Split(',')
        });
    }

    [HttpGet("admin-data")]
    public IActionResult AdminOnly()
    {
        var roles = HttpContext.Session
            .GetString(IdentityKeys.UserRoles)?
            .Split(',') ?? Array.Empty<string>();

        if (!roles.Contains("Admin"))
            return Forbid();

        return Ok("Welcome Admin");
    }

}
