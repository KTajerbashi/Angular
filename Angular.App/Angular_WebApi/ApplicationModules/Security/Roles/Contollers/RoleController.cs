using Angular_WebApi.Controllers.BaseControllers;
using MediatR;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Contollers;

public class RoleController : AuthController
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }
}
