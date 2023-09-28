using Kalvis.Domain.EducationEntities.CourseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Kalvis.EFCore.Mapping.CourseMapper
{
    public class UserCourseMap : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.HasKey(x => x.UcId);

            builder.Property(x => x.CourseId);
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserCourses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.UserCourses)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
