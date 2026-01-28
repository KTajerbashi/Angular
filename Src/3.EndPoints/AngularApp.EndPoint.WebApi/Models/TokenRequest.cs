using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.EndPoint.WebApi.Models;

public class TokenRequest
{
    public TokenType TokenType { get; set; }
    public UserEntity User { get; set; }
    public UserRoleEntity UserRole { get; set; }
    public RoleEntity Role { get; set; }
}
public sealed class RefreshTokenRequest
{
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}

public sealed class ValidateTokenRequest
{
    public string Token { get; set; } = default!;
}

public sealed class ReadTokenRequest
{
    public string Token { get; set; } = default!;
}