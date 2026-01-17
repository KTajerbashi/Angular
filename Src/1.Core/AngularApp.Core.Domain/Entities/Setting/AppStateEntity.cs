namespace AngularApp.Core.Domain.Entities.Setting;

[Table("AppStates", Schema = "Setting")]
public class AppStateEntity : AggregateRoot
{
    public string Key { get; set; }
    public string Title { get; set; }
    public string Schema { get; set; }
}


