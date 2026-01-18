using AngularApp.Core.Application.Common;
using AngularApp.Core.Domain.Entities.Security;

namespace AngularApp.Core.Application.Aggregates.Security.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity, long>
{
}
public interface IRoleRepository : IBaseRepository<RoleEntity, long>
{
}

