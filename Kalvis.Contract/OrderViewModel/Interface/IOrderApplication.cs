using Kalvis.Common.Application;

namespace Kalvis.Contract.OrderViewModel.Interface
{
    public interface IOrderApplication
    {
        OperationResult CreateCart(CreateOrderItem createOrder);
        GetOrderItem GetOrder(long UserID);
        List<DetailOrderItem> GetOrderDetail(long OrderID, long UserID);
        List<CalculateComissionItem> CalculateComission(long OrderID);
        ZarinPalItem ZarinPal(ZarinPalItem zarinPal);
        VerificationZarinPalItem VerificationPay(VerificationZarinPalItem verification);
        OperationResult UpdateCart(CreateOrderItem UpdateCart);
    }
}
