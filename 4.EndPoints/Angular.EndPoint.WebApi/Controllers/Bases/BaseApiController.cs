using Microsoft.AspNetCore.Mvc;

namespace Angular.EndPoint.WebApi.Controllers.Bases;

// Abstract base API controller extending BaseController for shared logic between API controllers
[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : BaseController
{
    // Common API logic can be added here if needed in future
}
