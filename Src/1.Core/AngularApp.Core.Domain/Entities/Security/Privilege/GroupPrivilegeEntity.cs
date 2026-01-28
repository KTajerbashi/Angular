using AngularApp.Core.Domain.Entities.Security.Group;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("GroupPrivileges", Schema = "Security")]
public class GroupPrivilegeEntity : Entity<long>
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long PrivilegeId { get; private set; }
    public PrivilegeEntity PrivilegeEntity { get; private set; }


    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; private set; }
    public GroupEntity GroupEntity { get; private set; }
}
