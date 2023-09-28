using Kalvis.Common.Application;
using Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel;
using Kalvis.Contract.OrderViewModel;
using Kalvis.Contract.OrderViewModel.Interface;
using Kalvis.Domain.DiscountEntities.CourseDisCountEntities.Interface;
using Kalvis.Domain.EducationEntities.CourseEntities;
using Kalvis.Domain.EducationEntities.CourseEntities.Interface;
using Kalvis.Domain.OrderEntities.CourseOrderEntities;
using Kalvis.Domain.OrderEntities.CourseOrderEntities.Interface;
using ZarinpalSandbox;

namespace Kalvis.Application.OrderApp
{
    public class OrderApplication : IOrderApplication
    {
        #region Constracture
        private readonly IOrderRepository _OrderRep;
        private readonly IOrderDetailRepository _OrderDetailRep;
        private readonly ICourseRepository _CourseRep;
        private readonly ICourseDisCountRepository _DisCountRep;
        private readonly IUserCourseRepository _UserCourse;
        public OrderApplication(
            IOrderRepository OrderRep,
        IOrderDetailRepository OrderDetailRep,
        ICourseRepository CourseRep,
        ICourseDisCountRepository DisCountRep,
        IUserCourseRepository UserCourse
            )
        {
            this._CourseRep = CourseRep;
            this._OrderRep = OrderRep;
            this._OrderDetailRep = OrderDetailRep;
            this._DisCountRep = DisCountRep;
            this._UserCourse = UserCourse;
        }
        #endregion

        public OperationResult CreateCart(CreateOrderItem createOrder)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("سبد خرید");

            var getorder = GetOrder(createOrder.UserID);
            var GetCourse = _CourseRep.Get(createOrder.CourseID);
            if (getorder == null)
            {
                CourseOrders order =
                    new(createOrder.UserID, GetCourse.CoursePrice);

                OperationResult OperationOrder =
                    CreateOrder(order);

                if (OperationOrder.Code != Operation.Success)
                    return operationResult.Failed(Operation.Error, message.ErrorCreate());

                CourseOrderDetails orderDetails = new(order.Id,
                   createOrder.CourseID, GetCourse.CoursePrice);

                OperationResult OperationDetail =
                    CreateOrderDetail(orderDetails);

                if (OperationDetail.Code != Operation.Success)
                    return operationResult.Failed(Operation.Error, message.ErrorCreate());

                return operationResult.Success(Operation.Success, message.Create());

            }
            else
            {
                var OrderDetail =
                    GetOrderDetail(getorder.OrderID, getorder.UserID);

                if (OrderDetail.Where(x => x.CourseID == createOrder.CourseID).Any())
                    return operationResult.Failed(Operation.Dublicade, message.Dublicate("دوره"));

                CourseOrderDetails courseOrderDetails =
                    new(getorder.OrderID, GetCourse.Id, GetCourse.CoursePrice);

                OperationResult OperationDetail =
                             CreateOrderDetail(courseOrderDetails);

                if (OperationDetail.Code != Operation.Success)
                    return operationResult.Failed(Operation.Error, message.ErrorUpdate());

                getorder.TotalSum += GetCourse.CoursePrice;

                var Order = _OrderRep.Get(getorder.OrderID);
                Order.UpdateCart(getorder.TotalSum);

                OperationResult OperationOrderUpdate =
                    UpdateOrder(Order);

                if (OperationOrderUpdate.Code != Operation.Success)
                    return operationResult.Failed(Operation.Error, message.ErrorUpdate());

                return operationResult.Success(Operation.Success, message.Update());

            }

        }

        public GetOrderItem GetOrder(long UserID)
        {
            return _OrderRep.GetOrder(UserID);
        }

        public OperationResult CreateOrder(CourseOrders orders)
        {
            OperationResult operationResult = new();

            bool Create = _OrderRep.Create(orders);
            if (!Create)
                return operationResult.Failed(Operation.Error);

            bool Save = _OrderRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error);

