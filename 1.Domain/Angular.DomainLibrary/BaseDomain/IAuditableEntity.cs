namespace Angular.DomainLibrary.BaseDomain;

public interface IEntity
{
}
public interface IAuditableEntity<TId> : IEntity
     where TId : struct,
              IComparable,
              IComparable<TId>,
              IConvertible,
              IEquatable<TId>,
              IFormattable
{
}

public abstract class BaseEntity<TId> : IEntity
{
}

public abstract class AuditableEntity<TId> : BaseEntity<TId>, IAuditableEntity<TId>
         where TId : struct,
              IComparable,
              IComparable<TId>,
              IConvertible,
              IEquatable<TId>,
              IFormattable
{
}