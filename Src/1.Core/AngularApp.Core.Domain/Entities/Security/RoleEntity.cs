namespace AngularApp.Core.Domain.Entities.Security;

[Table("Roles", Schema = "Security")]
public class RoleEntity : IdentityRole<long>, IAuditableEntity<long>
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
