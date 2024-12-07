using Angular_WebApi.ApplicationBases.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;

[Table("RoleClaims", Schema = "Identity")]
public class RoleClaimEntity : IdentityRoleClaim<long>, IBaseEntity<int>
{
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}
