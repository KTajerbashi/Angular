using AngularApp.Core.Domain.Entities.Security.Privilege;

namespace AngularApp.Core.Domain.Entities.Setting;

[Table("Menus", Schema = "Setting")]
public class MenuEntity : AggregateRoot
{
    [ForeignKey(nameof(MenuEntity))]
    public long? ParentId { get; private set; }
    public virtual IReadOnlyCollection<MenuEntity> Children { get; private set; }
    public virtual MenuEntity Parent { get; private set; }

    public string Title { get; private set; }
    public string Schema { get; private set; }


    private List<MenuPrivilegeEntity> _menuPrivileges = new();
    public IReadOnlyCollection<MenuPrivilegeEntity> MenuPrivilegeEntity => _menuPrivileges;

    private List<AppStateMenuEntity> _appStateMenuEntity = new();
    public IReadOnlyCollection<AppStateMenuEntity> AppStateMenuEntity => _appStateMenuEntity;
}


