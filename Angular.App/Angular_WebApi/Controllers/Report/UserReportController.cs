using Angular_WebApi.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.Controllers.Report;

public class UserReportController : AuthController
{
    public override async Task<IActionResult> Index()
    {
        return Ok("");
    }
}
