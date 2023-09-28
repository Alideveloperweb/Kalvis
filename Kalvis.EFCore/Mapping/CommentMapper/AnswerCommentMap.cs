using Kalvis.Domain.EducationEntities.CommentEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.CommentMapper
{
    public class AnswerCommentMap :
         IEntityTypeConfiguration<AnswerComment>
    {
        public void Configure(EntityTypeBuilder<AnswerComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AnswerText);
            builder.Property(x => x.CommentID);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.IsRemove);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.UserID);

            builder.HasOne(x => x.User)
                .WithMany(x => x.AnswerComments)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CourseComment)
                .WithMany(x => x.AnswerComments)
                .HasForeignKey(x => x.CommentID);

        }
    }
}
