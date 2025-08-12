using Angular.EndPoint.WebApi.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Angular.EndPoint.WebApi.Common.Controllers;


[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : Controller
{
    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    {
        return base.Ok(ApiResponse.Success(value, "Success", ""));
    }
}
