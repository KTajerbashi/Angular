namespace AngularApp.Core.Domain.Entities.Security.User.Parameters;

public class UserCreateParameter : BaseParameter
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual bool EmailConfirmed { get; set; }
    public virtual bool PhoneNumberConfirmed { get; set; }
}
