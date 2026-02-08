namespace AngularApp.Core.Application.Common.BaseApplication.Models;

public interface IBaseView
{
    Guid EntityId { get; set; }
}
public abstract class BaseView : IBaseView
{
    public Guid EntityId { get; set; }
}