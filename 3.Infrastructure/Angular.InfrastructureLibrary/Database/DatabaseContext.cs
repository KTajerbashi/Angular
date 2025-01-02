using Angular.DomainLibrary.Identity;
using Angular.InfrastructureLibrary.Database.Base;
using Microsoft.EntityFrameworkCore;

namespace Angular.InfrastructureLibrary.Database;

public class DatabaseContext : BaseDatabaseContext
{

    protected DatabaseContext()
    {

    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserEntity> UserEntities => Set<UserEntity>();
    public virtual DbSet<UserClaimEntity> UserClaimEntities => Set<UserClaimEntity>();
    public virtual DbSet<UserLoginEntity> UserLoginEntities => Set<UserLoginEntity>();
    public virtual DbSet<UserTokenEntity> UserTokenEntities => Set<UserTokenEntity>();
    public virtual DbSet<RoleEntity> RoleEntities => Set<RoleEntity>();
    public virtual DbSet<RoleClaimEntity> RoleClaimEntities => Set<RoleClaimEntity>();
    public virtual DbSet<UserRoleEntity> UserRoleEntities => Set<UserRoleEntity>();

}
