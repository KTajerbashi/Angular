using AngularApp.Core.Application.UseCases.Security.Users.Handlers.Add;
using AngularApp.Core.Application.UseCases.Security.Users.Handlers.ReadAll;
using AngularApp.Core.Application.UseCases.Security.Users.Handlers.ReadById;
using AngularApp.Core.Application.UseCases.Security.Users.Handlers.ReadDataGrid;
using AngularApp.Core.Application.UseCases.Security.Users.Handlers.Remove;
using AngularApp.Core.Application.UseCases.Security.Users.Handlers.Update;

namespace AngularApp.EndPoint.WebApi.Controllers.Security;

public class UserController : AuthController
{
    [HttpGet]
    public async Task<IActionResult> Get()
        => await QueryListAsync<ReadAllQuery, ReadAllQueryModel>(new());

    [HttpPost("ReadDataGrid")]
    public async Task<IActionResult> ReadDataGrid(ReadDataGridQuery query)
        => await ReadDataGridAsync<ReadDataGridQuery, ReadDataGridView>(query);


    [HttpGet("{entityId}")]
    public async Task<IActionResult> Get(Guid entityId)
        => await QueryAsync<ReadByIdQuery, ReadByIdQueryModel>(new(entityId));

    [HttpPost]
    public async Task<IActionResult> Add(AddCommand command)
        => await CommandAsync<AddCommand, AddResponse>(command);

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCommand command)
        => await CommandAsync<UpdateCommand>(command);

    [HttpDelete]
    public async Task<IActionResult> Remove(RemoveCommand command)
    => await CommandAsync<RemoveCommand>(command);
}
