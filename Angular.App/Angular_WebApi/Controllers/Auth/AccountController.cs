using Angular_WebApi.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.Controllers.Auth;

public class AccountController : AuthController
{
    public override async Task<IActionResult> Index()
    {
        return Ok("");
    }
}
