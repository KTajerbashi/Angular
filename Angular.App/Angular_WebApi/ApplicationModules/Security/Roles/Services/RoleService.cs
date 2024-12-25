using Angular_WebApi.ApplicationBases.Services;
using Angular_WebApi.ApplicationModules.Security.Roles.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.ContextDB.Database;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Services;

public class RoleService : BaseRepository<RoleEntity, long>, IRoleService
{
    public RoleService(DatabaseContext context) : base(context)
    {
    }
}