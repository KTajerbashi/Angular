using AngularApp.Core.Application.Providers;
using AngularApp.EndPoint.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.EndPoint.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ProviderServices ProviderServices => HttpContext.GetProviderServices();
}
