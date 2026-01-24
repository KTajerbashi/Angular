namespace AngularApp.Core.Domain.Entities.Setting;

[Table("AppStateMenus", Schema = "Setting")]
public class AppStateMenuEntity : AggregateRoot
{
    [ForeignKey(nameof(AppStateEntity))]
    public long AppStateId { get; set; }
    public AppStateEntity AppStateEntity { get; set; }


    [ForeignKey(nameof(MenuEntity))]
    public long MenuId { get; set; }
    public MenuEntity MenuEntity { get; set; }
}


