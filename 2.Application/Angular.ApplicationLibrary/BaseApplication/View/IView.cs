namespace Angular.ApplicationLibrary.BaseApplication.View;

public interface IView
{
}

public abstract class BaseView<TId> : IView
{
    public TId Id { get; set; }
    public Guid Guid { get; set; }
}

public abstract class BaseView : BaseView<long>
{

}
