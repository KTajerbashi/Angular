using Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Commands.Create;
using Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Commands.Delete;
using Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Commands.Update;
using Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Queries.GetAll;
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
        => await QueryListAsync<ProductGetAllQuery, ProductGetAllView>(new ProductGetAllQuery());

    [HttpGet("{id}")]
    public async Task<IActionResult> Read()
        => await QueryListAsync<ProductGetAllQuery, ProductGetAllView>(new ProductGetAllQuery());

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateCommand command)
        => await CreateAsync(command);

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, ProductUpdateCommand command)
        => await CreateAsync(command);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
        => await DeleteAsync(new ProductDeleteCommand(id));

}
