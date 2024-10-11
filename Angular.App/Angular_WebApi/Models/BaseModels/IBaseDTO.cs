namespace Angular_WebApi.Models.BaseModels;

public interface IBaseDTO
{

}
public abstract class BaseDTO<T> : IBaseDTO
{
    public T Id { get; set; }
}
public abstract class BaseDTO : BaseDTO<long>
{

}