using System.ComponentModel.DataAnnotations;

namespace AngularApp.Core.Domain.Entities.Security.User;

[Table("UserRoles", Schema = "Security")]
public class UserRoleEntity : IdentityUserRole<long>, IAuditableEntity<long>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public Guid EntityId { get; set; } = Guid.NewGuid();

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
