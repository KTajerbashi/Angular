using AngularApp.EndPoint.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp.EndPoint.WebApi.Controllers.Store;

public class Database
{
    public Database()
    {
        Products = new List<ProductDTO>();
        Products.Add(new ProductDTO(1, "IPhone X", 1000, 3));
        Products.Add(new ProductDTO(2, "IPhone XS", 1100, 1));
        Products.Add(new ProductDTO(3, "IPhone XS Max", 1200, 2));
        Products.Add(new ProductDTO(4, "IPhone 11", 1300, 3));
        Products.Add(new ProductDTO(5, "IPhone 11 Pro", 1400, 4));
        Products.Add(new ProductDTO(6, "IPhone 11 Pro Max", 1500, 5));
        Products.Add(new ProductDTO(7, "IPhone 12", 1600, 1));
        Products.Add(new ProductDTO(8, "IPhone 12 Pro", 1700, 2));
        Products.Add(new ProductDTO(9, "IPhone 12 Pro Max", 1800, 4));
        Products.Add(new ProductDTO(10, "IPhone 13", 1900, 3));
    }
    public static List<ProductDTO> Products { get; set; }

    public static void Update(ProductDTO parameters)
    {
        var index = Products.IndexOf(parameters);
        Products[index] = parameters;
    }
    public static void Delete(long id)
    {
        var entity = Products.Single(i => i.Id == id);
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
        Database.Products.Add(parameters);
        return Ok(Database.Products.ToList());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(long id)
    {
        await Task.CompletedTask;
        Database.Delete(id);
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
        return Ok(Database.Products.ToList());
    }

    [HttpGet("Reload")]
    public async Task<IActionResult> Reload()
    {
        await Task.CompletedTask;
        Database data = new Database();
        return Ok(Database.Products.ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        await Task.CompletedTask;
        return Ok(Database.Products.Single(item => item.Id == id));
    }

}
