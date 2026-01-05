
namespace AngularApp.Core.Domain.Entities.Store;

[Table("Products", Schema = "Store")]
public class ProductEntity : AggregateRoot<long>
{
    private readonly List<ProductDetailEntity> _details = new();

    public string Name { get; private set; }

    public IReadOnlyCollection<ProductDetailEntity> Details => _details.AsReadOnly();

    protected ProductEntity() { }

    public ProductEntity(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    // Aggregate behavior
    public void AddDetail(string key, string value)
    {
        if (_details.Any(d => d.Key == key))
            throw new DomainException($"Detail '{key}' already exists");

        _details.Add(new ProductDetailEntity(key, value));
    }

    public void RemoveDetail(long detailId)
    {
        var detail = _details.SingleOrDefault(x => x.Id == detailId)
            ?? throw new DomainException("Detail not found");

        _details.Remove(detail);
    }
}
