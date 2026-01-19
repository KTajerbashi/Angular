using System.ComponentModel;

namespace AngularApp.EndPoint.WebApi.Models;

public enum TokenType : byte
{
    [Description("")]
    JWT = 1,
    [Description("")]
    JWE = 2,
}
