using Kalvis.Common.Domain;
using Kalvis.Contract.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Domain.OrderEntities.CourseOrderEntities.Interface
{
    public interface IOrderDetailRepository
        : IRepositoryBase<long, CourseOrderDetails>
    {
        void RemoveCourseForCart(long OrderID, long OrderDetailID);

        List<DetailOrderItem> GetOrderDetail(long OrderID, long UserID);
    }
}
