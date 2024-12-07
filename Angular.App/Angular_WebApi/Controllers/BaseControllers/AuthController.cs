using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Angular_WebApi.Controllers.BaseControllers;

//[Authorize]
public abstract class AuthController : BaseController
{
    protected AuthController(IMediator mediator) : base(mediator)
    {
    }
}
