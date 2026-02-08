using AngularApp.Core.Application.Aggregates.Security.Users.Handlers.Add;
using AngularApp.Core.Domain.Entities.Security.User.Parameters;

namespace AngularApp.Core.Application.Aggregates.Security.Users.MapProfile;


public class UserAggregateProfile : Profile
{
    public UserAggregateProfile()
    {
        CreateMap<UserAddCommand, UserCreateParameter>().ReverseMap();
    }
}