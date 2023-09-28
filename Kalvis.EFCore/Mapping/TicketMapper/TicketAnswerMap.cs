using Kalvis.Domain.TicketEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kalvis.EfCore.Mapping.TicketMapper
{
    public class TicketAnswerMap
          : IEntityTypeConfiguration<TicketAnswer>
    {
        public void Configure(EntityTypeBuilder<TicketAnswer> builder)
        {
            builder.HasKey(x => x.TA_Id);
            builder.Property(x => x.AnswerText);
            builder.Property(x => x.TicketId);


        }
    }
}
