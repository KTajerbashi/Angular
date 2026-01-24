namespace AngularApp.Core.Domain.Entities.Security.Role;

[Table("Roles", Schema = "Security")]
public class RoleEntity : IdentityRole<long>, IAggregate<long>
{
    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public Guid EntityId { get; set; }

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
