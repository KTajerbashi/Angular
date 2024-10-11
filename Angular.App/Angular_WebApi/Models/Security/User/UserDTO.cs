using Angular_WebApi.Models.BaseModels;

namespace Angular_WebApi.Models.Security.User;

public class UserDTO : BaseDTO
{
    public string Name{ get; set; }
    public string Family{ get; set; }
    public string Phone { get; set; }
    public string  Email { get; set; }
}
