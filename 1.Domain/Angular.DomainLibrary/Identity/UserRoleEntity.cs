using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular.DomainLibrary.Identity;

[Table("UserRoles", Schema = "Identity")]
public class UserRoleEntity : IdentityUserRole<int>
{
}
