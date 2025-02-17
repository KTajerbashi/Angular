﻿using Angular.ApplicationLibrary.BaseApplication.Pattern.UnitOfWork;
using Angular.InfrastructureLibrary.Database.Base;

namespace Angular.InfrastructureLibrary.BaseInfrastructure.Pattern;

public abstract class UnitOfWork<TContext> : IUnitOfWork
    where TContext : BaseDatabaseContext
{
    protected TContext Context;
    protected UnitOfWork(TContext context)
    {
        Context = context;
    }
    public async Task BeginTransactionAsync()
        => await Context.Database.BeginTransactionAsync();

    public async Task CommitTransactionAsync()
        => await Context.Database.CommitTransactionAsync();

    public async Task RollbackTransactionAsync()
        => await Context.Database.RollbackTransactionAsync();

    public async Task<int> SaveChangesAsync()
        => await Context.SaveChangesAsync();
}
