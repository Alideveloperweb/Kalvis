using Kalvis.Common.Application;
using Kalvis.Contract.OrderViewModel;
using Kalvis.Domain.OrderEntities.CourseOrderEntities;
using Kalvis.Domain.OrderEntities.CourseOrderEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;
using Microsoft.EntityFrameworkCore;


namespace Kalvis.EfCore.Repository.ORderRepository
{
    public class OrderDetailRepository :
        RepositoryBase<long, CourseOrderDetails>, IOrderDetailRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        public OrderDetailRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
        #endregion

        public List<DetailOrderItem> GetOrderDetail(long OrderID, long UserID)
        {
            return _context.CourseOrderDetails
                .Include(x => x.CourseOrders)
                .Include(x => x.Course)
                .Where(x => x.OrderId == OrderID)
                .Where(x => x.CourseOrders.UserId == UserID)
                .Select(x => new DetailOrderItem
                {
                    CourseID = x.CourseId,
                    CourseImage = Router.RouteImageEducation +
                                _context.Categories.FirstOrDefault(c => c.Id == x.Course.CategoryId).EnCategoryName
                                + "/" + x.Course.CourseImage,
                    CourseTitle = x.Course.CourseTitle,
                    DetailID = x.Id,
                    OrderID = x.OrderId,
                    UserID = x.CourseOrders.UserId,
                    Price = x.Price,

                })
                .ToList();
        }

        public void RemoveCourseForCart(long OrderID, long OrderDetailID)
        {
            var OrderDetail = _context.CourseOrderDetails
                 .Where(x => x.OrderId == OrderID).FirstOrDefault();
            _context.Remove(OrderDetail);
            _context.SaveChanges();
        }
    }
}
