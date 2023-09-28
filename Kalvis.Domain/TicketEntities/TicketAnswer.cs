using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.TicketEntities
{
    public class TicketAnswer
    {
        public int TA_Id { get; private set; }
        public int TicketId { get; set; }
        public string AnswerText { get; set; }

        #region Create
        public TicketAnswer(int TicketId, string AnswerText)
        {
            this.TicketId = TicketId;
            this.AnswerText = AnswerText;
        }
        #endregion

        #region Relation
        public Ticket Ticket { get; private set; }
        #endregion
    }
}
