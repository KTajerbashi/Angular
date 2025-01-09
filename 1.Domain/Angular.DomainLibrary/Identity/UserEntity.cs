using Angular.DomainLibrary.BaseDomain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular.DomainLibrary.Identity;

[Table("Users", Schema = "Identity")]
public class UserEntity : IdentityUser<int>, IAuditableEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

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

    private UserEntity()
    {
        
    }

    public UserEntity(string displayName = "", string description = "")
    {
        KeyRecord = Guid.NewGuid();
        DisplayName = displayName;
        IsDeleted = false;
        IsActive = true;
    }

}
