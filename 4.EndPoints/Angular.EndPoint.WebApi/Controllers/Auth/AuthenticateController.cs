using Angular.ApplicationLibrary.Modules.Identity.Auth.Login;
using Angular.ApplicationLibrary.Modules.Identity.Auth.SignIn;
using Angular.DomainLibrary.Identity;
using Angular.EndPoint.WebApi.Controllers.Bases;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Angular.EndPoint.WebApi.Controllers.Auth;

// Concrete controller with authentication-specific behavior
public class AuthenticateController : BaseApiController
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    public AuthenticateController(
        IMediator mediator,
        UserManager<UserEntity> userManager,
        SignInManager<UserEntity> signInManager)
        : base(mediator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        if (!ModelState.IsValid)
            return Return(ModelState, "Login Fail !!!", ApiResultType.Failed);

        var result = await _signInManager.PasswordSignInAsync(
            command.Username,
            command.Password,
            isPersistent: false,
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Return(result, "Login Successfully Data", ApiResultType.Success);
        }

        return Return(result, "Login Fail !!!", ApiResultType.UnAuthorize);
    }

    [HttpPost("SignIn")]
    public IActionResult SignIn([FromBody] SignInCommand command)
    {
        return Return(true, "SignIn Successfully", ApiResultType.Success);
    }

    [HttpGet("Signout")]
    public async Task<IActionResult> Signout()
    {
        await _signInManager.SignOutAsync();
        return Return(true, "Signout Successfully", ApiResultType.Success);
    }


    [HttpGet("IsAuthenticated")]
    public IActionResult IsAuthenticated()
    {
        if (User.Identity!.IsAuthenticated)
            return Return(User.Identity.IsAuthenticated, "User Is Login", ApiResultType.Success);
        return Return(User.Identity.IsAuthenticated, "User Is Not Login", ApiResultType.Failed);

    }



}
