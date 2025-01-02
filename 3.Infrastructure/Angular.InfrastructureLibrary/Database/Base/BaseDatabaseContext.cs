using Angular.DomainLibrary.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Angular.InfrastructureLibrary.Database.Base;

public abstract class BaseDatabaseContext :
    IdentityDbContext<UserEntity, RoleEntity, int, UserClaimEntity, UserRoleEntity, UserLoginEntity, RoleClaimEntity, UserTokenEntity>
{
    protected BaseDatabaseContext()
    {

    }
    public BaseDatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.AddSecurityConfiguration();
    }
}
