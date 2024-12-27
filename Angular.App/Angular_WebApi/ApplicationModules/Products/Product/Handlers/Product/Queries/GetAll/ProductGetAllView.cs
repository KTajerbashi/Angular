using Angular_WebApi.ApplicationBases.Models;

namespace Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Queries.GetAll;

public class ProductGetAllView : BaseView
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }
}