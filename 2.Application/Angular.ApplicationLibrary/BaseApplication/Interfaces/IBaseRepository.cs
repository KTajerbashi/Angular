using Angular.ApplicationLibrary.BaseApplication.Pattern.UnitOfWork;
using Angular.DomainLibrary.BaseDomain;

namespace Angular.ApplicationLibrary.BaseApplication.Interfaces;

public interface IBaseRepository<TEntity, TId> : IUnitOfWork
    where TEntity : class, IAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>The entity if found, or null.</returns>
    Task<TEntity> GetAsync(TId id, CancellationToken token);
    Task<TEntity> GetAsync(Guid guid, CancellationToken token);

    /// <summary>
    /// Retrieves all entities of the specified type.
    /// </summary>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>An enumerable collection of entities.</returns>
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken token);

    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>The unique identifier of the created entity.</returns>
    Task<TId> CreateAsync(TEntity entity, CancellationToken token);

    /// <summary>
    /// Deletes an entity by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>A boolean indicating success or failure.</returns>
    Task<bool> DeleteAsync(TId id, CancellationToken token);

    /// <summary>
    /// Deletes an entity by its identifier.
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid guid, CancellationToken token);
}










