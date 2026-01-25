using AngularApp.Core.Domain.Entities.Security.Group;
using AngularApp.Core.Domain.Entities.Security.Privilege;
using AngularApp.Core.Domain.Entities.Security.User.Parameters;

namespace AngularApp.Core.Domain.Entities.Security.User;

[Table("Users", Schema = "Security")]
public class UserEntity : IdentityUser<long>, IAggregate<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public Guid EntityId { get; set; } = Guid.NewGuid();

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

    public UserEntity(UserCreateParameter parameter)
    {
        FirstName = parameter.FirstName;
        LastName = parameter.LastName;
        DisplayName = parameter.DisplayName;
        UserName = parameter.UserName;
        Email = parameter.Email;
        PhoneNumber = parameter.PhoneNumber;
        EmailConfirmed = parameter.EmailConfirmed;
        PhoneNumberConfirmed = parameter.PhoneNumberConfirmed;
    }

    private List<UserPrivilegeEntity> _userPrivileges = new();
    public IReadOnlyCollection<UserPrivilegeEntity> UserPrivileges => _userPrivileges;

    private List<GroupUserEntity> _groupUsers = new();
    public IReadOnlyCollection<GroupUserEntity> GroupUsers => _groupUsers;
}


