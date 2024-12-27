using Angular_WebApi.ApplicationBases.Models;

namespace Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Commands.Delete;

public class ProductDeleteCommand : Command
{
    public long Id { get; set; }

    public ProductDeleteCommand(long id)
    {
        Id = id;
    }
}

