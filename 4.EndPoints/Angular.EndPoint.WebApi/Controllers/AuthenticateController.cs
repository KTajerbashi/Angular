using Angular.EndPoint.WebApi.Controllers.Bases;
using Microsoft.AspNetCore.Mvc;

namespace Angular.EndPoint.WebApi.Controllers;

// Concrete controller with authentication-specific behavior
public class AuthenticateController : BaseController
{
    // Login action simplified without needing async when no I/O operation is involved
    [HttpPost("Login")]
    public IActionResult Login()
    {
        return Return("Login");
    }

    [HttpGet("Signout")]
    public IActionResult Signout()
    {
        return Return("Signout");
    }
}
