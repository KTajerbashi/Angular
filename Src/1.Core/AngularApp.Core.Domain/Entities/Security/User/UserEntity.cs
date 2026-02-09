using AngularApp.Core.Domain.Entities.Security.Group;
using AngularApp.Core.Domain.Entities.Security.Privilege;
using AngularApp.Core.Domain.Entities.Security.User.Parameters;

namespace AngularApp.Core.Domain.Entities.Security.User;

[Table("Users", Schema = "Security")]
public class UserEntity : IdentityUser<long>, IAggregate<long>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string DisplayName { get; private set; }

    public bool IsDeleted { get; private set; }

    public bool IsActive { get; private set; }

    public Guid EntityId { get; private set; } = Guid.NewGuid();
    public bool IsOnline { get; private set; }

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


    public void Update(UserUpdateParameter parameter)
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
    public virtual IReadOnlyCollection<UserPrivilegeEntity> UserPrivileges => _userPrivileges;

    private List<UserRoleEntity> _userRoles = new();
    public virtual IReadOnlyCollection<UserRoleEntity> UserRoles => _userRoles;

    private List<GroupUserEntity> _groupUsers = new();
    public virtual IReadOnlyCollection<GroupUserEntity> GroupUsers => _groupUsers;
}


