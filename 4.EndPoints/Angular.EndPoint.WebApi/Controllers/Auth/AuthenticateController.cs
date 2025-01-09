using Angular.ApplicationLibrary.Modules.Identity.Auth.Login;
using Angular.ApplicationLibrary.Modules.Identity.Auth.SignIn;
using Angular.ApplicationLibrary.Providers;
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
            return BadRequest(ModelState);

        var result = await _signInManager.PasswordSignInAsync(
            command.Username,
            command.Password,
            isPersistent: false,
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Ok(new { Message = "Login successful!" });
        }

        return Unauthorized(new { Message = "Invalid credentials." });
    }

    [HttpPost("SignIn")]
    public IActionResult SignIn([FromBody] SignInCommand command)
    {
        return Return("SignIn");
    }

    

}
