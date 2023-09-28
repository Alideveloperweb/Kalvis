
namespace Kalvis.Contract.NotificationViewModel.Interface
{
    public interface INotificationApplication
    {
        List<GetAllNotificationItem> GetAllNotification(bool IsRemove);
    }
}
