using AngularApp.Core.Domain.Entities.Security.Privilege;

namespace AngularApp.Core.Domain.Entities.Setting;

[Table("Menus", Schema = "Setting")]
public class MenuEntity : AggregateRoot
{
    [ForeignKey(nameof(MenuEntity))]
    public long? ParentId { get; set; }
    public virtual IReadOnlyCollection<MenuEntity> Children { get; set; }
    public virtual MenuEntity Parent { get; set; }

    public string Title { get; set; }
    public string Schema { get; set; }


    private List<MenuPrivilegeEntity> _menuPrivileges = new();
    public IReadOnlyCollection<MenuPrivilegeEntity> MenuPrivilegeEntity => _menuPrivileges;

    private List<AppStateMenuEntity> _appStateMenuEntity = new();
    public IReadOnlyCollection<AppStateMenuEntity> AppStateMenuEntity => _appStateMenuEntity;
}


