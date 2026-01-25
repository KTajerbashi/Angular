using AngularApp.Core.Domain.Entities.Security.Role;

namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("GroupRoles", Schema = "Security")]
public class GroupRoleEntity : Entity<long>
{
    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; set; }
    public GroupEntity GroupEntity { get; set; }


    [ForeignKey(nameof(RoleEntity))]
    public long RoleId { get; set; }
    public RoleEntity RoleEntity{ get; set; }
}