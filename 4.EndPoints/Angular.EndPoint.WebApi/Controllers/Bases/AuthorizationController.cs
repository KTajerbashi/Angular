using MediatR;

namespace Angular.EndPoint.WebApi.Controllers.Bases;

public abstract class AuthorizationController : BaseApiController
{
    public AuthorizationController(IMediator mediator) : base(mediator)
    {
    }


}