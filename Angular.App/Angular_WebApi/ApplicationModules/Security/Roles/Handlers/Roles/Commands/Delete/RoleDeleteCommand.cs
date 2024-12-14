using Angular_WebApi.ApplicationBases.Models;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Commands.Delete;

public class RoleDeleteCommand : Command<bool>
{
    public long Id { get; set; }

    public RoleDeleteCommand(long id)
    {
        Id = id;
    }
}

