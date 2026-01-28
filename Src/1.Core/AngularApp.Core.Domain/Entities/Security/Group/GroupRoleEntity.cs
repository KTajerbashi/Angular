using AngularApp.Core.Domain.Entities.Security.Role;

namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("GroupRoles", Schema = "Security")]
public class GroupRoleEntity : Entity<long>
{
    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; private set; }
    public GroupEntity GroupEntity { get; private set; }


    [ForeignKey(nameof(RoleEntity))]
    public long RoleId { get; private set; }
    public RoleEntity RoleEntity{ get; private set; }
}