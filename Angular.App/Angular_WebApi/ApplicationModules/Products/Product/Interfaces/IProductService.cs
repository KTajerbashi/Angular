using Angular_WebApi.ApplicationBases.Repositories;
using Angular_WebApi.ApplicationModules.Products.Product.Models.Entities;

namespace Angular_WebApi.ApplicationModules.Products.Product.Interfaces;

public interface IProductService : IBaseRepository<ProductEntity, long>
{
}
