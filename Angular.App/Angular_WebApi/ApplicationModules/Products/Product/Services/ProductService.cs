using Angular_WebApi.ApplicationBases.Services;
using Angular_WebApi.ApplicationModules.Products.Product.Interfaces;
using Angular_WebApi.ApplicationModules.Products.Product.Models.Entities;
using Angular_WebApi.ContextDB.Database;

namespace Angular_WebApi.ApplicationModules.Products.Product.Services;

public class ProductService : BaseRepository<ProductEntity, long>, IProductService
{
    public ProductService(DatabaseContext context) : base(context)
    {
    }
}
