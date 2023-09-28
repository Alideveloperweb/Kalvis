

using Kalvis.Domain.PermissionEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.PermissionMapper
{
    public class UserRoleMap :
        IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreateDate);
            builder.Property(x => x.IsRemove);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.RoleID);
            builder.Property(x => x.UserID);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleID);

            builder.HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserID);

        }
    }
}
