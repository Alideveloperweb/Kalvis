using Kalvis.Domain.EducationEntities.CourseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.EFCore.Mapping.CourseMapper
{
    public class CourseEpisodeMap : IEntityTypeConfiguration<CourseEpisode>
    {
        public void Configure(EntityTypeBuilder<CourseEpisode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CourseId);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.EpisodeTime);
            builder.Property(x => x.EpisodeTitle);
            builder.Property(x => x.IsFree);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.LinkEpisode);

        }
    }
}
