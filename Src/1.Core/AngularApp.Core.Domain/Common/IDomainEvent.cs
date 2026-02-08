namespace AngularApp.Core.Domain.Common;

public interface IDomainEvent : INotification
{
    Guid EntityId { get; set; }
}

public abstract class DomainEvent : IDomainEvent
{
    public Guid EntityId { get ; set ; }

    protected DomainEvent(Guid entityId)
    {
        EntityId = entityId;
    }
}