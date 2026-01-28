namespace AngularApp.Core.Domain.Entities.Setting;

[Table("AppStates", Schema = "Setting")]
public class AppStateEntity : AggregateRoot
{
    public string Key { get; private set; }
    public string Title { get; private set; }
    public string Schema { get; private set; }

    private List<AppStateMenuEntity> _appStateMenuEntity = new();
    public IReadOnlyCollection<AppStateMenuEntity> AppStateMenuEntity => _appStateMenuEntity;
}


