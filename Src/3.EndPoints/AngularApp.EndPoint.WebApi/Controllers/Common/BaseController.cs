using Microsoft.AspNetCore.Mvc;

namespace AngularApp.EndPoint.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{

}
public abstract class AuthController : BaseController
{

}
