using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Queries.GetAll;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, UserGetAllView>().ReverseMap();
    }
}
