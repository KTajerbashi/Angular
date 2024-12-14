using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.ApplicationModules.Security.Roles.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.Utilities;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Queries.GetAll;

public class RoleGetAllView : BaseView
{
    public string Name { get; set; }
    public string Title { get; set; }
}

public class RoleGetAllHandler : QueryHandler<RoleGetAllQuery, List<RoleGetAllView>>
{
    private readonly IRoleService _roleService;
    public RoleGetAllHandler(UtilitiesServices utilitiesServices, IRoleService roleService) : base(utilitiesServices)
    {
        _roleService = roleService;
    }

    public override async Task<List<RoleGetAllView>> Handle(RoleGetAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var dataList = await _roleService.GetAsync(cancellationToken);
            var result = UtilitiesServices.MapperFacade.Map<RoleEntity, RoleGetAllView>(dataList.ToList());
            return result;
        }
        catch
        {

            throw;
        }
    }
}


public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleEntity, RoleGetAllView>().ReverseMap();
    }
}
