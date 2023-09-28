using Kalvis.Common.Domain;
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities;
using Kalvis.Domain.UserEntities;

namespace Kalvis.Domain.OrderEntities.CourseOrderEntities
{
    public class CourseOrders : EntityBase<long>
    {
        public long UserId { get; private set; }
        public int OrderSum { get; private set; }
        public bool Ispaid { get; private set; }
        public bool IsCancelled { get; private set; }
        public int? DisCountID { get; set; }
        #region Create
        public CourseOrders(long UserId, int OrderSum)
        {
            this.UserId = UserId;
            this.OrderSum = OrderSum;
        }
        #endregion

        #region UpdateCart
        public void UpdateCart(int OrderSum)
        {
            this.OrderSum = OrderSum;
            Ispaid = false;
            IsCancelled = false;
        }
        #endregion

        #region Verification
        public void VerificationOrder()
        {
            this.Ispaid = true;
        }
        #endregion

        #region Relation
        public User User { get; private set; }
        public CourseDisCount CourseDisCount { get; private set; }
        public List<CourseOrderDetails> CourseOrderDetails { get; private set; }
        #endregion
    }
}
