using Angular.ApplicationLibrary.Providers;
using Angular.EndPoint.WebApi.Controllers.Bases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Angular.EndPoint.WebApi.Controllers.Auth;

public class AccountController : BaseApiController
{
    private readonly ProviderServices _providerServices;

    public AccountController(IMediator mediator, ProviderServices providerServices) : base(mediator)
    {
        _providerServices = providerServices;
    }


    [HttpGet("RemoveAccount")]
    public IActionResult RemoveAccount()
    {
        return Return("RemoveAccount");
    }

    [HttpGet("Signout")]
    public IActionResult Signout()
    {
        return Return("Signout");
    }

    [HttpGet("Authorize")]
    public IActionResult Authorize()
    {
        var model = new
        {
            Success = true,
            Authorize = User.Identity?.IsAuthenticated,
            //Identity = User.Identity,
            User = User
        };

        return Return(User);
    }

    [Authorize]
    [HttpGet("AuthorizeAccess")]
    public IActionResult AuthorizeAccess()
    {
        return Return(new { Access = true });
    }

    [HttpGet("UnAuthorizeAccess")]
    public IActionResult UnAuthorizeAccess()
    {
        return Return(new { Access = true });
    }

}
