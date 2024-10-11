using Angular_WebApi.Controllers.BaseControllers;
using Angular_WebApi.Models.Security.User;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.Controllers.Security;

public class UserController : AuthController
{
    public override async Task<IActionResult> Index()
    {
        return Ok("");
    }

    [HttpGet("Read")]
    public async Task<IActionResult> ReadAll()
    {
        var result = new List<UserDTO>();
        result.Add(new UserDTO { Id = 1,Name="Kamran",Family="Tajerbashi",Phone="09011001233",Email="Kamran@mail.com"});
        result.Add(new UserDTO { Id = 2,Name="Reza",Family="Attaii",Phone="0323238923",Email="Reza@mail.com"});
        result.Add(new UserDTO { Id = 3,Name="Javad",Family="Karimi",Phone="234234",Email="Javad@mail.com"});
        result.Add(new UserDTO { Id = 4,Name="Sharif",Family="Amini",Phone="234234234",Email="Sharif@mail.com"});
        result.Add(new UserDTO { Id = 5,Name="Mohammad",Family="Mahamoudi",Phone="2342342342342",Email="Mohammad@mail.com"});
        result.Add(new UserDTO { Id = 6,Name="Mashoud",Family="Kaboudany",Phone="23424352656456",Email="Mashood@mail.com" });
        return await Task.FromResult(Ok(result));
    }
}
