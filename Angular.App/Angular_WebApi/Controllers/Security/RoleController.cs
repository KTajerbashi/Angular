using Angular_WebApi.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.Controllers.Security;

public class RoleController : AuthController
{
    public override async Task<IActionResult> Index()
    {
        return Ok("");
    }
}
