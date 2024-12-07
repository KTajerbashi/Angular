using Angular_WebApi.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Contollers;

public class RoleController : AuthController
{
    public override async Task<IActionResult> Index()
    {
        return Ok("");
    }
}
