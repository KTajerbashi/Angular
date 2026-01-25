namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("GroupUserRoles", Schema = "Security")]
public class GroupUserRoleEntity : Entity<long>
{
    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; set; }
    public GroupEntity GroupEntity { get; set; }

    public long UserRoleId { get; set; }
}