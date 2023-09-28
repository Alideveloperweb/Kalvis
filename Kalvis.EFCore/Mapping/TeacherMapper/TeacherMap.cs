using Kalvis.Domain.EducationEntities.TeacherEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Kalvis.EFCore.Mapping.TeacherMapper
{
    public class TeacherMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TeacherId);

            builder.HasOne(x => x.user)
                .WithMany(x => x.Teachers)
                .HasForeignKey(x => x.TeacherId);

        }
    }
}
