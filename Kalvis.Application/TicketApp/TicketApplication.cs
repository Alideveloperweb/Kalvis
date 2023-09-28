using Kalvis.Common.Application;
using Kalvis.Contract.TicketViewModel;
using Kalvis.Contract.TicketViewModel.Interface;
using Kalvis.Domain.TicketEntities;
using Kalvis.Domain.TicketEntities.Interface;
using System.Collections.Generic;

namespace Kalvis.Application.TicketApp
{
    public class TicketApplication
        : ITicketApplication
    {
        #region Constracture
        private readonly ITicketRepository _TicketRep;
        private readonly IAnswerRepository _AnswerRep;
        public TicketApplication(ITicketRepository TicketRep,
            IAnswerRepository AnswerRep)
        {
            this._AnswerRep = AnswerRep;
            this._TicketRep = TicketRep;
        }


        #endregion


        public List<GetAllTicketItem> GetAllTicket(bool Isremove, long Userid)
        {
            return _TicketRep.GetAllTicket(Isremove, Userid);
        }

        public GetTicketItem GetTicketById(int TicketId, long UserId)
        {
            return _TicketRep.GetTicketById(TicketId, UserId);
        }

        public OperationResult CreateTicket(CreateTicketItem ticket)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("تیکت");

            Ticket Ticket = new(ticket.TicketTitle,
                ticket.TicketText, ticket.UserId);

            bool Create = _TicketRep.Create(Ticket);
            if (!Create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool Save = _TicketRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }

        public List<GetAllTicketForAdminItem> GetAllTicketForAdmin(bool IsRemove)
        {
            return _TicketRep.GetAllTicketForAdmin(IsRemove);
        }

        public List<GetAnswerItem> GetAllAnswer(int TicketID)
        {
            return _TicketRep.GetAllAnswer(TicketID);
        }

        public GetTicketItem GetTicketById(int TicketId)
        {
            return _TicketRep.GetTicketById(TicketId);
        }

        public OperationResult CreateAnswer(CreateAnswerItem createAnswer)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("ثبت پاسخ");

            TicketAnswer ticketAnswer =new(createAnswer.TicketID
             , createAnswer.AnswerText);

            bool Create = _AnswerRep.Create(ticketAnswer);
            if (!Create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool Save = _AnswerRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }
    }
}
