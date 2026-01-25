using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.Core.Domain.Entities.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularApp.Infra.Data.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(x => x.Details)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
public class ProductDetailEntityConfiguration : IEntityTypeConfiguration<ProductDetailEntity>
{
    public void Configure(EntityTypeBuilder<ProductDetailEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Key)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Value)
            .IsRequired()
            .HasMaxLength(500);
    }
}
//public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRoleEntity>
//{
//    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
//    {
//    }
//}
