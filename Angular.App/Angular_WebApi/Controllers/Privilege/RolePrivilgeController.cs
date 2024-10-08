using Angular_WebApi.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.Controllers.Privilege;

public class RolePrivilgeController : AuthController
{
    public override async Task<IActionResult> Index()
    {
        return Ok("");
    }
}
