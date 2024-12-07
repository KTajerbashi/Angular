using Angular_WebApi.ApplicationBases.Models;

namespace Angular_WebApi.ApplicationModules.Security.Users.Models.Views;

public class UserView : BaseView
{
    public UserView()
    {
        var random = new Random();
        if (Id == 0)
            Id = random.Next(1, 100);
    }
    public string Name { get; set; }
    public string Family { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
