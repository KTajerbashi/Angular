using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Security.Users.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Queries.GetAll;

public class UserGetAllHandler : QueryHandler<UserGetAllQuery, List<UserGetAllView>>
{
    private readonly IUserService _userService;
    public UserGetAllHandler(UtilitiesServices utilitiesServices, IUserService userService) : base(utilitiesServices)
    {
        _userService = userService;
    }

    public override async Task<List<UserGetAllView>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var dataList = await _userService.GetAsync(cancellationToken);
            var result = UtilitiesServices.MapperFacade.Map<UserEntity, UserGetAllView>(dataList.ToList());
            return result.ToList();
        }
        catch
        {

            throw;
        }
    }
}
