using Angular_WebApi.ApplicationBases.Repositories;

namespace Angular_WebApi.ApplicationBases.Services;

public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
{
    public Task<TId> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAsync()
    {
        throw new NotImplementedException();
    }
}