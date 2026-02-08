using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Application.Aggregates.Security.Users.Models.Views;

public class UserView : BaseView, IMapFrom<UserEntity>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserEntity, UserView>();
    }
}
