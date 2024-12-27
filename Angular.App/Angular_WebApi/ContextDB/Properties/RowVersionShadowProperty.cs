using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Angular_WebApi.ContextDB.Properties;

public static class RowVersionShadowProperty
{
    public static readonly string RowVersion = nameof(RowVersion);

    /// <summary>
    /// رو ورژن بصورت شادو پراپرتی خواستیم استفاده کنیم ازین متد استفاده میکنیم
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="builder"></param>
    public static void AddRowVersionShadowProperty<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class
        => builder.Property<byte[]>(RowVersion).IsRowVersion();
}
