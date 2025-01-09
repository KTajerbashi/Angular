using Angular.ApplicationLibrary.BaseApplication.DTO;

namespace Angular.ApplicationLibrary.Modules.Identity.Auth.Login
{
    public class LoginDTO : BaseDTO
    {
    }

    public class LoginCommand : Command
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool IsRemember { get; set; }
    }

}
