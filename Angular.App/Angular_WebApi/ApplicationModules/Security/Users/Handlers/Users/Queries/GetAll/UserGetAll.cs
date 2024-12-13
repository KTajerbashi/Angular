using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.ApplicationModules.Security.Users.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.Utilities;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Queries.GetAll;
public class UserGetAllQuery : Query<List<UserGetAllDTO>>
{
}
public class UserGetAllHandler : QueryHandler<UserGetAllQuery, List<UserGetAllDTO>>
{
    private readonly IUserService _userService;
    public UserGetAllHandler(UtilitiesServices utilitiesServices, IUserService userService) : base(utilitiesServices)
    {
        _userService = userService;
    }

    public override async Task<List<UserGetAllDTO>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var dataList = await _userService.GetAsync(cancellationToken);
            var result = UtilitiesServices.MapperFacade.Map<UserEntity, UserGetAllDTO>(dataList.ToList());
            return result.ToList();
        }
        catch
        {

            throw;
        }
    }
}


public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, UserGetAllDTO>().ReverseMap();
    }
}
