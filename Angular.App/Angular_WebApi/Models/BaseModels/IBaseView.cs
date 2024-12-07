namespace Angular_WebApi.Models.BaseModels;

public interface IBaseView
{

}
public abstract class BaseView<T> : IBaseView
{
    public T Id { get; set; }
}
public abstract class BaseView : BaseView<long>
{

}