using Angular_WebApi.ApplicationBases.Services;
using Angular_WebApi.ApplicationModules.Security.Users.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.ContextDB;

namespace Angular_WebApi.ApplicationModules.Security.Users.Services;

public class UserService :
    BaseRepository<UserEntity, long>, IUserService
{
    public UserService(DatabaseContext context) : base(context)
    {
    }
}