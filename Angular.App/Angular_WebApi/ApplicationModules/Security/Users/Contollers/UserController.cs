using Angular_WebApi.ApplicationModules.Security.Users.Models.DTOs;
using Angular_WebApi.ContextDB;
using Angular_WebApi.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Users.Contollers;

public class UserController : AuthController
{

    public UserController()
    {

    }
    public override async Task<IActionResult> Index()
    {
        return Ok("");
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDTO model)
    {
        DatabaseContext.SetUser(model);
        return Ok(true);
    }
    [HttpGet("Read")]
    public async Task<IActionResult> ReadAll()
    {
        return Ok(DatabaseContext.GetUsers());
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var model = DatabaseContext.GetUsers().Where(item => item.Id == id).FirstOrDefault();
        if (model != null)
            DatabaseContext.RemoveUser(model);
        return Ok(true);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UserDTO model)
    {
        var result = DatabaseContext.GetUsers().Where(item => item.Id == id).FirstOrDefault();
        if (result != null)
        {
            DatabaseContext.RemoveUser(result);
            DatabaseContext.SetUser(model);
        }
        return Ok(true);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Read(long id)
    {
        var result = DatabaseContext.GetUsers().Where(item => item.Id == id).FirstOrDefault();
        return Ok(result);
    }
}
