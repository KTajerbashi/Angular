
namespace AngularApp.Core.Domain.Entities.Store;

[Table("Categories", Schema = "Store")]
public class CategoryEntity : AggregateRoot<long>
{
    public string Title { get; private set; }

    protected CategoryEntity() { }

    public CategoryEntity(string title)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
    }

    public void Rename(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Category title is required");

        Title = title;
    }
}
