using Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Commands.Create;
using Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Commands.Delete;
using Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Commands.Update;
using Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Queries.GetAll;
using Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Queries.RoleGetById;
using Angular_WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Contollers;

public class RoleController : AuthController
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }



    [HttpPost]
    public async Task<IActionResult> Create(RoleCreateCommand command) => await base.Create<RoleCreateCommand, long>(command);


    [HttpGet]
    public async Task<IActionResult> ReadAll() => await QueryList<RoleGetAllQuery, RoleGetAllView>(new RoleGetAllQuery());

    [HttpGet("{id}")]
    public async Task<IActionResult> Read(long id) => await Query<RoleGetByIdQuery, RoleGetByIdDTO>(new RoleGetByIdQuery(id));


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id) => await Command<RoleDeleteCommand, bool>(new RoleDeleteCommand(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, RoleUpdateCommand command) => await Command<RoleUpdateCommand, bool>(command);
}
