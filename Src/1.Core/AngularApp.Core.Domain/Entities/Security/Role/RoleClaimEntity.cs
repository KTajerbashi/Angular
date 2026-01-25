namespace AngularApp.Core.Domain.Entities.Security.Role;

[Table("RoleClaims", Schema = "Security")]
[Description("Role Claim Entity Model")]
public class RoleClaimEntity : IdentityRoleClaim<long>
{
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