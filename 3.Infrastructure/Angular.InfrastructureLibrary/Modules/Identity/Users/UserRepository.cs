using Angular.ApplicationLibrary.Modules.Identity.Users.Repository;
using Angular.DomainLibrary.Identity;
using Angular.InfrastructureLibrary.BaseInfrastructure.Services;
using Angular.InfrastructureLibrary.Database;
using Microsoft.EntityFrameworkCore;

namespace Angular.InfrastructureLibrary.Modules.Identity.Users;

public class UserRepository : BaseRepository<UserEntity, int>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<RoleEntity> GetRoleInfoAsync(int roleId)
    {
        return await Context.Set<RoleEntity>().Where(item => item.Id == roleId).SingleAsync();
    }

    public async Task<List<UserRoleEntity>> GetUserRolesAsync(int userId)
    {
        return await Context.Set<UserRoleEntity>().Where(item => item.UserId == userId).ToListAsync();
    }
}
