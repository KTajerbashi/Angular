using Angular_WebApi.ApplicationBases.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;

[Table("UserClaims", Schema = "Identity")]
public class UserClaimEntity : IdentityUserClaim<long>, IBaseEntity<int>
{
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}
