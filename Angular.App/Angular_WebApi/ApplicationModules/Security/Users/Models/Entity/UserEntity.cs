using Angular_WebApi.ApplicationBases.Models;
using Microsoft.AspNetCore.Identity;

namespace Angular_WebApi.ApplicationModules.Security.Users.Models.Entity;

public class UserEntity : IdentityUser<long>, IBaseEntity<long>
{
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}