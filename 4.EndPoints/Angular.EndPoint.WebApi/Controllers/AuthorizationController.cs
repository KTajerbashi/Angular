using Angular.EndPoint.WebApi.Controllers.Bases;
using Microsoft.AspNetCore.Mvc;

namespace Angular.EndPoint.WebApi.Controllers;

public class AuthorizationController : BaseApiController
{
    // Login action simplified without needing async when no I/O operation is involved
    [HttpPost("Register")]
    public IActionResult Register()
    {
        return Return("Register");
    }

    [HttpGet("RemoveAccount")]
    public IActionResult RemoveAccount()
    {
        return Return("RemoveAccount");
    }
}
