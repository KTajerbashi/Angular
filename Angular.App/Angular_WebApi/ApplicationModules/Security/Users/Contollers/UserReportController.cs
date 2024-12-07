using Angular_WebApi.Controllers.BaseControllers;
using MediatR;

namespace Angular_WebApi.ApplicationModules.Security.Users.Contollers;

public class UserReportController : AuthController
{
    public UserReportController(IMediator mediator) : base(mediator)
    {
    }
}
