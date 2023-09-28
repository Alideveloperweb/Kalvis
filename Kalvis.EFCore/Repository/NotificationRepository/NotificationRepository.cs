using Kalvis.Common.Application;
using Kalvis.Contract.NotificationViewModel;
using Kalvis.Domain.NotificationEntities;
using Kalvis.Domain.NotificationEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;


namespace Kalvis.EfCore.Repository.NotificationRepository
{
    public class NotificationRepository :
            RepositoryBase<int, Notification>
        , INotificationRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public NotificationRepository(ApplicationContext context)
            : base(context)
        {
            this._context = context;
        }
        #endregion

        public List<GetAllNotificationItem> GetAllNotification(bool IsRemove)
        {
            return _context.Notifications
                 .Where(x => x.IsRemove == IsRemove)
                 .Select(x => new GetAllNotificationItem
                 {
                     NotificationId = x.Id,
                     NotificationCreate = ConvertDate.MiladiToShamsi(x.CreateDate),
                     NotificationText = x.NotificcationText,
                     NotificationTitle = x.NotificcationTitle,

                 })
                 .OrderByDescending(x => x.NotificationId)
                 .ToList();
        }
    }
}
