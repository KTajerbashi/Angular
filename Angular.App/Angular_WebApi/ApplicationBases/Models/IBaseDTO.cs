namespace Angular_WebApi.ApplicationBases.Models;

public interface IBaseDTO<TId>
{
    TId Id { get; set; }

}
public abstract class BaseDTO<TId> : IBaseDTO<TId>
{
    public TId Id { get; set; }
}
public abstract class BaseDTO : BaseDTO<long>
{

}
