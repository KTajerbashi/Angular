using Angular.ApplicationLibrary.Modules.Identity.Users.Queries.Get;
using Angular.ApplicationLibrary.Modules.Identity.Users.Queries.GetById;
using Angular.EndPoint.WebApi.Controllers.Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular.EndPoint.WebApi.Controllers.Identity;

public class UserController : BaseApiController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return await QueryAsync<UserGetByIdQuery, UserGetByIdDTO>(new UserGetByIdQuery(id));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await QueryListAsync<UserGetQuery, UserGetDTO>(new UserGetQuery());
    }
}
