using Angular.DomainLibrary.BaseDomain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular.DomainLibrary.Identity;

[Table("UserRoles", Schema = "Identity")]
public class UserRoleEntity : IdentityUserRole<int>, IAuditableEntity<int>
{
    public int Id { get; private set; }

    public Guid KeyRecord { get; private set; }
    public DateTime CreateDate { get; private set; }

    public int CreatedByUserId { get; private set; }

    public DateTime? UpdateDate { get; private set; }

    public int? UpdateByUserId { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsDeleted { get; private set; }

    public void Delete() => IsDeleted = true;
    public void Acive() => IsActive = true;
    public void DisActive() => IsActive = false;
    public void UndoDelete() => IsDeleted = false;
    public void DeleteRecord()
    {
        IsDeleted = true;
        IsActive = false;
    }

    public void Create(int userId, int roleId, bool isActive)
    {
        UserId = userId;
        RoleId = roleId;
        IsActive = isActive;
    }

}
