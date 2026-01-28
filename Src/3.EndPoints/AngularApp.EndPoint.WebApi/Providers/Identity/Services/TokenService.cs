using AngularApp.EndPoint.WebApi.Models;
using AngularApp.EndPoint.WebApi.Providers.Identity.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AngularApp.EndPoint.WebApi.Providers.Identity.Services;

public sealed class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // ----------------------------------------------------
    // Generate Access + Refresh Token
    // ----------------------------------------------------
    public async Task<TokenResponse> GenerateTokenAsync(TokenRequest parameter, CancellationToken cancellation)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, parameter.User.EntityId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, parameter.User.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, parameter.Role.Name)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
        );

        var credentials = new SigningCredentials(
            key, SecurityAlgorithms.HmacSha256
        );

        var expires = DateTime.UtcNow.AddMinutes(
            int.Parse(_configuration["Jwt:AccessTokenMinutes"]!)
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        var refreshToken = GenerateSecureRefreshToken();

        return new TokenResponse
        {
            IsSuccess = true,
            Token = accessToken,
            RefreshToken = refreshToken,
            ExpireDate = expires,
            Message = "Token generated successfully"
        };
    }

    // ----------------------------------------------------
    // Refresh Token
    // ----------------------------------------------------
    public async Task<TokenResponse> GenerateRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellation)
    {
        var principal = GetPrincipalFromExpiredToken(token);
        if (principal == null)
            return Fail("Invalid token");

        // ⚠️ Here you must validate refresh token from DB
        // Example:
        // if (!await _refreshTokenRepository.IsValidAsync(refreshToken))
        //     return Fail("Invalid refresh token");

        var userId = principal.FindFirstValue(JwtRegisteredClaimNames.Sub);
        var username = principal.FindFirstValue(JwtRegisteredClaimNames.UniqueName);
        var role = principal.FindFirstValue(ClaimTypes.Role);

        var request = new TokenRequest
        {
            //User = new UserEntity { EntityId = Guid.Parse(userId), UserName = username },
            //Role = new RoleEntity { Name = role }
            User = new(new() { FirstName = "Kamran", LastName = "Tajerbashi", UserName = "Kamran_Tajerbashi", DisplayName = "Kamran Tajerbashi", Email = "kamrantajerbashi@mail.com", EmailConfirmed = true, PhoneNumber = "+1 234 567 789", PhoneNumberConfirmed = true }),
            Role = new(new(role))
        };

        return await GenerateTokenAsync(request, cancellation);
    }

    // ----------------------------------------------------
    // Validate Token
    // ----------------------------------------------------
    public async Task<TokenResponse> ValidateTokenAsync(string token, CancellationToken cancellation)
    {
        var handler = new JwtSecurityTokenHandler();

        try
        {
            var parameters = GetValidationParameters();
            handler.ValidateToken(token, parameters, out _);

            return new TokenResponse
            {
                IsSuccess = true,
                Message = "Token is valid"
            };
        }
        catch (Exception ex)
        {
            return Fail(ex.Message);
        }
    }

    // ----------------------------------------------------
    // Helpers
    // ----------------------------------------------------

    private static string GenerateSecureRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        var parameters = GetValidationParameters();
        parameters.ValidateLifetime = false;

        try
        {
            return handler.ValidateToken(token, parameters, out _);
        }
        catch
        {
            return null;
        }
    }

    private TokenValidationParameters GetValidationParameters()
        => new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,

            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidAudience = _configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            )
        };

    private static TokenResponse Fail(string message)
        => new()
        {
            IsSuccess = false,
            Message = message,
            ErrorMessages = new() { message }
        };
}