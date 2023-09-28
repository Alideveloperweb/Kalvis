using Kalvis.Common.Domain;
using Kalvis.Domain.EducationEntities.CourseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.OrderEntities.CourseOrderEntities
{

    public class CourseOrderDetails : EntityBase<long>
    {
        public long OrderId { get; private set; }
        public long CourseId { get; private set; }
        public int Price { get; private set; }


        #region Create
        public CourseOrderDetails(
            long OrderId,
            long CourseId,
            int Price
            )
        {
            this.OrderId = OrderId;
            this.CourseId = CourseId;
            this.Price = Price;
        }
        #endregion

        #region Relation
        public CourseOrders CourseOrders { get; private set; }
        public Course Course { get; private set; }
        #endregion
    }
}
