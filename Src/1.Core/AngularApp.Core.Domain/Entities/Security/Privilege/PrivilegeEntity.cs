using AngularApp.Core.Domain.Entities.Security.Enums;
using AngularApp.Core.Domain.Entities.Security.User;

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
}

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

[Table("UserRolePrivileges", Schema = "Security")]
public class UserRolePrivilegeEntity : Entity<long>
{

}

[Table("RolePrivileges", Schema = "Security")]
public class RolePrivilegeEntity : Entity<long>
{

}

[Table("GroupPrivileges", Schema = "Security")]
public class GroupPrivilegeEntity : Entity<long>
{

}

[Table("MenuPrivileges", Schema = "Security")]
public class MenuPrivilegeEntity : Entity<long>
{

}
