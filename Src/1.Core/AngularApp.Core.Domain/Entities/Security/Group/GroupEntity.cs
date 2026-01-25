using AngularApp.Core.Domain.Entities.Security.Privilege;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("Groups", Schema = "Security")]
public class GroupEntity : AggregateRoot
{
    public string Title { get; set; }
    public string Key { get; set; }

    private List<GroupPrivilegeEntity> _groupPrivileges = new();
    public IReadOnlyCollection<GroupPrivilegeEntity> GroupPrivileges => _groupPrivileges;

    private List<GroupUserRoleEntity> _groupUserRoles = new();
    public IReadOnlyCollection<GroupUserRoleEntity> GroupUserRoles => _groupUserRoles;
  
    private List<GroupUserEntity> _groupUsers = new();
    public IReadOnlyCollection<GroupUserEntity> GroupUsers => _groupUsers;
  
    private List<GroupRoleEntity> _groupRoles = new();
    public IReadOnlyCollection<GroupRoleEntity> GroupRoles => _groupRoles;
}
