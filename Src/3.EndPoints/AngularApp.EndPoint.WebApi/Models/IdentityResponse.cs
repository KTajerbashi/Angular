using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.Core.Domain.Enums.Security;

namespace AngularApp.EndPoint.WebApi.Models;

public class IdentityResponse : BaseIdentityModel
{
    public UserEntity User { get; set; }
    public RoleEntity Role { get; set; }
    public List<RoleEntity> Roles { get; set; }
    public UserRoleEntity UserRole { get; set; }
    public List<UserRoleEntity> UserRoles { get; set; }
}


public class UserModel : BaseIdentityModel
{
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
}
public class RoleModel : BaseIdentityModel
{
    public string Name { get; set; }
}
public class UserRoleModel : BaseIdentityModel
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
}
public class GroupModel : BaseIdentityModel
{
    public string Title { get; set; }
    public string Key { get; set; }
}
public class MenuModel : BaseIdentityModel
{
    public string Title { get; set; }
    public string Schema { get; set; }
    public List<MenuModel> Children { get; set; }
}
public class PrivielgeModel : BaseIdentityModel
{
    public string ParentId { get; set; }
    public string EntityName { get; set; }
    public string Action { get; set; }
    public string Title { get; set; }
    public PrivilegeType Type { get; set; }
    public string Command { get; set; }
    public byte Order { get; set; }
    public List<PrivielgeModel> Children { get; set; }
}

public class IdentityProfileResponse : BaseIdentityModel
{
    public UserModel User { get; set; }
    public void BuildUser()
    {
        User = new UserModel()
        {
            Username = "Kamran_Tajerbashi",
            DisplayName = "Kamran Tajerbashi",
            Email = "kamrantajerbashi@mail.com",
            ErrorMessages = new(),
            IsSuccess = true,
            Message = "Successfully ..."
        };
    }

    public RoleModel Role { get; set; }
    public void BuildRole()
    {
        Role = new RoleModel()
        {
            Name = "ADMIN",
            ErrorMessages = new(),
            IsSuccess = true,
            Message = "Successfully ..."
        };
    }
    public List<RoleModel> Roles { get; set; }
    public void BuildRoles()
    {
        Roles = new List<RoleModel>();
        Roles.Add(new RoleModel() { Name = "ADMIN", IsSuccess = true, Message = "Successfully ...", ErrorMessages = new() });
        Roles.Add(new RoleModel() { Name = "USER", IsSuccess = true, Message = "Successfully ...", ErrorMessages = new() });
    }
    public List<UserRoleModel> UserRoles { get; set; }
    public void BuildUserRoles()
    {
        UserRoles = new List<UserRoleModel>();
        UserRoles.Add(new UserRoleModel() { Id = 1, UserId = 1, RoleId = 1, IsSuccess = true, Message = "", ErrorMessages = new() });
        UserRoles.Add(new UserRoleModel() { Id = 2, UserId = 1, RoleId = 2, IsSuccess = true, Message = "", ErrorMessages = new() });
    }
    public List<GroupModel> Groups { get; set; }
    public void BuildGroups()
    {
        Groups = new List<GroupModel>();
        Groups.Add(new GroupModel() { Id = 1, Key = "ADMIN_GROUP", Title = "System Admins", Message = "", IsSuccess = true, ErrorMessages = new() });
    }
    public List<MenuModel> Menus { get; set; }
    public void BuildMenus()
    {
        Menus = new List<MenuModel>();
        Menus.Add(new MenuModel() { Title = "System", Schema = "Setting", Children = [], IsSuccess = true, Message = "", ErrorMessages = [] });
        Menus.Add(new MenuModel() { Title = "Security", Schema = "Security", Children = [], IsSuccess = true, Message = "", ErrorMessages = [] });
    }
    public List<PrivielgeModel> Privielges { get; set; }
    public void BuildPrivielges()
    {
        Privielges = new List<PrivielgeModel>();
        Privielges.Add(new PrivielgeModel()
        {
            Id = 1,
            EntityId = Guid.NewGuid(),
            EntityName = "",
            Action = "",
            Command = "",
            Message = "",
            IsSuccess = true,
            ErrorMessages = new(),
            Children = new(),
            Order = 1,
            ParentId = null,
            Title = "System",
            Type = PrivilegeType.Read
        });
    }
}