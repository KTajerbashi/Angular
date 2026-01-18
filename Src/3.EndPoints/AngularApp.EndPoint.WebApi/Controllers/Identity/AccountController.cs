using AngularApp.EndPoint.WebApi.Models;
using AngularApp.EndPoint.WebApi.Providers.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.EndPoint.WebApi.Controllers.Identity;

public class AccountController : BaseController
{
    private readonly IIdentityFacade _identityFacade;

    public AccountController(IIdentityFacade identityFacade)
    {
        _identityFacade = identityFacade;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest parameters)
    {
        return Ok(new
        {
            Success = true,
            Data = parameters,
            Message = "با موفقیت انجام شده است ..."
        });
    }
    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpRequest parameters)
    {
        return Ok(new
        {
            Success = true,
            Data = parameters,
            Message = "با موفقیت انجام شده است ..."
        });
    }

    [HttpGet("Signout")]
    public async Task<IActionResult> Signout()
    {
        return Ok(new
        {
            Success = true,
            Data = true,
            Message = "با موفقیت انجام شده است ..."
        });
    }
}
