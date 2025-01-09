using Angular.ApplicationLibrary.BaseApplication.Interfaces;
using Angular.DomainLibrary.BaseDomain;
using Angular.InfrastructureLibrary.BaseInfrastructure.Pattern;
using Angular.InfrastructureLibrary.Database;
using Microsoft.EntityFrameworkCore;

namespace Angular.InfrastructureLibrary.BaseInfrastructure.Services;

public abstract class BaseRepository<TEntity, TId>
       : UnitOfWork<DatabaseContext>, IBaseRepository<TEntity, TId>
    where TEntity : class, IAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(DatabaseContext context) : base(context)
    {
        _dbSet = context.Set<TEntity>();
    }

    /// <summary>
    /// Creates a new entity and saves it to the database.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>The ID of the created entity.</returns>
    public async Task<TId> CreateAsync(TEntity entity, CancellationToken token)
    {
        var result = await _dbSet.AddAsync(entity, token);
        await Context.SaveChangesAsync(token);
        return result.Entity.Id; // Assuming `Id` is the TId property
    }

    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>True if deletion was successful, otherwise false.</returns>
    public async Task<bool> DeleteAsync(TId id, CancellationToken token)
    {
        var entity = await _dbSet.FindAsync(new object[] { id }, token);
        if (entity == null)
            return false;

        entity.Delete();
        await Context.SaveChangesAsync(token);
        return true;
    }


    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>True if deletion was successful, otherwise false.</returns>

    public async Task<bool> DeleteAsync(Guid guid, CancellationToken token)
    {
        var entity = await _dbSet.Where(item => item.IsActive && !item.IsDeleted && item.KeyRecord.Equals(guid)).SingleAsync(token);
        if (entity == null)
            return false;

        entity.Delete();
        await Context.SaveChangesAsync(token);
        return true;
    }

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>The entity if found, otherwise null.</returns>
    public async Task<TEntity> GetAsync(TId id, CancellationToken token)
    {
        if (id is int intId)
        {
            // Handle as an integer ID
            var entity = await _dbSet.FindAsync(new object[] { intId }, token);
            if (entity is not null)
                return entity;
        }
        else if (id is Guid guidId)
        {
            // Handle as a GUID
            var entity = await _dbSet.Where(item => item.IsActive && !item.IsDeleted && item.KeyRecord.Equals(guidId)).SingleAsync(token);
            if (entity is not null)
                return entity;
        }
        else if (int.TryParse(id.ToString(), out int parsedIntId))
        {
            // Attempt to parse id as int
            var entity = await _dbSet.FindAsync(parsedIntId, token);
            if (entity is not null)
                return entity;
        }
        else if (Guid.TryParse(id.ToString(), out Guid parsedGuidId))
        {
            // Attempt to parse id as Guid
            var entity = await _dbSet.Where(item => item.IsActive && !item.IsDeleted && item.KeyRecord.Equals(parsedGuidId) ).SingleAsync(token);
            if (entity is not null)
                return entity;
        }

        throw new ArgumentException($"The provided id '{id}' is neither a valid int nor a valid Guid.", nameof(id));
    }

    public async Task<TEntity> GetAsync(Guid guid, CancellationToken token)
        => await _dbSet
        .Where(item => item.IsActive && !item.IsDeleted && item.KeyRecord.Equals(guid))
        .Select(item => item)
        .SingleAsync(token);

    /// <summary>
    /// Retrieves all entities of the given type.
    /// </summary>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>A collection of all entities.</returns>
    public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken token)
        => await _dbSet.Where(item => item.IsActive && !item.IsDeleted).Select(item => item).ToListAsync(token);
}



