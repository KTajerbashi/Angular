namespace AngularApp.Core.Domain.Entities.Security;

[Table("UserClaims", Schema = "Security")]
public class UserClaimEntity : IdentityUserClaim<long>, IAuditableEntity<int>
{
    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public Guid EntityId { get; set; }

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
