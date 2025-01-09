using Angular.ApplicationLibrary.BaseApplication.Interfaces;
using Angular.DomainLibrary.Identity;

namespace Angular.ApplicationLibrary.Modules.Identity.Users.Repository;

public interface IUserRepository : IBaseRepository<UserEntity, int>
{
    Task<List<UserRoleEntity>> GetUserRolesAsync(int userId);
    Task<RoleEntity> GetRoleInfoAsync(int roleId);
}
