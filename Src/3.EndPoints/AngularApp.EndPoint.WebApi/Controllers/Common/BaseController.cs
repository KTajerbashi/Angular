using AngularApp.Core.Application.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AngularApp.EndPoint.WebApi.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ProviderServices ProviderServices => HttpContext.GetProviderServices();

    //public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    //{
    //    return Ok(ApiResult.Success(value));
    //}


    //protected ObjectResult FailResult(string message, int statusCode = StatusCodes.Status400BadRequest)
    //{
    //    return StatusCode(statusCode, ApiResult.Faild(message));
    //}


}
