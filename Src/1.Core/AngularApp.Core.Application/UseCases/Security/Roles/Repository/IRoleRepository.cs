using AngularApp.Core.Application.Common;
using AngularApp.Core.Domain.Entities.Security.Role;

namespace AngularApp.Core.Application.UseCases.Security.Roles.Repository;

public interface IRoleRepository : IBaseRepository<RoleEntity, long>
{
}

