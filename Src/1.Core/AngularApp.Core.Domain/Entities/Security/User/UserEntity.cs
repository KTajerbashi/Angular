using AngularApp.Core.Domain.Entities.Security.Group;
using AngularApp.Core.Domain.Entities.Security.Privilege;

namespace AngularApp.Core.Domain.Entities.Security.User;

[Table("Users", Schema = "Security")]
public class UserEntity : IdentityUser<long>, IAggregate<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public Guid EntityId { get; set; }

    /// <summary>
    /// لیست 
    /// Event
    /// های مربوطه را نگهداری می‌کند        
    /// </summary>
    private readonly List<IDomainEvent> _events;
    protected UserEntity() => _events = new();
    protected void AddEvent(IDomainEvent @event) => _events.Add(@event);
    public void ClearEvents() => _events.Clear();
    public IEnumerable<IDomainEvent> GetEvents() => _events.AsEnumerable();

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


    private List<UserPrivilegeEntity> _userPrivileges = new();
    public IReadOnlyCollection<UserPrivilegeEntity> UserPrivileges => _userPrivileges;

    private List<GroupUserEntity> _groupUsers = new();
    public IReadOnlyCollection<GroupUserEntity> GroupUsers => _groupUsers;
}


