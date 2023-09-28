using Kalvis.Common.Domain;
using Kalvis.Contract.OrderViewModel;

namespace Kalvis.Domain.OrderEntities.CourseOrderEntities.Interface
{
    public interface IOrderRepository : IRepositoryBase<long, CourseOrders>
    {
        GetOrderItem GetOrder(long UserID);
        List<CalculateComissionItem> CalculateComission(long OrderID);
        void AddCalculateComssion(List<CalculateComissionItem> calculates);
    }
}
