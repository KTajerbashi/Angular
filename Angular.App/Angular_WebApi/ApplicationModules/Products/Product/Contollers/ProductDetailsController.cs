using Angular_WebApi.Controllers.BaseControllers;
using MediatR;

namespace Angular_WebApi.ApplicationModules.Products.Product.Contollers;

public class ProductDetailsController : AuthController
{
    public ProductDetailsController(IMediator mediator) : base(mediator)
    {
    }
}
