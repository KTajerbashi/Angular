using AngularApp.EndPoint.WebApi.Exceptions;
using AngularApp.EndPoint.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.EndPoint.WebApi.Controllers.Common;

public abstract class AuthController : BaseController
{
    //[HttpGet("Profile")]
    //public async Task<IActionResult> Profile()
    //{
    //    try
    //    {
    //        IdentityProfileResponse response = new();
    //        response.BuildUser();
    //        response.BuildRole();
    //        response.BuildRoles();
    //        response.BuildUserRoles();
    //        response.BuildGroups();
    //        response.BuildMenus();
    //        response.BuildPrivielges();
    //        return Ok(response);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex.ThrowApiException();
    //    }
    //}
}
