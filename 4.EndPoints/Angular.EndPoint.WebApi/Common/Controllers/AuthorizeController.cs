using Microsoft.AspNetCore.Authorization;

namespace Angular.EndPoint.WebApi.Common.Controllers;

[Authorize]
public abstract class AuthorizeController : BaseController
{
}
