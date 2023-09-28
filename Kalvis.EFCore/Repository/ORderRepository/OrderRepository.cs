
using Kalvis.Common.Application;
using Kalvis.Contract.OrderViewModel;
using Kalvis.Domain.EducationEntities.TeacherEntities.Interface;
using Kalvis.Domain.OrderEntities.CourseOrderEntities;
using Kalvis.Domain.OrderEntities.CourseOrderEntities.Interface;
using Kalvis.Domain.UserEntities;
using Kalvis.Domain.UserEntities.Interface;
using Kalvis.EFCore.ApplicationContexts;

namespace Kalvis.EfCore.Repository.ORderRepository
{
    public class OrderRepository
          : RepositoryBase<long, CourseOrders>, IOrderRepository
    {
        #region Constracture
        private readonly ApplicationContext _context;
        private readonly ITeacherRepository _TeacherRep;
        private readonly IUserRepository _UserRep;
        public OrderRepository(ApplicationContext context,
            ITeacherRepository TeacherRep,
            IUserRepository UserRep)
            : base(context)
        {
            _TeacherRep = TeacherRep;
            _context = context;
            _UserRep = UserRep;
        }


        #endregion

        public GetOrderItem GetOrder(long UserID)
        {
            return _context.CourseOrders
                  .Where(x => x.UserId == UserID)
                  .Where(x => !x.IsCancelled)
                  .Where(x => !x.Ispaid)
                  .Select(x => new GetOrderItem
                  {
                      IsCancelled = x.IsCancelled,
                      TotalSum = x.OrderSum,
                      IsPay = x.Ispaid,
                      OrderID = x.Id,
                      UserID = x.UserId,

                  })
                  .FirstOrDefault();
        }

        public List<CalculateComissionItem> CalculateComission(long OrderID)
        {
            return (from order in _context.CourseOrders
                    join discount in _context.CourseDisCounts on order.DisCountID
                    equals discount.Id into DisCount
                    from discount in DisCount.DefaultIfEmpty()

                    join orderDetail in _context.CourseOrderDetails on order.Id
                    equals orderDetail.OrderId

                    join course in _context.courses on orderDetail.CourseId
                    equals course.Id

                    where (order.Id == OrderID)
                    select new CalculateComissionItem
                    {
                        Comission = course.Percentage,
                        CourseID = course.Id,
                        CoursePrice = orderDetail.Price,
                        DisCountCode = discount.Code,
                        DiscountPercent = discount.Value,
                        OrderID = order.Id,
                        UserID = course.UserId

                    }).ToList();
        }

        public void AddCalculateComssion(List<CalculateComissionItem> calculates)
        {
            List<long> UserID = new();
            List<User> users = new();

            foreach (var item in calculates)
                UserID.Add(item.UserID);

            var UserList = _TeacherRep.getTeacherForCommition(UserID);

            foreach (var item in calculates)
            {
                var FindUser = UserList.Where(x => x.UserID == item.UserID).FirstOrDefault();

                var Comsion = (item.CoursePrice * item.Comission);

                FindUser.Wallet += (item.DiscountPercent == null ?
                    (Comsion / 100)
                    : (((Comsion * item.DiscountPercent.Value) / 100) - Comsion));

                User user = _UserRep.Get(FindUser.UserID);
                user.Comssion(FindUser.Wallet);
                _UserRep.Update(user);
            }
            _UserRep.SaveChanges();
        }
    }
}
