using AngularApp.Core.Application.Common;
using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Application.Aggregates.Security.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity, long>
{
}
public interface IRoleRepository : IBaseRepository<RoleEntity, long>
{
}

