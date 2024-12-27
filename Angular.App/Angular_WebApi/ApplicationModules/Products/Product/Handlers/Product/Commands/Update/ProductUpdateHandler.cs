using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Products.Product.Interfaces;
using Angular_WebApi.ApplicationModules.Products.Product.Models.Entities;
using Angular_WebApi.Middlewares.ExceptionHandler.Exceptions;
using Angular_WebApi.Utilities;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Commands.Update;

public class ProductUpdateHandler : CommandHandler<ProductUpdateCommand>
{
    private readonly IProductService _service;
    public ProductUpdateHandler(
        UtilitiesServices utilitiesServices,
        IProductService service) : base(utilitiesServices)
    {
        _service = service;
    }

    public override async Task Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        ProductEntity entity = await _service.GetAsync(request.Id,cancellationToken);
        if (entity == null)
            throw new AppException("Entity Not Found ... !");
        entity = UtilitiesServices.MapperFacade.Map<ProductUpdateCommand,ProductEntity>(request);
        await _service.SaveChangesAsync();
    }
}

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductUpdateCommand>().ReverseMap();
    }
}
