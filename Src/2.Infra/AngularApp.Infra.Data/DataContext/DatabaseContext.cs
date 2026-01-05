using AngularApp.Core.Domain.Entities.Store;
using AngularApp.Infra.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Infra.Data.DataContext;

public class DatabaseContext : BaseDataContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    #region Store
    public virtual DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    public virtual DbSet<ProductEntity> Products => Set<ProductEntity>();
    public virtual DbSet<ProductDetailEntity> ProductDetails => Set<ProductDetailEntity>();
    public virtual DbSet<ShopEntity> Shops => Set<ShopEntity>();
    #endregion
}
