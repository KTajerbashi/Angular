using Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Commands.CreateUser;
using Angular_WebApi.ApplicationModules.Security.Users.Models.DTOs;
using Angular_WebApi.ContextDB;
using Angular_WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Users.Contollers;

public class UserController : AuthController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost]
    public async Task<IActionResult> Create(UserCreateCommand model)
        => await base.Create<UserCreateCommand, long>(model);
    [HttpGet("Read")]
    public async Task<IActionResult> ReadAll()
    {
        return Ok(true);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(true);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UserDTO model)
    {
        return Ok(true);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Read(long id)
    {
        return Ok(true);
    }
}
