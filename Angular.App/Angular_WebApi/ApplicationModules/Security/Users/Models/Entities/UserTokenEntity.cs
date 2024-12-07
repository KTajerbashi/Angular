using Angular_WebApi.ApplicationBases.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;

[Table("UserTokens", Schema = "Identity")]
public class UserTokenEntity : IdentityUserToken<long>, IBaseEntity<long>
{
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public long Id { get; set; }
}
