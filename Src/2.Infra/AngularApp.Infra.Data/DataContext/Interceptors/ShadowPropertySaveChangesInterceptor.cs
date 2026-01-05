using AngularApp.Core.Application.Providers.UserState;
using AngularApp.Infra.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AngularApp.Infra.Data.DataContext.Interceptors;

public sealed class ShadowPropertySaveChangesInterceptor
    : SaveChangesInterceptor
{
    public ShadowPropertySaveChangesInterceptor()
    {
    }

    // ----------------------------
    // Sync SaveChanges
    // ----------------------------
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        var userStateService = eventData?.Context?.GetService<IUserState>();
        ApplyShadowProperties(userStateService, eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    // ----------------------------
    // Async SaveChanges
    // ----------------------------
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var userStateService = eventData?.Context?.GetService<IUserState>();
        ApplyShadowProperties(userStateService, eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    // ----------------------------
    // Core Logic
    // ----------------------------
    private void ApplyShadowProperties(IUserState? state, DbContext context)
    {
        if (context == null)
            return;

        var userId = state.UserId;

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.Metadata.IsOwned())
                continue;

            switch (entry.State)
            {
                case EntityState.Added:
                    SetAdded(entry, userId);
                    break;

                case EntityState.Modified:
                    SetModified(entry, userId);
                    break;

                case EntityState.Deleted:
                    SetDeleted(entry, userId);
                    break;
            }
        }
    }

    private static void SetAdded(EntityEntry entry, long? userId)
    {
        entry.Property(ShadowProperties.IsActive).CurrentValue = true;
        entry.Property(ShadowProperties.IsDeleted).CurrentValue = false;
        entry.Property(ShadowProperties.CreatedDate).CurrentValue = DateTime.Now;
        entry.Property(ShadowProperties.CreatedByUserId).CurrentValue = userId;
    }

    private static void SetModified(EntityEntry entry, long? userId)
    {
        entry.Property(ShadowProperties.UpdatedDate).CurrentValue = DateTime.Now;
        entry.Property(ShadowProperties.UpdatedByUserId).CurrentValue = userId;
    }

    private static void SetDeleted(EntityEntry entry, long? userId)
    {
        entry.State = EntityState.Modified;
        entry.Property(ShadowProperties.IsDeleted).CurrentValue = true;
        entry.Property(ShadowProperties.UpdatedDate).CurrentValue = DateTime.Now;
        entry.Property(ShadowProperties.UpdatedByUserId).CurrentValue = userId;
    }
}