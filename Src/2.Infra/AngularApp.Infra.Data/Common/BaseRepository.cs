using AngularApp.Core.Application.Common;
using AngularApp.Core.Domain.Common;
using AngularApp.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Infra.Data.Common;

public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : class, IAggregate<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly DatabaseContext Context;
    protected readonly DbSet<TEntity> Set;

    protected BaseRepository(DatabaseContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        Set = Context.Set<TEntity>();
    }

    // ----------------------------------------------------
    // Queryable
    // ----------------------------------------------------
    public IQueryable<TEntity> Queryable => Set;

    // ----------------------------------------------------
    // Add
    // ----------------------------------------------------
    public virtual TEntity Add(TEntity entity)
    {
        Set.Add(entity);
        return entity;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellation = default)
    {
        await Set.AddAsync(entity, cancellation);
        return entity;
    }

    // ----------------------------------------------------
    // Get (Tracking)
    // ----------------------------------------------------
    public virtual TEntity Get(TId id)
        => Set.FirstOrDefault(e => e.Id.Equals(id));

    public virtual TEntity Get(Guid entityId)
        => Set.FirstOrDefault(e => e.Id.Equals(entityId));

    public virtual TEntity Get(TEntity entity)
        => Get(entity.Id);

    public virtual IEnumerable<TEntity> Get()
        => Set.ToList();

    public virtual async Task<TEntity> GetAsync(TId id, CancellationToken cancellation = default)
        => await Set.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellation);

    public virtual async Task<TEntity> GetAsync(Guid entityId, CancellationToken cancellation = default)
        => await Set.FirstOrDefaultAsync(e => e.Id.Equals(entityId), cancellation);

    public virtual async Task<TEntity> GetAsync(TEntity entity, CancellationToken cancellation = default)
        => await GetAsync(entity.Id, cancellation);

    public virtual async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellation = default)
        => await Set.ToListAsync(cancellation);

    // ----------------------------------------------------
    // Get As No Tracking
    // ----------------------------------------------------
    public virtual TEntity GetAsNoTracking(TId id)
        => Set.AsNoTracking().FirstOrDefault(e => e.Id.Equals(id));

    public virtual TEntity GetAsNoTracking(Guid entityId)
        => Set.AsNoTracking().FirstOrDefault(e => e.Id.Equals(entityId));

    public virtual TEntity GetAsNoTracking(TEntity entity)
        => GetAsNoTracking(entity.Id);

    public virtual IEnumerable<TEntity> GetAsNoTracking()
        => Set.AsNoTracking().ToList();

    public virtual async Task<TEntity> GetAsNoTrackingAsync(TId id, CancellationToken cancellation = default)
        => await Set.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id.Equals(id), cancellation);

    public virtual async Task<TEntity> GetAsNoTrackingAsync(Guid entityId, CancellationToken cancellation = default)
        => await Set.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id.Equals(entityId), cancellation);

    public virtual async Task<TEntity> GetAsNoTrackingAsync(TEntity entity, CancellationToken cancellation = default)
        => await GetAsNoTrackingAsync(entity.Id, cancellation);

    public virtual async Task<IEnumerable<TEntity>> GetAsNoTrackingAsync(CancellationToken cancellation = default)
        => await Set.AsNoTracking().ToListAsync(cancellation);

    // ----------------------------------------------------
    // Graph Loading (override IncludeGraph)
    // ----------------------------------------------------
    protected virtual IQueryable<TEntity> IncludeGraph(IQueryable<TEntity> query)
        => query;

    public virtual TEntity GetGraph(TId id)
        => IncludeGraph(Set).FirstOrDefault(e => e.Id.Equals(id));

    public virtual TEntity GetGraph(Guid entityId)
        => IncludeGraph(Set).FirstOrDefault(e => e.Id.Equals(entityId));

    public virtual TEntity GetGraph(TEntity entity)
        => GetGraph(entity.Id);

    public virtual TEntity GetGraphAsNoTracking(TId id)
        => IncludeGraph(Set.AsNoTracking())
            .FirstOrDefault(e => e.Id.Equals(id));

    public virtual TEntity GetGraphAsNoTracking(Guid entityId)
        => IncludeGraph(Set.AsNoTracking())
            .FirstOrDefault(e => e.Id.Equals(entityId));

    public virtual TEntity GetGraphAsNoTracking(TEntity entity)
        => GetGraphAsNoTracking(entity.Id);

    public virtual async Task<TEntity> GetGraphAsync(TId id, CancellationToken cancellation = default)
        => await IncludeGraph(Set)
            .FirstOrDefaultAsync(e => e.Id.Equals(id), cancellation);

    public virtual async Task<TEntity> GetGraphAsync(Guid entityId, CancellationToken cancellation = default)
        => await IncludeGraph(Set)
            .FirstOrDefaultAsync(e => e.Id.Equals(entityId), cancellation);

    public virtual async Task<TEntity> GetGraphAsync(TEntity entity, CancellationToken cancellation = default)
        => await GetGraphAsync(entity.Id, cancellation);

    public virtual async Task<TEntity> GetGraphAsNoTrackingAsync(TId id, CancellationToken cancellation = default)
        => await IncludeGraph(Set.AsNoTracking())
            .FirstOrDefaultAsync(e => e.Id.Equals(id), cancellation);

    public virtual async Task<TEntity> GetGraphAsNoTrackingAsync(Guid entityId, CancellationToken cancellation = default)
        => await IncludeGraph(Set.AsNoTracking())
            .FirstOrDefaultAsync(e => e.Id.Equals(entityId), cancellation);

    public virtual async Task<TEntity> GetGraphAsNoTrackingAsync(TEntity entity, CancellationToken cancellation = default)
        => await GetGraphAsNoTrackingAsync(entity.Id, cancellation);

    // ----------------------------------------------------
    // Remove (Soft delete handled by DbContext filter)
    // ----------------------------------------------------
    public virtual TEntity Remove(TId id)
    {
        var entity = Get(id);
        return Remove(entity);
    }

    public virtual TEntity Remove(Guid entityId)
    {
        var entity = Get(entityId);
        return Remove(entity);
    }

    public virtual TEntity Remove(TEntity entity)
    {
        Set.Remove(entity);
        return entity;
    }

    public virtual async Task<TEntity> RemoveAsync(TId id, CancellationToken cancellation = default)
    {
        var entity = await GetAsync(id, cancellation);
        return Remove(entity);
    }

    public virtual async Task<TEntity> RemoveAsync(Guid entityId, CancellationToken cancellation = default)
    {
        var entity = await GetAsync(entityId, cancellation);
        return Remove(entity);
    }

    public virtual Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellation = default)
    {
        Remove(entity);
        return Task.FromResult(entity);
    }
}
