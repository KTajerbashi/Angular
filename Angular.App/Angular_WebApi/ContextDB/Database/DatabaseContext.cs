using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.ContextDB.Bases;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApi.ContextDB.Database;

public class DatabaseContext : BaseDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    #region DbSet

    public virtual DbSet<UserEntity> UserEntities => Set<UserEntity>();
    public virtual DbSet<UserClaimEntity> UserClaimEntities => Set<UserClaimEntity>();
    public virtual DbSet<UserLoginEntity> UserLoginEntities => Set<UserLoginEntity>();
    public virtual DbSet<UserTokenEntity> UserTokenEntities => Set<UserTokenEntity>();
    public virtual DbSet<RoleEntity> RoleEntities => Set<RoleEntity>();
    public virtual DbSet<RoleClaimEntity> RoleClaimEntities => Set<RoleClaimEntity>();
    public virtual DbSet<UserRoleEntity> UserRoleEntities => Set<UserRoleEntity>();


    #endregion

}
