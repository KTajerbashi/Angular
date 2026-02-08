using AngularApp.Core.Application.Common;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Application.Aggregates.Security.Users.Repository;

public interface IUserRepository : IBaseRepository<UserEntity, long>
{
}

