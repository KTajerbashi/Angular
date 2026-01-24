using AngularApp.Core.Domain.Entities.Setting;

namespace AngularApp.Core.Domain.Entities.Security.Privilege;

[Table("MenuPrivileges", Schema = "Security")]
public class MenuPrivilegeEntity : Entity<long>
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long PrivilegeId { get; set; }
    public PrivilegeEntity PrivilegeEntity { get; set; }


    [ForeignKey(nameof(MenuEntity))]
    public long MenuId { get; set; }
    public MenuEntity MenuEntity { get; set; }
}
