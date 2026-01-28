using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("UserPrivileges", Schema = "Security")]
public class UserPrivilegeEntity : Entity<long>
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long PrivilegeId { get; private set; }
    public PrivilegeEntity PrivilegeEntity { get; private set; }

    [ForeignKey(nameof(UserEntity))]
    public long UserId { get; private set; }
    public UserEntity UserEntity { get; private set; }
}
