using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApi.ContextDB;

public class DatabaseContext : BaseDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    #region DbSet
    
    public virtual DbSet<UserEntity> UserEntities { get; set; }
    public virtual DbSet<UserClaimEntity> UserClaimEntities { get; set; }
    public virtual DbSet<UserLoginEntity> UserLoginEntities { get; set; }
    public virtual DbSet<UserTokenEntity> UserTokenEntities { get; set; }
    public virtual DbSet<RoleEntity> RoleEntities { get; set; }
    public virtual DbSet<RoleClaimEntity> RoleClaimEntities { get; set; }
    public virtual DbSet<UserRoleEntity> UserRoleEntities { get; set; }


    #endregion

}
