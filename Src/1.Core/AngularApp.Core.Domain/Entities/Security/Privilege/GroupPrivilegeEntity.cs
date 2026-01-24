using AngularApp.Core.Domain.Entities.Security.Group;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("GroupPrivileges", Schema = "Security")]
public class GroupPrivilegeEntity : Entity<long>
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long PrivilegeId { get; set; }
    public PrivilegeEntity PrivilegeEntity { get; set; }


    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; set; }
    public GroupEntity GroupEntity { get; set; }
}
