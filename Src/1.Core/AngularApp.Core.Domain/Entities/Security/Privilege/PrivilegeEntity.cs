using AngularApp.Core.Domain.Entities.Security.Group;
using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.Core.Domain.Enums.Security;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("Privileges", Schema = "Security")]
public class PrivilegeEntity : AggregateRoot
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long? ParentId { get; set; }
    // Navigation to parent
    public PrivilegeEntity Parent { get; set; }

    private List<PrivilegeEntity> _children = new();
    public IReadOnlyCollection<PrivilegeEntity> Children => _children;

    public string EntityName { get; set; }
    public string Action { get; set; }
    public string Title { get; set; }
    public PrivilegeType Type { get; set; }
    public string Command { get; set; }
    public byte Order { get; set; }

    private List<UserPrivilegeEntity> _userPrivileges = new();
    public IReadOnlyCollection<UserPrivilegeEntity> UserPrivileges => _userPrivileges;

    private List<UserRolePrivilegeEntity> _userRolePrivileges = new();
    public IReadOnlyCollection<UserRolePrivilegeEntity> UserRolePrivileges => _userRolePrivileges;

    private List<RolePrivilegeEntity> _rolePrivileges = new();
    public IReadOnlyCollection<RolePrivilegeEntity> RolePrivileges => _rolePrivileges;

    private List<GroupPrivilegeEntity> _groupPrivileges = new();
    public IReadOnlyCollection<GroupPrivilegeEntity> GroupPrivileges => _groupPrivileges;

    private List<MenuPrivilegeEntity> _menuPrivileges = new();
    public IReadOnlyCollection<MenuPrivilegeEntity> MenuPrivilegeEntity => _menuPrivileges;
}
