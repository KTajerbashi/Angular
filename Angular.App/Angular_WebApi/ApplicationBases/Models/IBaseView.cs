namespace Angular_WebApi.ApplicationBases.Models;

public interface IBaseView<TId>
{
    TId Id { get; set; }
}
public abstract class BaseView<TId> : IBaseView<TId>
{
    public TId Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}
public abstract class BaseView : BaseView<long>
{

}
