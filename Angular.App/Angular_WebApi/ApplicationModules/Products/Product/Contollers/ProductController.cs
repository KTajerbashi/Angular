using Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Queries.GetAll;
using Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Queries.GetAll;
using Angular_WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Products.Product.Contollers;

public class ProductController : AuthController
{
    public ProductController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> ReadAll()
        => await QueryList<ProductGetAllQuery, ProductGetAllView>(new ProductGetAllQuery());

    [HttpGet("{id}")]
    public async Task<IActionResult> Read()
    {
        return Ok(true);
    }

}
