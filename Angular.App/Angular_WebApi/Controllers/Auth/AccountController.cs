using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.Controllers.BaseControllers;
using Angular_WebApi.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.Controllers.Auth;

public class AccountController : AuthController
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    public AccountController(
        IMediator mediator,
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager) : base(mediator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO model)
    {
        if (ModelState.IsValid)
        {

        }
        return Ok();
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Signin(SigninDTO model)
    {
        return Ok();
    }


}
