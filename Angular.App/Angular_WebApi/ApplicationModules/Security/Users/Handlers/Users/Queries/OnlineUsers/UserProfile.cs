using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Queries.OnlineUsers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<OnlineUsersView, UserEntity>().ReverseMap();
    }
}
