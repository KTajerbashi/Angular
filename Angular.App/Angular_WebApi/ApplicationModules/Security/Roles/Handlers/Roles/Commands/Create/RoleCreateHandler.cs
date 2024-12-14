using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Security.Roles.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Commands.Create;

public class RoleCreateHandler : CommandHandler<RoleCreateCommand, long>
{
    private readonly IRoleService _service;
    public RoleCreateHandler(UtilitiesServices utilitiesServices, IRoleService service) : base(utilitiesServices)
    {
        _service = service;
    }

    public override async Task<long> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
    {
        RoleEntity role = new RoleEntity(request.Name,request.Title);
        await _service.CreateAsync(role,cancellationToken);
        return role.Id;

    }
}

