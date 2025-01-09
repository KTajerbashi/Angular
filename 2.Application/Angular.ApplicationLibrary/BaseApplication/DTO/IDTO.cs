namespace Angular.ApplicationLibrary.BaseApplication.DTO;

public interface IDTO
{
}
public abstract class BaseDTO<TId> : IDTO
{
    public TId Id { get; set; }
    public Guid Guid { get; set; }
}
public abstract class BaseDTO : BaseDTO<long>
{

}
