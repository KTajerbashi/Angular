using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("UserRolePrivileges", Schema = "Security")]
public class UserRolePrivilegeEntity : Entity<long>
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long PrivilegeId { get; set; }
    public PrivilegeEntity PrivilegeEntity { get; set; }


    [ForeignKey(nameof(UserRoleEntity))]
    public long UserRoleId { get; set; }

}
