namespace AngularApp.EndPoint.WebApi.Models;

public abstract class BaseIdentityModel
{
    public long Id { get; set; }
    public Guid EntityId { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> ErrorMessages { get; set; }
}
