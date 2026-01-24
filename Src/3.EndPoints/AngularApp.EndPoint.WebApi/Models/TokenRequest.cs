using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.EndPoint.WebApi.Models;

public class TokenRequest : BaseIdentityModel
{
    public TokenType TokenType { get; set; }
    public UserEntity User { get; set; }
    public UserRoleEntity UserRole { get; set; }
    public RoleEntity Role { get; set; }
}
