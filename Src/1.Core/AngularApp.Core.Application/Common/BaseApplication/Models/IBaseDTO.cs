namespace AngularApp.Core.Application.Common.BaseApplication.Models;

public interface IBaseDTO
{
    Guid EntityId { get; set; }
    long Id { get; set; }
}
public abstract class BaseDTO : IBaseDTO
{
    public Guid EntityId { get; set; }
    public long Id { get; set; }
}
