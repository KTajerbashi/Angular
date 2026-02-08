using AngularApp.Core.Application.Providers.UserState;
using AutoMapper;

namespace AngularApp.Core.Application.Providers;

public class ProviderServices
{
    public IUserState UserState;
    public IMediator Mediator;
    public INotificationPublisher NotificationPublisher;
    public IMapper Mapper;
    public ProviderServices(
        IUserState userState,
        IMediator mediator,
        INotificationPublisher notificationPublisher,
        IMapper mapper)
    {
        UserState = userState;
        Mediator = mediator;
        NotificationPublisher = notificationPublisher;
        Mapper = mapper;
    }
}
