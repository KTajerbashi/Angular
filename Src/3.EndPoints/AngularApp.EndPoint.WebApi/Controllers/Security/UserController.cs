using AngularApp.Core.Application.Aggregates.Security.Users.Handlers.Add;

namespace AngularApp.EndPoint.WebApi.Controllers.Security;

public class UserController : AuthController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserAddCommand command)
        => await Command<UserAddCommand, UserAddResponse>(command);
}
