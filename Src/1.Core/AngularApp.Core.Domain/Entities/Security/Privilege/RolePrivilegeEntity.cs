using AngularApp.Core.Domain.Entities.Security.Role;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("RolePrivileges", Schema = "Security")]
public class RolePrivilegeEntity : Entity<long>
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long PrivilegeId { get; set; }
    public PrivilegeEntity PrivilegeEntity { get; set; }


    [ForeignKey(nameof(RoleEntity))]
    public long RoleId { get; set; }
    public RoleEntity RoleEntity { get; set; }
}
