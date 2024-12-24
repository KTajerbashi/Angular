using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
[Table("Users", Schema = "Identity")]
public class UserEntity : IdentityUser<long>, IBaseEntity<long>
{
    public string Name { get; set; }
    public string Family { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool IsOnline { get; set; }
    public UserEntity()
    {
        IsDeleted = false;
        IsActive = true;
    }
    public UserEntity(UserCreateCommand command)
    {
        Name = command.Name;
        Family = command.Family;
        Email = command.Email;
        PhoneNumber = command.PhoneNumber;
        UserName = command.UserName;
    }
    public void ChangeOnline() => IsOnline = !IsOnline;
}

