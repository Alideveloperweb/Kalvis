
using Kalvis.Common.Application;
using Kalvis.Domain.TicketEntities;
using Kalvis.Domain.TicketEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;

namespace Kalvis.EfCore.Repository.TicketRepository
{
    public class AnswerRepository
          : RepositoryBase<int, TicketAnswer>
          , IAnswerRepository
    {
        private readonly ApplicationContext _context;
        public AnswerRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
