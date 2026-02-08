using AngularApp.Core.Domain.Common;

namespace AngularApp.Core.Application.Common.BaseApplication.Mediator.Event;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : DomainEvent
{

}
public abstract class DomainEventHandler<TEvent> : IDomainEventHandler<TEvent> where TEvent : DomainEvent
{
    protected readonly ProviderServices Provider;

    protected DomainEventHandler(ProviderServices provider)
    {
        Provider = provider;
    }
    public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);
}