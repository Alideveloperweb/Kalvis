using Kalvis.Common.Domain;
using Kalvis.Contract.NotificationViewModel;

namespace Kalvis.Domain.NotificationEntities.Interface
{
    public interface INotificationRepository
            : IRepositoryBase<int, Notification>
    {
        List<GetAllNotificationItem> GetAllNotification(bool IsRemove);
    }
}