            return operationResult.Success(Operation.Success);
        }

        public OperationResult CreateOrderDetail(CourseOrderDetails OrderDetail)
        {

            OperationResult operationResult = new();

            bool Create = _OrderDetailRep.Create(OrderDetail);
            if (!Create)
                return operationResult.Failed(Operation.Error);

            bool Save = _OrderRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error);

            return operationResult.Success(Operation.Success);

        }

        public List<DetailOrderItem> GetOrderDetail(long OrderID, long UserID)
        {
            return _OrderDetailRep.GetOrderDetail(OrderID, UserID);
        }

        public OperationResult UpdateOrder(CourseOrders course)
        {
            OperationResult operationResult = new();

            bool Create = _OrderRep.Update(course);
            if (!Create)
                return operationResult.Failed(Operation.Error);

            bool Save = _OrderRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error);

            return operationResult.Success(Operation.Success);
        }


        public ZarinPalItem ZarinPal(ZarinPalItem zarinPal)
        {
            ZarinPalItem zarinPalItem = new();

            var Order = _OrderRep.GetOrder(zarinPal.UserID);

            if (Order == null)
                return null;

            if (!String.IsNullOrEmpty(zarinPal.DisCountCode))
            {
                var Res = _DisCountRep.GetDisCount(zarinPal.DisCountCode);

                int Price = ((Order.TotalSum * Res.Persistant) / 100);

                CourseOrders courseOrder = _OrderRep.Get(Order.OrderID);
                courseOrder.DisCountID = Res.DisCountID;
                Order.TotalSum -= Price;
                _OrderRep.Update(courseOrder);
                _OrderRep.SaveChanges();
            }

            var Zarin = new Payment(Order.TotalSum);

            var Result = Zarin.PaymentRequest("خرید دوره", zarinPal.UrlSite +
                "/Cart/ZarinPal/UrlBack/" + Order.OrderID);

            if (Result.Result.Status == 100)
            {
                zarinPalItem.Redirect = "https://sandbox.zarinpal.com/pg/StartPay/"
                    + Result.Result.Authority;
                return zarinPalItem;

            }

            return null;
        }

        public VerificationZarinPalItem VerificationPay(VerificationZarinPalItem verification)
        {
            VerificationZarinPalItem Pay = new();

            var Order = _OrderRep.Get(verification.OrderID);
            var OrderSumDiscount = 0;

            if (Order == null)
                return null;

            if (Order.DisCountID != null && Order.DisCountID > 0)
            {
                var DisCount = _DisCountRep.GetDisCount(Order.DisCountID.Value);
                int price = ((Order.OrderSum * DisCount.Persistant) / 100);
                OrderSumDiscount = Order.OrderSum - price;
            }

            var zarin = new Payment(OrderSumDiscount > 0 ? OrderSumDiscount
                : Order.OrderSum);

            var Result = zarin.Verification(verification.Authority).Result;

            if (Result.Status == 100)
            {
                Order.VerificationOrder();
                UpdateOrder(Order);

                Pay.RefID = Result.RefId.ToString();
                Pay.Status = Result.Status.ToString();
                AddUserCourse(Order.Id, Order.UserId);

                var CalCulate = _OrderRep.CalculateComission(Order.Id);
                _OrderRep.AddCalculateComssion(CalCulate);

                return Pay;

            }
            return null;
        }


        public OperationResult AddUserCourse(long OrderID, long UserID)
        {
            OperationResult operationResult = new();
            List<UserCourse> UserCourse = new();
            var OrderDetail = _OrderDetailRep.GetOrderDetail(OrderID, UserID);

            foreach (var item in OrderDetail)
                UserCourse.Add(new UserCourse(0, UserID, item.CourseID));

            bool Create = _UserCourse.CreateRange(UserCourse);
            if (!Create)
                return operationResult.Failed(Operation.Error);

            bool Save = _UserCourse.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error);

            return operationResult.Success(Operation.Success);
        }

        public List<CalculateComissionItem> CalculateComission(long OrderID)
        {
            return _OrderRep.CalculateComission(OrderID);
        }



        public OperationResult UpdateCart(CreateOrderItem UpdateCart)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("سبد خرید");

            var getorder = GetOrder(UpdateCart.UserID);
            var GetCourse = _CourseRep.Get(UpdateCart.CourseID);
            if (getorder == null)
            {
                CourseOrders order =
                    new(UpdateCart.UserID, GetCourse.CoursePrice);

                OperationResult OperationOrder =
                    CreateOrder(order);

                if (OperationOrder.Code != Operation.Success)
                    return operationResult.Failed(Operation.Error, message.ErrorCreate());

                CourseOrderDetails orderDetails = new(order.Id,
                   UpdateCart.CourseID, GetCourse.CoursePrice);

                OperationResult OperationDetail =
                    CreateOrderDetail(orderDetails);

                if (OperationDetail.Code != Operation.Success)
                    return operationResult.Failed(Operation.Error, message.ErrorCreate());

                return operationResult.Success(Operation.Success, message.Create());

            }
            else
            {
                var OrderDetail =
                    GetOrderDetail(getorder.OrderID, getorder.UserID);

                if (!OrderDetail.Where(x => x.CourseID == UpdateCart.CourseID).Any())
                    return operationResult.Failed(Operation.Nullabel, message.Nullabele());

                var Detail = OrderDetail
                    .Where(x => x.CourseID == UpdateCart.CourseID).FirstOrDefault();

                getorder.TotalSum -= Detail.Price;

                var Order = _OrderRep.Get(getorder.OrderID);
                Order.UpdateCart(getorder.TotalSum);

                RemoveCourseForCart(Order.Id, Detail.DetailID);

                OperationResult OperationOrderUpdate =
                    UpdateOrder(Order);

                if (OperationOrderUpdate.Code != Operation.Success)
                    return operationResult.Failed(Operation.Error, message.ErrorUpdate());

                return operationResult.Success(Operation.Success, message.Update());

            }



        }
        public void RemoveCourseForCart(long OrderID, long OrderDetailID)
        {
            _OrderDetailRep.RemoveCourseForCart(OrderID, OrderDetailID);
        }
    }
}
