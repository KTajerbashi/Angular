using AngularApp.Core.Domain.Entities.Security.Role;
using System.ComponentModel.DataAnnotations;

namespace AngularApp.Core.Domain.Entities.Security.User;

[Table("UserRoles", Schema = "Security")]
public class UserRoleEntity : IdentityUserRole<long>, IAuditableEntity<long>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
    public Guid EntityId { get; private set; } = Guid.NewGuid();
    public virtual UserEntity User { get; private set; } = null!;
    public virtual RoleEntity Role { get; private set; } = null!;

    public bool IsDefault { get; private set; }
    public string Description { get; private set; }

    public static UserRoleEntity CreateInstance(long id, long userId, long roleId)
    {
        return new()
        {
            Id = id,
            UserId = userId,
            RoleId = roleId,
        };
    }
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
