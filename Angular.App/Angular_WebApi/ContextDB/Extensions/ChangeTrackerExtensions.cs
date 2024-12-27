using Angular_WebApi.ApplicationBases.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Angular_WebApi.ContextDB.Extensions;

public static class ChangeTrackerExtensions
{
    /// <summary>
    /// ترکر های بده که 
    /// Aggregate Root  
    /// هستند
    /// </summary>
    /// <param name="changeTracker"></param>
    /// <returns></returns>
    public static List<IBaseEntity> GetChangedAggregates(this ChangeTracker changeTracker) =>
        changeTracker.Aggregates().Where(IsModified()).Select(c => c.Entity).ToList();


    /// <summary>
    /// 
    /// </summary>
    /// <param name="changeTracker"></param>
    /// <returns></returns>
    public static IEnumerable<EntityEntry<IBaseEntity>> Aggregates(this ChangeTracker changeTracker) =>
        changeTracker.Entries<IBaseEntity>();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Func<EntityEntry<IBaseEntity>, bool> IsNotDetached() =>
        x => x.State != EntityState.Detached;


    /// <summary>
    /// این شاخه های که تغییرات داشته را بر میگرداند
    /// </summary>
    /// <returns></returns>
    private static Func<EntityEntry<IBaseEntity>, bool> IsModified()
    {
        return x => x.State == EntityState.Modified ||
                                           x.State == EntityState.Added ||
                                           x.State == EntityState.Deleted;
    }

}

