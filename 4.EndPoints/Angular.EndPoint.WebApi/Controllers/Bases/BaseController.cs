using Angular.ApplicationLibrary.Providers;
using Angular.EndPoint.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Angular.EndPoint.WebApi.Controllers.Bases;

// Abstract base controller with general functionality
[Route("app/[controller]")]
public abstract class BaseController : Controller
{
    protected ProviderServices ApplicationContext => HttpContext.ApplicationContext();
    // Return method simplified with a non-async version.
    // Async behavior is unnecessary since the result is a static value.
    protected virtual IActionResult Return(object? obj)
    {
        if (obj == null)
        {
            return Ok("");  // Return an empty string if obj is null
        }

        return Ok(obj);  // Return the object as an OK result
    }
}
