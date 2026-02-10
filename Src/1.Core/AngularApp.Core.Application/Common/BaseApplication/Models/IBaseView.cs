namespace AngularApp.Core.Application.Common.BaseApplication.Models;

public interface IBaseView<TModel> : IBaseModel, IMapFrom<TModel>
    where TModel : class
{
    Guid EntityId { get; set; }
    long Id { get; set; }
}
public abstract class BaseView<TModel> : BaseView, IBaseView<TModel>
    where TModel : class
{
    public Guid EntityId { get; set; }
    public long Id { get; set; }

    public abstract void Mapping(Profile profile);

}

public abstract class BaseView : IBaseModel
{
    public Guid EntityId { get; set; }
    public long Id { get; set; }
}