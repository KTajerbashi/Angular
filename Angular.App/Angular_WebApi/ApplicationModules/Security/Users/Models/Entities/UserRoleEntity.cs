using Angular_WebApi.ApplicationBases.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;

[Table("UserRoles", Schema = "Identity")]
public class UserRoleEntity : IdentityUserRole<long>, IBaseEntity<long>
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}
