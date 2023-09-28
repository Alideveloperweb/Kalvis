using Kalvis.Domain.OrderEntities.CourseOrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.OrderMapper
{
    public class CourseOrderDetailsMap : IEntityTypeConfiguration<CourseOrderDetails>
    {
        public void Configure(EntityTypeBuilder<CourseOrderDetails> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CourseId);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.IsRemove);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.OrderId);
            builder.Property(x => x.Price);


            builder.HasOne(x => x.CourseOrders)
                .WithMany(x => x.CourseOrderDetails)
                .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.CourseOrderDetails)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
