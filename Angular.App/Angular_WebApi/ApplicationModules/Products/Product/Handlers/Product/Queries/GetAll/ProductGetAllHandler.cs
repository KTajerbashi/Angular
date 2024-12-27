using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Products.Product.Interfaces;
using Angular_WebApi.ApplicationModules.Products.Product.Models.Entities;
using Angular_WebApi.Utilities;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Queries.GetAll;

public class ProductGetAllHandler : QueryHandler<ProductGetAllQuery, List<ProductGetAllView>>
{
    private readonly IProductService _service;
    public ProductGetAllHandler(UtilitiesServices utilitiesServices, IProductService service) : base(utilitiesServices)
    {
        _service = service;
    }

    public override async Task<List<ProductGetAllView>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _service.GetAsync(cancellationToken);
            if (data is null)
                return Enumerable.Empty<ProductGetAllView>().ToList();
            return UtilitiesServices.MapperFacade.Map<ProductEntity, ProductGetAllView>(data.ToList());
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
        CreateMap<ProductEntity, ProductGetAllView>().ReverseMap();
    }
}


