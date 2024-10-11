using Angular_WebApi.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Angular_WebApi.Controllers.BaseControllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{
    [HttpGet("index")]
    public abstract Task<IActionResult> Index();
    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        => base.Ok(_JsonResult.Success(value ?? true));
}
