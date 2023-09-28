using Kalvis.Domain.BlogEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.BlogMapper
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.BlogDescription)
                .IsRequired();

            builder.Property(x => x.BlogImage)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.BlogTitle)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.CategoryId);

            builder.Property(x => x.CreateDate);

            builder.Property(x => x.IsActive);

            builder.Property(x => x.IsComment);

            builder.Property(x => x.IsRemove);

            builder.Property(x => x.LastUpdate);

            builder.Property(x => x.Tags)
                .HasMaxLength(500);

            builder.HasOne(x => x.category)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
