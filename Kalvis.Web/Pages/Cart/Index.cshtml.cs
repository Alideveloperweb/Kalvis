using System.Collections.Generic;
using Kalvis.Contract.OrderViewModel;
using Kalvis.Contract.OrderViewModel.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        #region Constracture
        private readonly IOrderApplication _OrderApp;
        public IndexModel(IOrderApplication OrderApp)
        {
            _OrderApp = OrderApp;
        }

        #endregion

        public List<DetailOrderItem> Detail { get; set; }
        public void OnGet()
        {
            Detail = new();

            long UserID = long.Parse(User.FindFirst("userid").Value);
            var Order = _OrderApp.GetOrder(UserID);
            if (Order != null)
                Detail = _OrderApp.GetOrderDetail(Order.OrderID, UserID);

        }
    }
}
