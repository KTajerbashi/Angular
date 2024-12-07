namespace Angular_WebApi.ApplicationBases.Repositories;

public interface IBaseRepository<TEntity, TId>
{
    Task<TEntity> GetAsync(TId id);
    Task<IEnumerable<TEntity>> GetAsync();

    Task<TId> CreateAsync(TEntity entity);
    Task<bool> Delete(TId id);
}
