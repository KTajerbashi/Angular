using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.ContextDB.Configuration;
using Angular_WebApi.ContextDB.Properties;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApi.ContextDB.Bases;

public abstract class BaseDatabaseContext : IdentityDbContext
    <UserEntity, RoleEntity, long, UserClaimEntity, UserRoleEntity, UserLoginEntity, RoleClaimEntity, UserTokenEntity>
{
    protected BaseDatabaseContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.AddSecurityConfiguration();
        builder.AddAuditableShadowProperties<long>();
    }
}
