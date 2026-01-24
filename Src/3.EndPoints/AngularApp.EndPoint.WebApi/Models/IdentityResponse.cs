using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.EndPoint.WebApi.Models;

public class IdentityResponse : BaseIdentityModel
{
    public UserEntity User { get; set; }
}
