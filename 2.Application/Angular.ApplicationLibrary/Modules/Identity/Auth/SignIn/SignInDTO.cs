using Angular.ApplicationLibrary.BaseApplication.DTO;

namespace Angular.ApplicationLibrary.Modules.Identity.Auth.SignIn;

public class SignInDTO : BaseDTO
{

}
public class SignInCommand : Command
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public string PhoneNumber { get; set; }
}