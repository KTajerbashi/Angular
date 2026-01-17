namespace AngularApp.Core.Domain.Entities.Setting;

[Table("Menus", Schema = "Setting")]
public class MenuEntity : AggregateRoot
{
    [ForeignKey(nameof(MenuEntity))]
    public long? ParentId { get; set; }
    public virtual MenuEntity Children { get; set; }

    public string Title { get; set; }
    public string Schema { get; set; }
}


