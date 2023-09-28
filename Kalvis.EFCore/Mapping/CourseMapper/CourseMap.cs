using Kalvis.Domain.EducationEntities.CourseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Kalvis.EFCore.Mapping.CourseMapper
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ActiveComment);

            builder.Property(x => x.ActiveFaq);

            builder.Property(x => x.CourseDescription)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(x => x.CourseImage)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.CourseLevel);
            builder.Property(x => x.CoursePrice);

            builder.Property(x => x.CourseSummery)
                .HasMaxLength(500);

            builder.Property(x => x.CourseTitle)
                   .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.CreateDate);
            builder.Property(x => x.IsRemove);
            builder.Property(x => x.Language);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.Percentage);

            builder.Property(x => x.Tags)
                .HasMaxLength(600);

            builder.Property(x => x.UserId);
            builder.Property(x => x.CategoryId);


            builder.HasOne(x => x.User)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Category)
               .WithMany(x => x.Courses)
               .HasForeignKey(x => x.CategoryId);
        }
    }
}
