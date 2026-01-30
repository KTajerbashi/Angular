using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.EndPoint.WebApi.Controllers.Common;
using AngularApp.EndPoint.WebApi.Models;
using AngularApp.EndPoint.WebApi.Providers.Identity.Interfaces;
using AngularApp.Infra.Data.References;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AngularApp.EndPoint.WebApi.Controllers.Identity;
//public sealed class AccountController : BaseController
//{
//    private readonly IIdentityService _identityService;
//    public AccountController(IIdentityService identityService)
//    {
//        _identityService = identityService;
//    }

//    // --------------------------------------------------
//    // LOGIN (JWT + COOKIE)
//    // --------------------------------------------------
//    [HttpPost("Login")]
//    public async Task<IActionResult> Login([FromBody] LoginRequest parameters, CancellationToken cancellation)
//    {
//        // 1️⃣ Identity login (cookie/session)
//        IdentityResponse loginResult =
//            await _identityService.LoginByUsernameAsync(
//                    parameters.Username!, parameters.Password!, cancellation)
//            ??
//            await _identityService.LoginByEmailAsync(
//                    parameters.Username!, parameters.Password!, cancellation)
//            ;
//        if (!loginResult.IsSuccess)
//            return BadRequest(loginResult);

//        var loginResult = await _identityService.LoginAsync 

//        //var userEntity =
//        //    await _identityFacade.UserManager.FindByEmailAsync(parameters.Username) ??
//        //    await _identityFacade.UserManager.FindByNameAsync(parameters.Username);
//        //if (userEntity is null)
//        //{
//        //    return BadRequest();
//        //}


//        //// 2️⃣ Generate JWT for client
//        //var tokenResponse = await _tokenService.GenerateTokenAsync(
//        //    new TokenRequest
//        //    {
//        //        User = userEntity,
//        //        Role = new RoleEntity(RolesReference.Admin),
//        //        UserRole = UserRoleEntity.CreateInstance(1, 1, 1),
//        //        TokenType = TokenType.JWE
//        //    },
//        //    cancellation);

//        return Ok(new
//        {
//            Success = true,
//            Data = tokenResponse,
//            Message = "ورود با موفقیت انجام شد"
//        });
//    }

//    // --------------------------------------------------
//    // SIGN UP
//    // --------------------------------------------------
//    [HttpPost("SignUp")]
//    public async Task<IActionResult> SignUp([FromBody] SignUpRequest parameters, CancellationToken cancellation)
//    {
//        var user = new UserEntity(new()
//        {
//            UserName = parameters.Username,
//            Email = parameters.Email
//        });

//        var result = await _identityFacade.UserManager.CreateAsync(user, parameters.Password);

//        if (!result.Succeeded)
//            return BadRequest(new
//            {
//                Success = false,
//                Errors = result.Errors.Select(e => e.Description)
//            });

//        // Default role
//        await _identityService.AddRoleToUserAsync(
//            user, "User", cancellation);

//        return Ok(new
//        {
//            Success = true,
//            Message = "ثبت نام با موفقیت انجام شد"
//        });
//    }

//    // --------------------------------------------------
//    // SIGN OUT
//    // --------------------------------------------------
//    [HttpGet("SignOut")]
//    public async Task<IActionResult> SignOut(CancellationToken cancellation)
//    {
//        await _identityService.LogoutAsync(cancellation);

//        return Ok(new
//        {
//            Success = true,
//            Data = ProviderServices.UserState,
//            Message = "خروج با موفقیت انجام شد"
//        });
//    }


//    [HttpPost("GenerateToken")]
//    public async Task<IActionResult> GenerateToken([FromBody] TokenRequest request, CancellationToken cancellation)
//    {
//        var result = await _tokenService.GenerateTokenAsync(request, cancellation);

//        if (!result.IsSuccess)
//            return BadRequest(result);

//        return Ok(new
//        {
//            Success = true,
//            Data = result,
//            Message = "توکن با موفقیت ایجاد شد"
//        });
//    }


//    [HttpPost("ValidateToken")]
//    public async Task<IActionResult> ValidateToken([FromBody] ValidateTokenRequest request, CancellationToken cancellation)
//    {
//        var result = await _tokenService.ValidateTokenAsync(
//            request.Token, cancellation);

//        if (!result.IsSuccess)
//            return Unauthorized(result);

//        return Ok(new
//        {
//            Success = true,
//            Message = "توکن معتبر است"
//        });
//    }

//    [HttpPost("RefreshToken")]
//    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellation)
//    {
//        var result = await _tokenService.GenerateRefreshTokenAsync(
//            request.Token,
//            request.RefreshToken,
//            cancellation);

//        if (!result.IsSuccess)
//            return Unauthorized(result);

//        return Ok(new
//        {
//            Success = true,
//            Data = result,
//            Message = "توکن جدید با موفقیت ایجاد شد"
//        });
//    }


//    [HttpPost("ReadToken")]
//    public IActionResult ReadToken([FromBody] ReadTokenRequest request)
//    {
//        var handler = new JwtSecurityTokenHandler();

//        if (!handler.CanReadToken(request.Token))
//            return BadRequest("توکن نامعتبر است");

//        var jwtToken = handler.ReadJwtToken(request.Token);

//        var claims = jwtToken.Claims.Select(c => new
//        {
//            c.Type,
//            c.Value
//        });

//        return Ok(new
//        {
//            Success = true,
//            Data = new
//            {
//                jwtToken.Issuer,
//                jwtToken.ValidFrom,
//                jwtToken.ValidTo,
//                Claims = claims
//            },
//            Message = "اطلاعات توکن با موفقیت استخراج شد"
//        });
//    }

//}