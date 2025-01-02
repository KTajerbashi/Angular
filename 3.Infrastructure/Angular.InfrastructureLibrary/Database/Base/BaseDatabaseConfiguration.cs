using Angular.DomainLibrary.Identity;
using Microsoft.EntityFrameworkCore;

namespace Angular.InfrastructureLibrary.Database.Base;

public static class BaseDatabaseConfiguration
{
    public static ModelBuilder AddSecurityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<UserEntity>().ToTable("Users", "Identity");
        builder.Entity<RoleEntity>().ToTable("Roles", "Identity");
        builder.Entity<RoleClaimEntity>().ToTable("RoleClaims", "Identity");
        builder.Entity<UserClaimEntity>().ToTable("UserClaims", "Identity");
        builder.Entity<UserLoginEntity>().ToTable("UserLogins", "Identity");
        builder.Entity<UserRoleEntity>().ToTable("UserRoles", "Identity");
        builder.Entity<UserTokenEntity>().ToTable("UserTokens", "Identity");
        return builder;
    }
}