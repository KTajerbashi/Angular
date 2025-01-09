namespace Angular.DomainLibrary.BaseDomain;

public interface IEntity
{
    void Delete();
    void Acive();
    void DisActive();
    void UndoDelete();
    void DeleteRecord();
}

public interface IAuditableEntity<TId> : IEntity
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    TId Id { get; }
    Guid KeyRecord { get; } 
    DateTime CreateDate { get; }
    TId CreatedByUserId { get; }
    DateTime? UpdateDate { get; }
    TId? UpdateByUserId { get; }
    bool IsActive { get; }
    bool IsDeleted { get; }
}

public abstract class BaseEntity<TId> : IEntity
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    public TId Id { get; private set; }
    public DateTime CreateDate { get; private set; }
    public Guid KeyRecord { get; private set; }
    public TId CreatedByUserId { get; private set; }
    public DateTime? UpdateDate { get; private set; }
    public TId? UpdateByUserId { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }

    public void Delete() => IsDeleted = true;
    public void Acive() => IsActive = true;
    public void DisActive() => IsActive = false;
    public void UndoDelete() => IsDeleted = false;
    public void DeleteRecord()
    {
        IsDeleted = true;
        IsActive = false;
    }
}

public abstract class AuditableEntity<TId> : BaseEntity<TId>, IAuditableEntity<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
}
