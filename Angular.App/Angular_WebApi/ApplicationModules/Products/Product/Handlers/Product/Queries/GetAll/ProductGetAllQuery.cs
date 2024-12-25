using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Queries.GetAll;

public class ProductGetAllHandler : QueryHandler<ProductGetAllQuery, List<ProductGetAllView>>
{
    public ProductGetAllHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override async Task<List<ProductGetAllView>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new List<ProductGetAllView>()
        {
            new ProductGetAllView(){ Id = 1,Name = "Mobile",Description= "Mobile Desc",Price = 250000,Status= true},
            new ProductGetAllView(){ Id = 2,Name = "Laptop",Description= "Laptop Desc",Price = 250000,Status= true},
            new ProductGetAllView(){ Id = 3,Name = "Keyboard",Description= "Keyboard Desc",Price = 250000,Status= true},
            new ProductGetAllView(){ Id = 4,Name = "Monitor",Description= "Monitor Desc",Price = 250000,Status= true},
            new ProductGetAllView(){ Id = 5,Name = "Mouse",Description= "Mouse Desc",Price = 250000,Status= true},
            new ProductGetAllView(){ Id = 6,Name = "Case",Description= "Case Desc",Price = 250000,Status= true},
        };
    }
}

public class ProductGetAllQuery : Query<List<ProductGetAllView>>
{
}
public class ProductGetAllView : BaseView
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }
}