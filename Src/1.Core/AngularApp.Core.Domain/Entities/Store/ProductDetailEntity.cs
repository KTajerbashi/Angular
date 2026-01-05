
namespace AngularApp.Core.Domain.Entities.Store;

[Table("ProductDetails", Schema = "Store")]
public class ProductDetailEntity : AuditableEntity<long>
{
    public string Key { get; private set; }
    public string Value { get; private set; }

    public long ProductId { get; private set; }
    public ProductEntity Product { get; private set; }

    protected ProductDetailEntity() { }

    internal ProductDetailEntity(string key, string value)
    {
        Key = key;
        Value = value;
    }
}
