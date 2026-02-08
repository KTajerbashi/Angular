using AngularApp.Core.Application.Common;
using AngularApp.Core.Domain.Entities.Security.Role;

namespace AngularApp.Core.Application.Aggregates.Security.Roles.Repository;

public interface IRoleRepository : IBaseRepository<RoleEntity, long>
{
}

