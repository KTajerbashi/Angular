using Angular.ApplicationLibrary.Modules.Identity.Auth.CurrentUserInfo;
using Angular.EndPoint.WebApi.Controllers.Bases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Angular.EndPoint.WebApi.Controllers.Auth;

public class AccountController : BaseApiController
{
    protected IHttpContextAccessor httpContextAccessor;

    public AccountController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(mediator)
    {
        this.httpContextAccessor = httpContextAccessor;
    }


    //[HttpGet("RemoveAccount")]
    //public IActionResult RemoveAccount()
    //{
    //    return Return(true, "Remove Account Successfully", ApiResultType.Success);
    //}

    //[HttpGet("Signout")]
    //public IActionResult Signout()
    //{
    //    return Return(true, "Remove Account Successfully", ApiResultType.Success);
    //}

    //[HttpGet("Authorize")]
    //public IActionResult Authorize()
    //{
    //    var model = new
    //    {
    //        Success = true,
    //        Authorize = User.Identity?.IsAuthenticated,
    //        //Identity = User.Identity,
    //        User = User
    //    };

    //    return Return(model, "Remove Account Successfully", ApiResultType.Success);
    //}

    //[Authorize]
    //[HttpGet("AuthorizeAccess")]
    //public IActionResult AuthorizeAccess()
    //{
    //    return Return(true, "Authorize Access Successfully", ApiResultType.Success);
    //}

    //[HttpGet("UnAuthorizeAccess")]
    //public IActionResult UnAuthorizeAccess()
    //{
    //    return Return(true, "Un Authorize Access Successfully", ApiResultType.Success);
    //}

    //[HttpGet("GetUserInfo")]
    //public IActionResult GetUserInfo()
    //{
    //    // Access the current user's claims
    //    var user = httpContextAccessor.HttpContext?.User;

    //    if (user == null || !user.Identity?.IsAuthenticated == true)
    //    {
    //        return Return(true, "Un Authorize", ApiResultType.UnAuthorize);
    //    }

    //    // Extract claims
    //    var rolesClaim = user.FindFirst("Roles")?.Value ?? ""; // Roles stored as a comma-separated string
    //    var rolesList = rolesClaim.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

    //    // Populate the DTO
    //    var userInfo = new CurrentUserInfoDTO
    //    {
    //        Id = Convert.ToInt32(user.FindFirst("UserId").Value.ToString()),
    //        FirstName = user.FindFirst("FirstName")?.Value ?? "",
    //        LastName = user.FindFirst("LastName")?.Value ?? "",
    //        FullName = user.FindFirst("FullName")?.Value ?? "",
    //        DisplayName = user.FindFirst("DisplayName")?.Value ?? "",
    //        Email = user.FindFirst("Email")?.Value ?? "",
    //        UserRoleId = user.FindFirst("UserRoleId")?.Value ?? "",
    //        RoleId = user.FindFirst("RoleId")?.Value ?? "",
    //        IsAdmin = user.FindFirst("IsAdmin")?.Value ?? "",
    //        NationalCode = user.FindFirst("NationalCode")?.Value ?? "",
    //        PhoneNumber = user.FindFirst(ClaimTypes.MobilePhone)?.Value ?? "",
    //        Roles = rolesList,
    //    };

    //    return Return(userInfo, "Success Data", ApiResultType.Success);
    //}

}
