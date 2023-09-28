using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Kalvis.Domain.UserEntities;

namespace Kalvis.EFCore.Mapping.UserMapper
{

    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ActiveCode)
                .IsRequired();

            builder.Property(x => x.Avatar);

            builder.Property(x => x.CreateDate);

            builder.Property(x => x.Email)
                .HasMaxLength(200);

            builder.Property(x => x.FirstName)
                               .HasMaxLength(200);

            builder.Property(x => x.IsActive);

            builder.Property(x => x.IsRemove);

            builder.Property(x => x.LastName)
                               .HasMaxLength(200);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(12);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Wallet);

            builder.HasMany(x => x.Teachers)
             .WithOne(x => x.user)
             .HasForeignKey(x => x.TeacherId);
        }
    }
}
