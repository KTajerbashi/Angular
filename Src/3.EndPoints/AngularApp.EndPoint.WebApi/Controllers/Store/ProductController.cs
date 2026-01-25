using AngularApp.EndPoint.WebApi.Controllers.Common;
using AngularApp.EndPoint.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.EndPoint.WebApi.Controllers.Store;

public class Database
{
    public Database()
    {
        Products = new List<ProductDTO>();
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone X", 1000, 3));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone XS", 1100, 1));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone XS Max", 1200, 2));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone 11", 1300, 3));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone 11 Pro", 1400, 4));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone 11 Pro Max", 1500, 5));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone 12", 1600, 1));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone 12 Pro", 1700, 2));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone 12 Pro Max", 1800, 4));
        Products.Add(new ProductDTO(Guid.NewGuid(), "IPhone 13", 1900, 3));
    }
    public static List<ProductDTO> Products { get; set; }

    public static void Update(ProductDTO parameters)
    {
        var entity = Products.Single(item => item.Key == parameters.Key);
        var index = Products.IndexOf(entity);
        Products[index] = parameters;
    }
    public static void Delete(Guid id)
    {
        var entity = Products.Single(i => i.Key == id);
        Products.Remove(entity);
    }
}
public class ProductController : AuthController
{
    public ProductController()
    {
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(ProductDTO parameters)
    {
        await Task.CompletedTask;

        Database.Products.Add(new(Guid.NewGuid(), parameters.Title, parameters.Price, parameters.Rate));
        return Ok(Database.Products.ToList());
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> RemoveAsync(Guid key)
    {
        await Task.CompletedTask;
        Database.Delete(key);
        return Ok(Database.Products.ToList());
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(ProductDTO parameters)
    {
        await Task.CompletedTask;
        Database.Update(parameters);
        return Ok(Database.Products.ToList());
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        await Task.CompletedTask;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        var headers = HttpContext.Request.Headers;
        await this.Reload();
        return Ok(Database.Products.ToList());
    }

    [HttpGet("Reload")]
    public async Task<IActionResult> Reload()
    {
        await Task.CompletedTask;
        Database data = new Database();
        var headers = HttpContext.Request.Headers;
        return Ok(Database.Products.ToList());
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetByIdAsync(Guid key)
    {
        await Task.CompletedTask;
        return Ok(Database.Products.Single(item => item.Key == key));
    }

}
