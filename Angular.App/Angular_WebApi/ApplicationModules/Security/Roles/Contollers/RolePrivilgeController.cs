using Angular_WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Contollers;

public class RolePrivilgeController : AuthController
{
    public RolePrivilgeController(IMediator mediator) : base(mediator)
    {
    }
}
