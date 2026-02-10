using AngularApp.Core.Application.UseCases.Security.Users.Handlers.Add;
using AngularApp.Core.Application.UseCases.Security.Users.Handlers.Update;
using AngularApp.Core.Domain.Entities.Security.User.Parameters;

namespace AngularApp.Core.Application.UseCases.Security.Users.MapProfile;

public class UserAggregateProfile : Profile
{
    public UserAggregateProfile()
    {
        CreateMap<AddCommand, UserCreateParameter>().ReverseMap();
        CreateMap<UpdateCommand, UserUpdateParameter>().ReverseMap();
    }
}