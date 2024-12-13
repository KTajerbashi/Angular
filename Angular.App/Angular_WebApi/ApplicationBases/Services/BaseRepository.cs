using Angular_WebApi.ApplicationBases.Models;
using Angular_WebApi.ApplicationBases.Patterns;
using Angular_WebApi.ApplicationBases.Repositories;
using Angular_WebApi.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApi.ApplicationBases.Services;

public abstract class BaseRepository<TEntity, TId>
       : UnitOfWork<DatabaseContext>, IBaseRepository<TEntity, TId>
       where TEntity : class, IBaseEntity<TId>, new()
       where TId : struct
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
        entity.IsActive = true;
        entity.IsDeleted = true;
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
    public async Task<bool> Delete(TId id, CancellationToken token)
    {
        var entity = await _dbSet.FindAsync(new object[] { id }, token);
        if (entity == null)
        {
            return false;
        }

        _dbSet.Remove(entity);
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
        return await _dbSet.FindAsync(new object[] { id }, token);
    }

    /// <summary>
    /// Retrieves all entities of the given type.
    /// </summary>
    /// <param name="token">Cancellation token for the operation.</param>
    /// <returns>A collection of all entities.</returns>
    public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken token)
    {
        return await _dbSet.Where(item => item.IsActive && !item.IsDeleted).ToListAsync(token);
    }
}

