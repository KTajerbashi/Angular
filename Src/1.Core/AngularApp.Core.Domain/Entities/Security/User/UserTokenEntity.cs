namespace AngularApp.Core.Domain.Entities.Security.User;

[Table("UserTokens", Schema = "Security")]
public class UserTokenEntity : IdentityUserToken<long>, IAuditableEntity<long>
{
    public long Id { get; private set; }
    public bool IsDeleted { get; private set; }

    public bool IsActive { get; private set; }

    public Guid EntityId { get; private set; } = Guid.NewGuid();

    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }

    public void Restore()
    {
        IsActive = true;
        IsDeleted = false;
    }
}
