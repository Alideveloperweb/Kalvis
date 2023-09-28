using Kalvis.Common.Domain;
using Kalvis.Domain.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.TicketEntities
{
    public class Ticket : EntityBase<int>
    {
        #region Properties
        public string TicketTitle { get; set; }
        public string TicketText { get; set; }
        public long Userid { get; set; }
        #endregion

        #region Create
        public Ticket(string TicketTitle, string TicketText,
            long Userid)
        {
            this.TicketTitle = TicketTitle;
            this.TicketText = TicketText;
            this.Userid = Userid;
        }
        #endregion

        #region Relation
        public User User { get; set; }
        public List<TicketAnswer> TicketAnswers { get; set; }
        #endregion

    }
}