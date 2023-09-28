
using Kalvis.Domain.OrderEntities.CourseOrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.OrderMapper
{
    public class CourseOrderMap : IEntityTypeConfiguration<CourseOrders>
    {
        public void Configure(EntityTypeBuilder<CourseOrders> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreateDate);
            builder.Property(x => x.IsCancelled);
            builder.Property(x => x.Ispaid);
            builder.Property(x => x.IsRemove);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.OrderSum);
            builder.Property(x => x.UserId);
            builder.Property(x => x.DisCountID);

            builder.HasOne(x => x.User)
                .WithMany(x => x.CourseOrders)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.CourseDisCount)
                .WithMany(x => x.courseOrders)
                .HasForeignKey(x => x.DisCountID);

        }
    }
}
