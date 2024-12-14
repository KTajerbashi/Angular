using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Security.Roles.Interfaces;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Commands.Delete;

public class RoleDeleteHandler : CommandHandler<RoleDeleteCommand, bool>
{
    private readonly IRoleService _service;
    public RoleDeleteHandler(UtilitiesServices utilitiesServices, IRoleService service) : base(utilitiesServices)
    {
        _service = service;
    }
    public override async Task<bool> Handle(RoleDeleteCommand command, CancellationToken cancellation)
    {
        await _service.Delete(command.Id, cancellation);
        await _service.SaveChangesAsync();
        return true;
    }
}

