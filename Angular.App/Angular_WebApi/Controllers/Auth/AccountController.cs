using Angular_WebApi.Controllers.BaseControllers;
using MediatR;

namespace Angular_WebApi.Controllers.Auth;

public class AccountController : AuthController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }

}
