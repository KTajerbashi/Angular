using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApp.Core.Domain.Entities.Security;

[Table("Users", Schema = "Security")]
public class UserEntity : IdentityUser<long>
{
}
[Table("Roles", Schema = "Security")]
public class RoleEntity : IdentityRole<long>
{
}
[Table("UserRoles", Schema = "Security")]
public class UserRoleEntity : IdentityUserRole<long>
{
}
[Table("UserClaims", Schema = "Security")]
public class UserClaimEntity : IdentityUserClaim<long>
{
}
[Table("UserLogins", Schema = "Security")]
public class UserLoginEntity : IdentityUserLogin<long>
{
}
[Table("UserTokens", Schema = "Security")]
public class UserTokenEntity : IdentityUserToken<long>
{
}
[Table("RoleClaims", Schema = "Security")]
[Description("Role Claim Entity Model")]
public class RoleClaimEntity : IdentityRoleClaim<long>
{
}