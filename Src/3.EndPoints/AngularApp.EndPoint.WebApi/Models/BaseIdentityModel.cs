namespace AngularApp.EndPoint.WebApi.Models;

public abstract class BaseIdentityModel
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> ErrorMessages { get; set; }
}
