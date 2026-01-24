using AngularApp.Core.Domain.Entities.Security.Privilege;

namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("Groups", Schema = "Security")]
public class GroupEntity : AggregateRoot
{
    public string Title { get; set; }
    public string Key { get; set; }

    private List<GroupPrivilegeEntity> _groupPrivileges = new();
    public IReadOnlyCollection<GroupPrivilegeEntity> GroupPrivileges => _groupPrivileges;

    private List<UserRoleGroupEntity> _userRoleGroups = new();
    public IReadOnlyCollection<UserRoleGroupEntity> UserRoleGroups => _userRoleGroups;


}

[Table("UserRoleGroups", Schema = "Security")]
public class UserRoleGroupEntity : Entity<long>
{
    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; set; }
    public GroupEntity GroupEntity { get; set; }

    public long UserRoleId { get; set; }
}