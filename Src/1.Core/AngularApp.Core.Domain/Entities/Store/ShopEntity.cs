
namespace AngularApp.Core.Domain.Entities.Store;

[Table("Shop", Schema = "Store")]
public class ShopEntity : AggregateRoot<long>
{
    public string Name { get; private set; }

    protected ShopEntity() { }

    public ShopEntity(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}