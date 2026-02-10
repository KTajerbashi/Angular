using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Application.UseCases.Security.Users.Models.Views;

public class UserView : BaseView<UserEntity>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    public override void Mapping(Profile profile)
    {
    }
}
