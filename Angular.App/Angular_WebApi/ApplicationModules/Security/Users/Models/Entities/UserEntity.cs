using Angular_WebApi.ApplicationBases.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
[Table("Users", Schema = "Identity")]
public class UserEntity : IdentityUser<long>, IBaseEntity<long>
{
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}