using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.ApplicationModules.Security.Roles.Interfaces;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Commands.Update;

public class RoleUpdateCommand : Command<bool>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
}
public class RoleUpdateHandler : CommandHandler<RoleUpdateCommand, bool>
{
    private readonly IRoleService _roleService;
    public RoleUpdateHandler(UtilitiesServices utilitiesServices, IRoleService roleService) : base(utilitiesServices)
    {
        _roleService = roleService;
    }

    public override async Task<bool> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _roleService.GetAsync(request.Id,cancellationToken);
        entity.Update(request.Name, request.Title);

        await _roleService.SaveChangesAsync();

        return true;

    }
}