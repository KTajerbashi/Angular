namespace AngularApp.Core.Application.Common;

public interface IUnitOfWork
{

    Task TransactionAsync(Func<Task> func, CancellationToken cancellationToken = default);
    Task<TResult> TransactionAsync<TResult>(Func<Task<TResult>> func, CancellationToken cancellationToken = default);



    Task BeginTransactionAsync(CancellationToken cancellation);
    Task CommitTransactionAsync(CancellationToken cancellation);
    Task RollbackTransactionAsync(CancellationToken cancellation);

    Task<int> SaveChangesAsync(CancellationToken cancellation);
}
