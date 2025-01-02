using Angular.ApplicationLibrary.BaseApplication.Interfaces;
using Angular.InfrastructureLibrary.Database.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Angular.InfrastructureLibrary.Database.Interceptors;

public class AddAuditDataInterceptor : SaveChangesInterceptor
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        AddShadowProperties(eventData);
        return base.SavingChanges(eventData, result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        AddShadowProperties(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    private static void AddShadowProperties(DbContextEventData eventData)
    {
        var changeTracker = eventData.Context.ChangeTracker;
        var userInfoService = eventData.Context.GetService<IUserInfoService>();
        changeTracker.SetAuditableEntityPropertyValues(userInfoService);
    }
}
