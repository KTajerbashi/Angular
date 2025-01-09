using Angular.ApplicationLibrary.BaseApplication.Pattern.UnitOfWork;
using Angular.DomainLibrary.BaseDomain;

namespace Angular.ApplicationLibrary.BaseApplication.Interfaces;

public interface IBaseService<TEntity, TId> : IUnitOfWork
    where TEntity : class, IAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{

}










