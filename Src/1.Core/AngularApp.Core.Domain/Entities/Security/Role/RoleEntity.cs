using AngularApp.Core.Domain.Entities.Security.Privilege;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Domain.Entities.Security.Role;

[Table("Roles", Schema = "Security")]
public class RoleEntity : IdentityRole<long>, IAggregate<long>
{
    public bool IsDeleted { get; private set; }

    public bool IsActive { get; private set; }

    public Guid EntityId { get; private set; } = Guid.NewGuid();

    /// <summary>
    /// لیست 
    /// Event
    /// های مربوطه را نگهداری می‌کند        
    /// </summary>
    private readonly List<IDomainEvent> _events;
    protected RoleEntity() => _events = new();
    protected void AddEvent(IDomainEvent @event) => _events.Add(@event);
    public void ClearEvents() => _events.Clear();
    public IEnumerable<IDomainEvent> GetEvents() => _events.AsEnumerable();
    public RoleEntity(string name)
    {
        Name = name;
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

    private List<RolePrivilegeEntity> _rolePrivileges = new();
    public IReadOnlyCollection<RolePrivilegeEntity> RolePrivileges => _rolePrivileges;

    private List<UserRoleEntity> _userRoles = new();
    public IReadOnlyCollection<UserRoleEntity> UserRoles => _userRoles;
}
