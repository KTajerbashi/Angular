using Angular.ApplicationLibrary.BaseApplication.Interfaces;
using Angular.DomainLibrary.BaseDomain;
using Angular.InfrastructureLibrary.BaseInfrastructure.Pattern;
using Angular.InfrastructureLibrary.Database;
using Microsoft.EntityFrameworkCore;

namespace Angular.InfrastructureLibrary.BaseInfrastructure.Services;

public abstract class BaseService<TEntity, TId>
       : UnitOfWork<DatabaseContext>, IBaseService<TEntity, TId>
    where TEntity : class, IAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseService(DatabaseContext context) : base(context)
    {
        _dbSet = context.Set<TEntity>();
    }


}



