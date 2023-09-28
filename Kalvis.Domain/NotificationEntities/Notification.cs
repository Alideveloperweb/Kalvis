using Kalvis.Common.Domain;
using Kalvis.Contract.NotificationViewModel;


namespace Kalvis.Domain.NotificationEntities
{
    public class Notification : EntityBase<int>
    {
        public string NotificcationTitle { get; private set; }
        public string NotificcationText { get; private set; }
    }
}
