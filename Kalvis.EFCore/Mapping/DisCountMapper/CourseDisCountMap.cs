
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.DisCountMapper
{
    public class CourseDisCountMap : IEntityTypeConfiguration<CourseDisCount>
    {
        public void Configure(EntityTypeBuilder<CourseDisCount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.CreateDate);

            builder.Property(x => x.EndtDate);

            builder.Property(x => x.IsRemove);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.MaxUserCount);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.Value);

        }
    }
}
