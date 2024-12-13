using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.Utilities.Extensions;


namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Queries.GetAll;

public class UserGetAllDTO : BaseView
{
    public string UserName { get; set; }
    public string NormalizedUserName { get; set; }
    public string Email { get; set; }
    public string NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityStamp { get; set; }
    public string ConcurrencyStamp { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public string TwoFactorEnabled { get; set; }
    public DateTime? LockoutEnd { get; set; }
    public string LockoutEndPersian { get => LockoutEnd.ToPersianDateTextify(); }
    public bool? LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    public string Family { get; set; }
    public string Name { get; set; }
}
