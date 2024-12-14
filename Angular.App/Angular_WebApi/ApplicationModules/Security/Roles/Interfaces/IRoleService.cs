using Angular_WebApi.ApplicationBases.Repositories;
using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Interfaces;

public interface IRoleService : IBaseRepository<RoleEntity, long>
{
}
