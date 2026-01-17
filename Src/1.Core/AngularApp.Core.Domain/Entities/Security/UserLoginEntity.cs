namespace AngularApp.Core.Domain.Entities.Security;

[Table("UserLogins", Schema = "Security")]
public class UserLoginEntity : IdentityUserLogin<long>, IAuditableEntity<long>
{
    public long Id { get; set; }
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
