using AngularApp.Core.Domain.Entities.Security;
using AngularApp.Infra.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Infra.Data.DataContext;

public class DatabaseContext : BaseDataContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    #region Security
    public virtual DbSet<UserEntity> UserEntities => Set<UserEntity>();
    public virtual DbSet<RoleEntity> RoleEntities => Set<RoleEntity>();
    public virtual DbSet<UserRoleEntity> UserRoleEntities => Set<UserRoleEntity>();
    public virtual DbSet<UserClaimEntity> UserClaimEntities => Set<UserClaimEntity>();
    public virtual DbSet<UserLoginEntity> UserLoginEntities => Set<UserLoginEntity>();
    public virtual DbSet<UserTokenEntity> UserTokenEntities => Set<UserTokenEntity>();
    public virtual DbSet<RoleClaimEntity> RoleClaimEntities => Set<RoleClaimEntity>();
    #endregion

    #region Store
    //public virtual DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    //public virtual DbSet<ProductEntity> Products => Set<ProductEntity>();
    //public virtual DbSet<ProductDetailEntity> ProductDetails => Set<ProductDetailEntity>();
    //public virtual DbSet<ShopEntity> Shops => Set<ShopEntity>();
    #endregion
}
