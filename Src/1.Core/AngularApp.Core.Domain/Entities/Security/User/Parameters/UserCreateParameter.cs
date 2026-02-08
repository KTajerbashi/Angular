namespace AngularApp.Core.Domain.Entities.Security.User.Parameters;

public class UserCreateParameter : BaseParameter
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public virtual bool EmailConfirmed { get; set; }
    public virtual bool PhoneNumberConfirmed { get; set; }
}
