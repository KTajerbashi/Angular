using Angular_WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Users.Contollers;

public class UserPrivilgeController : AuthController
{
    public UserPrivilgeController(IMediator mediator) : base(mediator)
    {
    }
}
