
using Kalvis.Domain.PermissionEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.PermissionMapper
{
    public class RolePermissionMap :
        IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreateDate);
            builder.Property(x => x.IsRemove);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.PermissionID);
            builder.Property(x => x.RoleID);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.RoleID);

        }
    }
}
