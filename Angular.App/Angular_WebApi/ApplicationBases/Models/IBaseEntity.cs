namespace Angular_WebApi.ApplicationBases.Models;

public interface IBaseEntity
{

}
public interface IBaseEntity<TId>: IBaseEntity
{
    TId Id { get; set; }
    bool IsDeleted { get; set; }
    bool IsActive { get; set; }
}
public abstract class BaseEntity<TId> : IBaseEntity<TId>
{
    public TId Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
}

public abstract class BaseEntity : BaseEntity<long>
{
    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }
    public void UnDelete()
    {
        IsActive = true;
        IsDeleted = false;
    }
}