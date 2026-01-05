using AngularApp.Core.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AngularApp.Infra.Data.Common;

public abstract class BaseDataContext : IdentityDbContext<
    UserEntity,
    RoleEntity,
    long,
    UserClaimEntity,
    UserRoleEntity,
    UserLoginEntity,
    RoleClaimEntity,
    UserTokenEntity>
{

    protected BaseDataContext(DbContextOptions options) : base(options) { }

    // ----------------------------------------------------
    // Model configuration
    // ----------------------------------------------------
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Ignore Identity passkey entity (fix migration error)
        builder.Ignore<IdentityPasskeyData>();

        builder.HasDefaultSchema("Security");

        builder.Entity<UserEntity>().ToTable("Users");
        builder.Entity<RoleEntity>().ToTable("Roles");
        builder.Entity<UserRoleEntity>().ToTable("UserRoles");
        builder.Entity<UserClaimEntity>().ToTable("UserClaims");
        builder.Entity<UserTokenEntity>().ToTable("UserTokens");
        builder.Entity<RoleClaimEntity>().ToTable("RoleClaims");
        builder.Entity<UserLoginEntity>().ToTable("UserLogins");

        AddShadowProperties(builder);
        AddSoftDeleteQueryFilters(builder);
    }

    // ----------------------------------------------------
    // Shadow Properties
    // ----------------------------------------------------
    private static void AddShadowProperties(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.ClrType == null || entityType.IsOwned())
                continue;

            builder.Entity(entityType.ClrType)
                .Property<bool>(ShadowProperties.IsActive)
                .HasDefaultValue(true);

            builder.Entity(entityType.ClrType)
                .Property<bool>(ShadowProperties.IsDeleted)
                .HasDefaultValue(false);

            builder.Entity(entityType.ClrType)
                .Property<long?>(ShadowProperties.CreatedByUserId);

            builder.Entity(entityType.ClrType)
                .Property<long?>(ShadowProperties.UpdatedByUserId);

            builder.Entity(entityType.ClrType)
                .Property<DateTime>(ShadowProperties.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity(entityType.ClrType)
                .Property<DateTime?>(ShadowProperties.UpdatedDate);
        }
    }

    // ----------------------------------------------------
    // Global Soft Delete Filter
    // ----------------------------------------------------
    private static void AddSoftDeleteQueryFilters(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.ClrType == null)
                continue;

            var parameter = Expression.Parameter(entityType.ClrType, "e");

            var isDeletedProperty = Expression.Call(
                typeof(EF),
                nameof(EF.Property),
                new[] { typeof(bool) },
                parameter,
                Expression.Constant(ShadowProperties.IsDeleted));

            var filter = Expression.Lambda(
                Expression.Equal(isDeletedProperty, Expression.Constant(false)),
                parameter);

            builder.Entity(entityType.ClrType).HasQueryFilter(filter);
        }
    }

}
