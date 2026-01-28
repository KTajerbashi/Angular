namespace AngularApp.Core.Domain.Entities.Security.User;

[Table("UserClaims", Schema = "Security")]
public class UserClaimEntity : IdentityUserClaim<long>, IAuditableEntity<int>
{
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
