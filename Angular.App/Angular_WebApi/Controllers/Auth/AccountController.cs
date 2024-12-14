using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.Controllers.BaseControllers;
using Angular_WebApi.Exceptions;
using Angular_WebApi.Middlewares.ExceptionHandler.Exceptions;
using Angular_WebApi.Models.Auth;
using Angular_WebApi.Utilities.Extensions;
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
            var userEntity = await _userManager.FindByNameAsync(model.Username);
            if (userEntity is null)
                throw new IdentityLogicException("User Not Found");

            var result = await _signInManager.PasswordSignInAsync(model.Username,model.Password,true,false);
            return Ok(new
            {
                token = userEntity,
                expireDate = DateTime.Now.AddMinutes(100),
                isLoggedIn = true
            });
        }
        return Ok();
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Signin(SigninDTO model)
    {
        var userEntity = new UserEntity()
        {
            Name = model.Name,
            Family = model.Family,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            UserName = model.Username,
        };
        var result = await _userManager.CreateAsync(userEntity,model.Password);
        if (!result.Succeeded)
        {
            throw new IdentityLogicException(result.GetIdentityErrors());
        }
        return Ok(result);
    }


}
