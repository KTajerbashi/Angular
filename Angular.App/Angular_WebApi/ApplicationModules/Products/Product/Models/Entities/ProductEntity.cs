using Angular_WebApi.ApplicationBases.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Products.Product.Models.Entities;

[Table("Product", Schema = "Product")]
public class ProductEntity : BaseEntity
{
}
