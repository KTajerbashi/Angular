using Angular_WebApi.ApplicationBases.Models;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Commands.CreateUser;

public class UserCreateCommand : Command<long>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
