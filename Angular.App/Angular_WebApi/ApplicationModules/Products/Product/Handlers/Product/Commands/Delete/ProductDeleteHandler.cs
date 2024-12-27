using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Products.Product.Interfaces;
using Angular_WebApi.ApplicationModules.Products.Product.Models.Entities;
using Angular_WebApi.Middlewares.ExceptionHandler.Exceptions;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Commands.Delete;

public class ProductDeleteHandler : CommandHandler<ProductDeleteCommand>
{
    private readonly IProductService _service;
    public ProductDeleteHandler(UtilitiesServices utilitiesServices, IProductService service) : base(utilitiesServices)
    {
        _service = service;
    }

    public override async Task Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ProductEntity entity = await _service.GetAsync(request.Id,cancellationToken);
            if (entity == null)
                throw new AppException("Entity Not Found ... !");
            entity.Delete();
            await _service.SaveChangesAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
