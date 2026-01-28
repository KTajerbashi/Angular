using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("UserRolePrivileges", Schema = "Security")]
public class UserRolePrivilegeEntity : Entity<long>
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long PrivilegeId { get; private set; }
    public PrivilegeEntity PrivilegeEntity { get; private set; }


    [ForeignKey(nameof(UserRoleEntity))]
    public long UserRoleId { get; private set; }

}
