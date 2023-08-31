using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Contract.UserViewmodel
{
    public class AccountDetailItem
    {
        public int CourseCount { get; set; }
        public int UserCourseCount { get; set; }
        public int AwaitingPayeCount { get; set; }
        public int WalletBalance { get; set; }
        //public List<GetAllNotificationItem> GetAllNotification { get; set; }

    }
}
