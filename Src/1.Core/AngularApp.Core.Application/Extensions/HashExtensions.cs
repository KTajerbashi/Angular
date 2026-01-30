using System.Security.Cryptography;
using System.Text;

namespace AngularApp.Core.Application.Extensions;

public static class HashExtensions
{
    public static string Hash(this string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(bytes);
    }

}
