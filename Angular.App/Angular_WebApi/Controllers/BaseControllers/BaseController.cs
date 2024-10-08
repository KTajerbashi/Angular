using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.Controllers.BaseControllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{
    [HttpGet("index")]
    public abstract Task<IActionResult> Index();
}
