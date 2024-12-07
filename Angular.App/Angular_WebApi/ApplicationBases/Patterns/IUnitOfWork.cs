using Angular_WebApi.ContextDB;

namespace Angular_WebApi.ApplicationBases.Patterns;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}

public abstract class UnitOfWork<TContext> : IUnitOfWork
    where TContext : BaseDatabaseContext
{
    protected TContext Context;
    protected UnitOfWork(TContext context)
    {
        Context = context;
    }
    public async Task BeginTransactionAsync()
    {
        await Context.Database.BeginTransactionAsync();
    }

    public Task CommitTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public Task RollbackTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
