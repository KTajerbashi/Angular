namespace AngularApp.Core.Application.Common.BaseApplication.Models;

public interface IBaseView<TModel> : IMapFrom<TModel>
    where TModel : class
{
    Guid EntityId { get; set; }
    long Id { get; set; }
}
public abstract class BaseView<TModel> : IBaseView<TModel>
    where TModel : class
{
    public Guid EntityId { get; set; }
    public long Id { get; set; }

    public abstract void Mapping(Profile profile);

}
