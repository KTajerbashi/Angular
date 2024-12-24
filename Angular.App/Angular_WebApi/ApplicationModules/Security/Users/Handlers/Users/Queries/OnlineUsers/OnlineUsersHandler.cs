using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Security.Users.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Queries.OnlineUsers;

public class OnlineUsersHandler : QueryHandler<OnlineUsersQuery, List<OnlineUsersView>>
{
    private readonly IUserService _userService;
    public OnlineUsersHandler(UtilitiesServices utilitiesServices, IUserService userService) : base(utilitiesServices)
    {
        _userService = userService;
    }

    public override async Task<List<OnlineUsersView>> Handle(OnlineUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var dataList = await _userService.GetAsync(cancellationToken);
            var dataResult = UtilitiesServices.MapperFacade.Map<UserEntity,OnlineUsersView>(dataList.ToList());
            return dataResult;
        }
        catch
        {

            throw;
        }
    }
}
