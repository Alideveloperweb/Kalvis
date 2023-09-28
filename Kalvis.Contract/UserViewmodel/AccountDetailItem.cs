
using Kalvis.Contract.NotificationViewModel;

namespace Kalvis.Contract.UserViewModel
{
    public class AccountDetailItem
    {
        public int CourseCount { get; set; }
        public int UserCourseCount { get; set; }
        public int AwaitingPayeCount { get; set; }
        public int WalletBalance { get; set; }
        public List<GetAllNotificationItem> GetAllNotification { get; set; }

    }
}
