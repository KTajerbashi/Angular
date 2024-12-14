using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.ApplicationModules.Security.Roles.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.Utilities;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Queries.RoleGetById;

public class RoleGetByIdDTO : BaseDTO
{
    public string Name { get; set; }
    public string Title { get; set; }
}
public class RoleGetByIdQuery : Query<RoleGetByIdDTO>
{
    public long Id { get; set; }

    public RoleGetByIdQuery(long id)
    {

    }
}

public class RoleGetByIdHandler : QueryHandler<RoleGetByIdQuery, RoleGetByIdDTO>
{
    private readonly IRoleService _roleService;
    public RoleGetByIdHandler(UtilitiesServices utilitiesServices, IRoleService roleService) : base(utilitiesServices)
    {
        _roleService = roleService;
    }

    public override async Task<RoleGetByIdDTO> Handle(RoleGetByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _roleService.GetAsync(request.Id, cancellationToken);
        var result = UtilitiesServices.MapperFacade.Map<RoleEntity, RoleGetByIdDTO>(model);
        return result;
    }
}


public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleEntity, RoleGetByIdDTO>().ReverseMap();
    }
}
