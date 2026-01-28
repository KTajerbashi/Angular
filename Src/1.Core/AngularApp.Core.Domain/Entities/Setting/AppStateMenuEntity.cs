namespace AngularApp.Core.Domain.Entities.Setting;

[Table("AppStateMenus", Schema = "Setting")]
public class AppStateMenuEntity : AggregateRoot
{
    [ForeignKey(nameof(AppStateEntity))]
    public long AppStateId { get; private set; }
    public AppStateEntity AppStateEntity { get; private set; }


    [ForeignKey(nameof(MenuEntity))]
    public long MenuId { get; private set; }
    public MenuEntity MenuEntity { get; private set; }
}


