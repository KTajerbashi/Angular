namespace AngularApp.EndPoint.WebApi.Models;

public class TokenResponse : BaseIdentityModel
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpireDate { get; set; }
    public string State { get; set; }
    public string AppState { get; set; }
}
