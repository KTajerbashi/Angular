﻿using Angular_WebApi.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Users.Contollers;

public class UserReportController : AuthController
{
    public override async Task<IActionResult> Index()
    {
        return Ok("");
    }
}