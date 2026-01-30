using AngularApp.Core.Domain.Common;

namespace AngularApp.Core.Application.Common;

public interface IBaseRepository<TEntity, TId> : IScopeLifeTime
    where TEntity : IAggregate<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    TEntity Add(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation = default);

    TEntity Remove(TId id);
    Task<TEntity> RemoveAsync(TId id, CancellationToken cancellation = default);

    TEntity Remove(Guid entityId);
    Task<TEntity> RemoveAsync(Guid entityId, CancellationToken cancellation = default);

    TEntity Remove(TEntity entity);
    Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellation = default);

    TEntity Get(TId id);
    TEntity GetAsNoTracking(TId id);
    Task<TEntity> GetAsync(TId id, CancellationToken cancellation = default);
    Task<TEntity> GetAsNoTrackingAsync(TId id, CancellationToken cancellation = default);

    TEntity Get(Guid entityId);
    TEntity GetAsNoTracking(Guid entityId);
    Task<TEntity> GetAsync(Guid entityId, CancellationToken cancellation = default);
    Task<TEntity> GetAsNoTrackingAsync(Guid entityId, CancellationToken cancellation = default);

    TEntity Get(TEntity entity);
    TEntity GetAsNoTracking(TEntity entity);
    Task<TEntity> GetAsync(TEntity entity, CancellationToken cancellation = default);
    Task<TEntity> GetAsNoTrackingAsync(TEntity entity, CancellationToken cancellation = default);


    TEntity GetGraph(TId id);
    TEntity GetGraphAsNoTracking(TId id);
    Task<TEntity> GetGraphAsync(TId id, CancellationToken cancellation = default);
    Task<TEntity> GetGraphAsNoTrackingAsync(TId id, CancellationToken cancellation = default);

    TEntity GetGraph(Guid entityId);
    TEntity GetGraphAsNoTracking(Guid entityId);
    Task<TEntity> GetGraphAsync(Guid entityId, CancellationToken cancellation = default);
    Task<TEntity> GetGraphAsNoTrackingAsync(Guid entityId, CancellationToken cancellation = default);

    TEntity GetGraph(TEntity entity);
    TEntity GetGraphAsNoTracking(TEntity entity);
    Task<TEntity> GetGraphAsync(TEntity entity, CancellationToken cancellation = default);
    Task<TEntity> GetGraphAsNoTrackingAsync(TEntity entity, CancellationToken cancellation = default);


    IEnumerable<TEntity> Get();
    IEnumerable<TEntity> GetAsNoTracking();
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellation = default);
    Task<IEnumerable<TEntity>> GetAsNoTrackingAsync(CancellationToken cancellation = default);

    IQueryable<TEntity> Queryable { get; }

}
