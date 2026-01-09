using AngularApp.EndPoint.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.EndPoint.WebApi.Controllers.Identity;

public class AccountController : BaseController
{
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
