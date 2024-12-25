using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApi.ContextDB.Configuration;

public static class DbContextConfiguration
{
    public static ModelBuilder AddSecurityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<UserEntity>().ToTable("Users", "Identity");
        builder.Entity<UserClaimEntity>().ToTable("UserClaims", "Identity");
        builder.Entity<UserLoginEntity>().ToTable("UserLogins", "Identity");
        builder.Entity<UserRoleEntity>().ToTable("UserRoles", "Identity");
        builder.Entity<UserTokenEntity>().ToTable("UserTokens", "Identity");
        builder.Entity<RoleEntity>().ToTable("Roles", "Identity");
        builder.Entity<RoleClaimEntity>().ToTable("RoleClaims", "Identity");

        //builder.ApplyConfiguration(new UserConfiguration());
        //builder.ApplyConfiguration(new GroupConfiguration());
        //builder.ApplyConfiguration(new PrivilegeConfiguration());
        //builder.ApplyConfiguration(new UserRoleConfiguration());
        //builder.ApplyConfiguration(new UserRoleGroupConfiguration());
        //builder.ApplyConfiguration(new GroupPrivilegeConfiguration());
        //builder.ApplyConfiguration(new GroupPermissionConfiguration());
        //builder.ApplyConfiguration(new GroupOrganizationConfiguration());
        //builder.ApplyConfiguration(new UserRolePrivilegeConfiguration());

        return builder;
    }
}
