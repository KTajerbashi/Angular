using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("UserPrivileges", Schema = "Security")]
public class UserPrivilegeEntity : Entity<long>
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long PrivilegeId { get; set; }
    public PrivilegeEntity PrivilegeEntity { get; set; }

    [ForeignKey(nameof(UserEntity))]
    public long UserId { get; set; }
    public UserEntity UserEntity { get; set; }
}
