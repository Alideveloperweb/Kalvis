using Kalvis.Contract.NotificationViewModel;
using Kalvis.Contract.NotificationViewModel.Interface;
using Kalvis.Domain.NotificationEntities.Interface;
using System.Collections.Generic;

namespace Kalvis.Application.NotificationApp
{
    public class NotificationApplication
            : INotificationApplication
    {
        #region Constracture
        private readonly INotificationRepository _NotificationRepp;
        public NotificationApplication(INotificationRepository NotificationRepp)
        {
            this._NotificationRepp = NotificationRepp;
        }
        #endregion

        public List<GetAllNotificationItem> GetAllNotification(bool IsRemove)
        {
            return _NotificationRepp.GetAllNotification(IsRemove);
        }
    }
}
