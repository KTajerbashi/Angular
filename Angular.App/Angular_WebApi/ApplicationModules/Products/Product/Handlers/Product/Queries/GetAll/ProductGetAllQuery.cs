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
            new ProductGetAllView(){ Id = 1,Title = "Mobile",Access = true,Link = "/Mobile",Order = 1},
            new ProductGetAllView(){ Id = 2,Title = "Laptop",Access = false,Link = "/Laptop",Order = 2},
            new ProductGetAllView(){ Id = 3,Title = "Keyboard",Access = true,Link = "/Keyboard",Order = 3},
            new ProductGetAllView(){ Id = 4,Title = "Monitor",Access = false,Link = "/Monitor",Order = 4},
            new ProductGetAllView(){ Id = 5,Title = "Mouse",Access = true,Link = "/Mouse",Order = 5},
            new ProductGetAllView(){ Id = 6,Title = "Case",Access = true,Link = "/Case",Order = 6},
        };
    }
}

public class ProductGetAllQuery : Query<List<ProductGetAllView>>
{
}
public class ProductGetAllView : BaseView
{
    public string Title { get; set; }
    public string Link { get; set; }
    public bool Access { get; set; }
    public byte Order { get; set; }
}