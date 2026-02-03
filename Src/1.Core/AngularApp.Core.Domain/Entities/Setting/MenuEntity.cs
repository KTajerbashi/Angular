using AngularApp.Core.Domain.Entities.Security.Privilege;
using System.Security;

namespace AngularApp.Core.Domain.Entities.Setting;

[Table("Menus", Schema = "Setting")]
public class MenuEntity : AggregateRoot
{
    [ForeignKey(nameof(MenuEntity))]
    public long? ParentId { get; private set; }
    public List<MenuEntity> _children = new();
    public virtual IReadOnlyCollection<MenuEntity> Children => _children;
    public virtual MenuEntity Parent { get; private set; }

    public string Title { get; private set; }
    public string Schema { get; private set; }

    public static MenuEntity CreateInstance(string schema, string title, long? parentId)
    {
        return new()
        {
            Schema = schema,
            Title = title,
            ParentId = parentId,
        };
    }

    public void AddChild(string title)
    {
        _children.Add(new MenuEntity { Title = title, Schema = Schema });
    }

    private List<MenuPrivilegeEntity> _menuPrivileges = new();
    public IReadOnlyCollection<MenuPrivilegeEntity> MenuPrivilegeEntity => _menuPrivileges;

    private List<AppStateMenuEntity> _appStateMenuEntity = new();
    public IReadOnlyCollection<AppStateMenuEntity> AppStateMenuEntity => _appStateMenuEntity;
}


