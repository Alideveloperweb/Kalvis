using Kalvis.Common.Domain;
using Kalvis.Domain.OrderEntities.CourseOrderEntities;


namespace Kalvis.Domain.DiscountEntities.CourseDisCountEntities
{

    public class CourseDisCount : EntityBase<int>
    {
        #region Properties
        public string Code { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndtDate { get; private set; }
        public byte Value { get; private set; }
        public int? MaxUserCount { get; private set; }
        #endregion

        #region Create
        public CourseDisCount(string Code, DateTime? StartDate,
            DateTime? EndtDate, byte Value, int? MaxUserCount)
        {
            this.Code = Code;
            this.StartDate = StartDate;
            this.EndtDate = EndtDate;
            this.Value = Value;
            this.MaxUserCount = MaxUserCount;
        }
        #endregion

        #region Edit
        public void Edit(string Code, DateTime? StartDate,
            DateTime? EndtDate, byte Value, int? MaxUserCount)
        {
            this.Code = Code;
            this.StartDate = StartDate;
            this.EndtDate = EndtDate;
            this.Value = Value;
            this.MaxUserCount = MaxUserCount;
            this.LastUpdate = DateTime.Now;
        }
        #endregion

        #region Remove
        public void Remove()
        {
            this.IsRemove = true;
        }
        #endregion

        #region Restore
        public void Restore()
        {
            this.IsRemove = false;
        }
        #endregion

        #region Relation
        public List<CourseOrders> courseOrders { get; private set; }
        #endregion
    }
}
