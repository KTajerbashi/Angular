using Angular_WebApi.ApplicationBases.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;

[Table("Roles", Schema = "Identity")]
public class RoleEntity : IdentityRole<long>, IBaseEntity<long>
{
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }

}
