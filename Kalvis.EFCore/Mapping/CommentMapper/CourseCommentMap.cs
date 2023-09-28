using Kalvis.Domain.EducationEntities.CommentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.CommentMapper
{
    public class CourseCommentMap : IEntityTypeConfiguration<CourseComment>
    {
        public void Configure(EntityTypeBuilder<CourseComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CommentText)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.CourseId);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.IsRemove);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.CourseComments)
                .HasForeignKey(x => x.CourseId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.CourseComments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
