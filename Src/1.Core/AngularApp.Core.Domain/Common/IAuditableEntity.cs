namespace AngularApp.Core.Domain.Common;

public interface IAuditableEntity<TId> : IEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    bool IsDeleted { get; }
    bool IsActive { get; }
    void Delete();
    void Restore();
}
public abstract class AuditableEntity<TId> : Entity<TId>, IAuditableEntity<TId>
        where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    public bool IsDeleted { get; protected set; }
    public bool IsActive { get; protected set; }

    public void Delete()
    {
        IsDeleted = true;
        IsActive = false;
    }

    public void Restore()
    {
        IsDeleted = false;
        IsActive = true;
    }

}