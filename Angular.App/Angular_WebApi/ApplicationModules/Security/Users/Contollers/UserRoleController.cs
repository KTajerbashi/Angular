using Angular_WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Users.Contollers;

public class UserRoleController : AuthController
{
    public UserRoleController(IMediator mediator) : base(mediator)
    {
    }
}
