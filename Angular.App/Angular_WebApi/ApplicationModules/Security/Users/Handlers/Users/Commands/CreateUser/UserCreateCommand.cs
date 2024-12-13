using Angular_WebApi.ApplicationBases.Models;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Commands.CreateUser;

public class UserCreateCommand : Command<long>
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public long? RoleId { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
