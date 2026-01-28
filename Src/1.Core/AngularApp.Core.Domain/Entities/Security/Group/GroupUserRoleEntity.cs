namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("GroupUserRoles", Schema = "Security")]
public class GroupUserRoleEntity : Entity<long>
{
    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; private set; }
    public GroupEntity GroupEntity { get; private set; }

    public long UserRoleId { get; private set; }
}