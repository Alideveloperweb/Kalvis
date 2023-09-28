using Kalvis.Common.Application;
using Kalvis.Contract.TicketViewModel;
using Kalvis.Domain.TicketEntities;
using Kalvis.Domain.TicketEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Kalvis.EfCore.Repository.TicketRepository
{
    public class TicketRepository
        : RepositoryBase<int, Ticket>
        , ITicketRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public TicketRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }



        #endregion

        public List<GetAllTicketItem> GetAllTicket(bool Isremove, long Userid)
        {
            return _context.Tickets
                 .Where(x => !x.IsRemove)
                 .Where(x => x.Userid == Userid)
                 .Select(x => new GetAllTicketItem
                 {
                     CreateDate = ConvertDate.MiladiToShamsi(x.CreateDate),
                     TicketId = x.Id,
                     TicketTitle = x.TicketTitle,
                 })
                 .OrderByDescending(x => x.TicketId)
                 .ToList();
        }

        public List<GetAllTicketForAdminItem> GetAllTicketForAdmin(bool IsRemove)
        {
            return _context.Tickets
                .Include(x => x.User)
                .Where(x => x.IsRemove == IsRemove)
                .Select(x => new GetAllTicketForAdminItem
                {
                    CreateDate = ConvertDate.MiladiToShamsi(x.CreateDate),
                    FullName = x.User.FirstName + " " + x.User.LastName,
                    TicketId = x.Id,
                    UserId = x.User.Id,
                    UserName = x.User.UserName,
                    TicketTitle = x.TicketTitle,

                })
                .OrderByDescending(x => x.TicketId)
                .ToList();
        }

        public GetTicketItem GetTicketById(int TicketId, long UserId)
        {
            return _context.Tickets
                 .Where(x => !x.IsRemove)
                 .Where(x => x.Userid == UserId)
                 .Where(x => x.Id == TicketId)
                 .Select(x => new GetTicketItem
                 {
                     CreateDate = ConvertDate.MiladiToShamsi(x.CreateDate),
                     TicketId = x.Id,
                     TicketText = x.TicketText,
                     TicketTitle = x.TicketTitle,

                 })
                 .FirstOrDefault();
        }

        public List<GetAnswerItem> GetAllAnswer(int TicketID)
        {
            return _context.TicketAnswers
                .Where(x => x.TicketId == TicketID)
                .Select(x => new GetAnswerItem
                {
                    TicketID = x.TicketId,
                    AnswerID = x.TA_Id,
                    AnswerText = x.AnswerText,

                }).ToList();
        }

        public GetTicketItem GetTicketById(int TicketId)
        {
            return _context.Tickets
      .Where(x => !x.IsRemove)

      .Where(x => x.Id == TicketId)
      .Select(x => new GetTicketItem
      {
          CreateDate = ConvertDate.MiladiToShamsi(x.CreateDate),
          TicketId = x.Id,
          TicketText = x.TicketText,
          TicketTitle = x.TicketTitle,

      })
      .FirstOrDefault();
        }
    }
}
