using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular.DomainLibrary.Identity;

[Table("UserClaims", Schema = "Identity")]
public class UserClaimEntity : IdentityUserClaim<int>
{
}
