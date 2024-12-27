using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Products.Product.Interfaces;
using Angular_WebApi.ApplicationModules.Products.Product.Models.Entities;
using Angular_WebApi.Utilities;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Commands.Create;
public class ProductCreateHandler : CommandHandler<ProductCreateCommand>
{
    private readonly IProductService _service;
    public ProductCreateHandler(
        UtilitiesServices utilitiesServices,
        IProductService service)
        : base(utilitiesServices)
    {
        _service = service;
    }

    public override async Task Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ProductEntity product = UtilitiesServices.MapperFacade.Map<ProductCreateCommand,ProductEntity>(request);
            await _service.CreateAsync(product,cancellationToken);
            await _service.SaveChangesAsync();
        }
        catch
        {

            throw;
        }
    }
}


public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductCreateCommand>().ReverseMap();
    }
}
