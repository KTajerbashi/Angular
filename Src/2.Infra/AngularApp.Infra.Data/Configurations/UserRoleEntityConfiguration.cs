using AngularApp.Core.Domain.Entities.Security.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularApp.Infra.Data.Configurations;

public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder.HasOne(x => x.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .IsRequired();

        builder.Property(x => x.Description).HasMaxLength(500);

        builder.Property(x => x.IsDefault).HasDefaultValue(false).IsRequired();

        builder.ToTable("UserRoles", "Security");
    }
}

